using BuisnessLayer.interfaces;
using DataAcessLayer;
using DataAcessLayer.implementation;
using DataAcessLayer.interfaces;
using Share.DTOs;
using Share.entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.implementation
{
    public class BL_General : IBL_General
    {
        private IDAL_Viaje iViaje;
        private IDAL_Llegada iLllegada;
        private IDAL_Salida iSalida;
        private IDAL_Linea iLinea;
        private IDAL_Tramo iTramo;
        private IDAL_Parada iParada;
        private IDAL_Pasaje iPasaje;
        private IDAL_Usuario iUsuario;
        private IDAL_Vehiculo iVehiculo;
        private IDAL_Persona iPersona;

        private IDAL_Admin iAdmin;
        private IDAL_Conductor iConductor;
        private IDAL_SuperAdmin iSuperAd;

        public BL_General(IDAL_Viaje _iViaje, IDAL_Llegada _iLllegada, IDAL_Salida _iSalida,IDAL_Linea _iLinea, IDAL_Tramo _iTramo,IDAL_Parada _iParada,IDAL_Pasaje _iPasaje, IDAL_Usuario _iUsuario, IDAL_Vehiculo _iVehiculo, IDAL_Persona _iPersona, IDAL_Admin _iAdmin, IDAL_Conductor _iConductor, IDAL_SuperAdmin _iSuperAd)
        {
            iViaje = _iViaje;
            iLllegada = _iLllegada;
            iSalida = _iSalida;
            iLinea = _iLinea;
            iTramo = _iTramo;
            iParada = _iParada;
            iPasaje = _iPasaje;
            iUsuario = _iUsuario;
            iVehiculo = _iVehiculo;
            iPersona = _iPersona;
            iAdmin = _iAdmin;
            iConductor = _iConductor;
            iSuperAd = _iSuperAd;

        }

        public List<string> rolesPorEmail(string correo)
        {
            List<string> listStrR = new List<string>();

            int idPer = iPersona.getPerByEmail(correo).id;

            foreach (var rol in iPersona.getRol(idPer))
            {
                listStrR.Add(rol.ToString());
            }
            return listStrR;
        }
        public bool correoUnico(string email)
        {
            return iUsuario.verificarCorreo(email);
        }

        private bool isFinalParada(int idParada, int idViaje)
        {
            List<ETramo> trsDVje = iLinea.getLinea(iSalida.getSalidas(iViaje.getViaje(idViaje).IdSalida).IdLinea).Tramo.ToList();
            ETramo tramo =  trsDVje.Last();
            if (tramo.IdParada == idParada) return true;
            return false;
        }
        private bool isUltima(int idUltParada, List<ETramo> tramos)
        {
            int cant = tramos.Count();
            foreach (var t in tramos)
            {
                if(t.IdParada == idUltParada)
                {
                    if (t.Orden == cant)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private int orden(int idUltParada, List<ETramo> tramos)
        {
            foreach (var t in tramos)
            {
                if (t.IdParada == idUltParada)
                {
                    return t.Orden;
                }
            }
            return 0;
        }

        private EParada nextParada(List<ETramo> tramos, int ord)
        {
            foreach (var t in tramos)
            {
                if (t.Orden==(ord+1))
                {
                    return iParada.getParada(t.IdParada);
                }
            }
            EParada ep = new EParada();
            return ep;
        }
        public DTOnextBus CrearLlegada(int idViaje, TimeSpan hora, DateTime fecha)
        {
            List<ETramo> tramos = iLinea.getLinea(iSalida.getSalidas(iViaje.getViaje(idViaje).IdSalida).IdLinea).Tramo.ToList();

            List<EParada> paradas = new List<EParada>(); //todas las paradas del viaje
            foreach (var tramo in tramos)
            {
                paradas.Add(iParada.getParada(tramo.IdParada));
            }

            List<ELlegada> llegadas = new List<ELlegada>(); //todas las llegadas del viaje
            foreach (var llegada in iLllegada.getAllLlegadas())
            {
                if (llegada.idViaje == idViaje)
                {
                    llegadas.Add(iLllegada.getLlegada(llegada.idParada, llegada.idViaje));
                }
            }

            int idUltParada = llegadas.Last().idParada; //ultima llegada por la que paso

            EParada proxP = iParada.getParada(idUltParada);

            int ord = orden(idUltParada, tramos);

            if (!isUltima(idUltParada, tramos)) 
            {
                proxP = nextParada(tramos, ord);

                if (isFinalParada(proxP.IdParada, idViaje))
                {
                    iViaje.finalizarViaje(idViaje);
                    iLllegada.addLlegada(proxP.IdParada, idViaje, hora, fecha);
                    DTOnextBus ee = new DTOnextBus();
                    ee.matricula = "N/A";
                    ee.hora = "N/A";
                    ee.parada = "N/A";
                    return ee;
                }

                iLllegada.addLlegada(proxP.IdParada, idViaje, hora, fecha);

                DTOnextBus siguientesPjrs = notificacionProximidad2(proxP, idViaje, hora);
                return siguientesPjrs;
            }
            else
            {
                if (isFinalParada(proxP.IdParada, idViaje))
                {
                    iViaje.finalizarViaje(idViaje);

                    iLllegada.addLlegada(proxP.IdParada, idViaje, hora, fecha);

                    DTOnextBus sigui = new DTOnextBus();
                    sigui.matricula = "N/A";
                    sigui.hora = "N/A";
                    sigui.parada = "N/A";
                    return sigui;
                }

                iLllegada.addLlegada(proxP.IdParada, idViaje, hora, fecha);

                DTOnextBus siguientesPjrs = new DTOnextBus();
                siguientesPjrs.matricula = "N/A";
                siguientesPjrs.hora = "N/A";
                siguientesPjrs.parada = "N/A";
                return siguientesPjrs;
            }
        }
        public List<EUsuario> notificacionProximidad(int Parada, int viaje)
        {
            List<EUsuario> usuarios = new List<EUsuario>();
            if (isFinalParada(Parada, viaje))
            {
                return usuarios;
            }
            int idNextP = nextParadaNot(Parada, viaje);
            //int idNextP = Parada;
            List<EPasaje> pasajes = iPasaje.getAllPasajes();
            foreach (var pasaje in pasajes)
            {
                if (pasaje.IdParadaOrigen == idNextP && pasaje.IdUsuario != null)
                {
                    usuarios.Add(iUsuario.getUsuario(pasaje.IdUsuario ?? default(int)));
                }
            }
            return usuarios;

        }
        private DTOnextBus notificacionProximidad2(EParada Eparada, int viaje, TimeSpan hora)
        {
            int Parada = Eparada.IdParada;
            ESalida salida = iSalida.getSalidas(iViaje.getViaje(viaje).IdSalida);

            string matric = iVehiculo.getVehiculos(salida.IdVehiculo).Matricula;
            

            DTOnextBus nextBus = new DTOnextBus();
            if (isFinalParada(Parada, viaje))
            {
                nextBus.matricula = "N/A";
                nextBus.parada = "N/A";
                nextBus.hora = "N/A";
                return nextBus;
            }
            int idNextP = nextParadaNot(Parada, viaje);

            int tiempo = iTramo.getTramos(salida.IdLinea, idNextP).TiempoEstimado;
            TimeSpan minutes = TimeSpan.FromMinutes(tiempo);

            string horastr = hora.Add(minutes).ToString();
            nextBus.parada = iParada.getParada(idNextP).Nombre;
            nextBus.matricula = matric;
            nextBus.hora = horastr;

            return nextBus;

        }

        public void finalizarViaje(int idViaje)
        {
            iViaje.finalizarViaje(idViaje);
        }

        private int nextParadaNot(int Parada, int viaje)
        {
            List<ETramo> tramos= iLinea.getLinea(iSalida.getSalidas(iViaje.getViaje(viaje).IdSalida).IdLinea).Tramo.ToList();
            int ord = orden(Parada, tramos);
            return nextParada(tramos, ord).IdParada;
        }

        private int valorVigente(int idLinea, int idParada)
        {
            ETramo t = iTramo.getTramos(idLinea, idParada);
            List<EPrecio> lst = t.Precio.ToList();

            List<EPrecio> lst2 = new List<EPrecio>();

            foreach (var l in lst)
            {
                if (l.FechaEntradaVigencia.CompareTo(DateTime.Today) == -1)
                {
                    lst2.Add(l);
                }
            }

            lst2.OrderBy(r => r.FechaEntradaVigencia);

            return lst2.Last().Precio1;
        }
        private int costoEntreParadas(int idLinea, int IdParadaOrigen, int IdParadaDestino)
        {
            List<ETramo> tramos = iLinea.getLinea(idLinea).Tramo.ToList();
            iParada.getParada(IdParadaOrigen);

            int orednOrigen = iTramo.getTramos(idLinea, IdParadaOrigen).Orden;
            int orenDestingo = iTramo.getTramos(idLinea, IdParadaDestino).Orden;


            List<int> ordenes = new List<int>();
            for (int i = orednOrigen; i <= orenDestingo; i++)
            {
                ordenes.Add(i);
            }

            int costoPasaje = 0;
            foreach (var tramo in tramos)
            {
                foreach (var orden in ordenes)
                {
                    if(tramo.Orden == orden)
                    {
                        costoPasaje = costoPasaje + valorVigente(idLinea, tramo.IdParada);
                    }
                }
            }

            return costoPasaje;
        }
        private float utilidadPorViaje(int idViaje)
        {
            EViaje ev = iViaje.getViaje(idViaje);
            if (ev == null)
            {
                return -1;
            }
            int cantAsientos = iVehiculo.getVehiculos(iSalida.getSalidas(ev.IdSalida).IdVehiculo).CantAsientos;
            int idLinea = iSalida.getSalidas(iViaje.getViaje(idViaje).IdSalida).IdLinea;

            int maxCostoPsaje = 0;
            foreach (var tramo in iLinea.getLinea(idLinea).Tramo.ToList())
            {
                maxCostoPsaje = maxCostoPsaje + valorVigente(idLinea, tramo.IdParada);
            }

            int maxUtilidad = maxCostoPsaje * cantAsientos;


            int costoPasajes = 0;
            foreach (var pasaje in iViaje.getViaje(idViaje).Pasaje.ToList())
            {
                costoPasajes = costoPasajes + costoEntreParadas(idLinea, pasaje.IdParadaOrigen, pasaje.IdParadaDestino);
            }
            float utilidad = (float)costoPasajes / (float)maxUtilidad;
            return utilidad;
        }


        private float utilidadPorSalida(int salida, List<DateTime> fechas)
        {
            float costo = 0;
            ESalida sal = iSalida.getSalidas(salida);
            if (sal == null)
            {
                return -1;
            }
            foreach (var viaje in sal.Viaje.ToList())
            {
                if (fechas.Contains(viaje.Fecha))
                {
                    costo = costo + utilidadPorViaje(viaje.IdViaje);
                }
            }
            return costo;
 
        }
        private float utilidadPorLinea(int linea, List<DateTime> fechas)
        {
            float costo = 0;
            ELinea lin = iLinea.getLinea(linea);
            if (lin == null)
            {
                return -1;
            }
            foreach (var salida in lin.Salida.ToList())
            {
                costo = costo + utilidadPorSalida(salida.IdSalida, fechas);
            }
            return costo;
        }
        public float reporteUtilidad(int idViaje, DateTime fechaDesde, DateTime fechaHasat, int linea, int salida)
        {

            if (DateTime.Compare(fechaDesde, Convert.ToDateTime("1900,01,01")) == 0 || DateTime.Compare(fechaHasat, Convert.ToDateTime("1900,01,01")) == 0) return utilidadPorViaje(idViaje);


            List<DateTime> fechas = obtenerFechas(fechaDesde, fechaHasat);
            if (linea != -1) return utilidadPorLinea(linea, fechas);
            if (salida != -1) return utilidadPorSalida(salida, fechas);
            if (idViaje != -1) return utilidadPorViaje(idViaje);
            throw new Exception("Error en los parametros");


        }


        private List<DateTime> obtenerFechas(DateTime fechaDesde, DateTime fechaHasat) {
            List<DateTime> resultado = new List<DateTime>();

            for (DateTime n = fechaDesde; n.CompareTo(fechaHasat) <= 0; n = n.AddDays(1))
            {
                resultado.Add(n);
            }

            return resultado;
        }
        private List<EPasaje> pasajesDeViaje(int viaje) {
            EViaje v = iViaje.getViaje(viaje);
            if (v == null) 
            {
                return new List<EPasaje>();
            }
            return v.Pasaje.ToList();
        }

        private List<EPasaje> pasajeDeFechas(List<DateTime> fechas) 
        {
            List<EPasaje> pasajes = new List<EPasaje>();

            foreach (var viaje in iViaje.getAllViajes())
            {
                if (fechas.Contains(viaje.Fecha)) {

                    foreach (var pasaje in viaje.Pasaje.ToList())
                    {
                        pasajes.Add(pasaje);
                    }
                }
            }
            return pasajes;
        }

        private List<EPasaje> pasajesDeSalida(int salida, List<DateTime> fechas) 
        {
            List<EPasaje> pasajes = new List<EPasaje>();
            ESalida es = iSalida.getSalidas(salida);
            if (es == null) 
            {
                return pasajes;
            }
            foreach (var viaje in es.Viaje.ToList())
            {
                if (fechas.Contains(viaje.Fecha))
                {

                    foreach (var pasaje in viaje.Pasaje.ToList())
                    {
                        pasajes.Add(pasaje);
                    }
                }
            }
            return pasajes;
        }

        private List<EPasaje> pasajesDeLinea(int linea, List<DateTime> fechas) 
        {
            List<EPasaje> pasajes = new List<EPasaje>();
            ELinea l = iLinea.getLinea(linea);
            if (l == null)
            {
                return pasajes;
            }
            foreach (var salida in l.Salida.ToList())
            {
                foreach (var pas in pasajesDeSalida(salida.IdSalida, fechas))
                {
                    pasajes.Add(pas);
                }
            }
            return pasajes;
        }


        /// <summary>
        ///Si solo me pasan fechas retorno los pasajes de los viajes de esas fechas(No me deben pasar el id del viaje), 
        ///Si me pasan viaje retorno los pasajes del viaje (No me deben pasar fechas),
        ///Si me pasan salida retorno los pasajes de los viajes de la salida(No me deben pasar el id del viaje);
        ///si me pasan linea retorno los pasajes de los viajes de las salidas de la linea(No me deben pasar el id del viaje)
        ///     
        /// </summary>
        /// <param name="fechaDesde">(1900,01,01) si no es por fecha</param>
        /// <param name="fechaHasat">(1900,01,01) si no es por fecha</param>
        /// <param name="linea"> -1 si no es por linea</param>
        /// <param name="salida"> -1 si no es por salida</param>
        /// <param name="viaje"> -1 si no es por viaje</param>
        /// <returns></returns>
        public List<EPasaje> reposrtesPasajes(DateTime fechaDesde, DateTime fechaHasat, int linea, int salida, int viaje)
        {   
            List<EPasaje> PasajesDentro = new List<EPasaje>();
            if (fechaDesde == new DateTime (1900,01,01) || fechaHasat == new DateTime (1900,01,01)) {
                return pasajesDeViaje(viaje);
            }
            else { 
                List<DateTime> fechas = obtenerFechas(fechaDesde,fechaHasat);
                if(linea != -1) return pasajesDeLinea(linea,fechas);
                if(salida != -1) return pasajesDeSalida(salida,fechas);
                if (viaje == -1) return pasajeDeFechas(fechas);
            }
             throw new Exception("Error en los parametros");
        }

        public EPersona iniciarSesion(string email, string password, string rol)
        {

            EPersona res = new EPersona();
            res.pNombre = "Error";

            EPersona ep = new EPersona();
            foreach (var item in iPersona.getAllPersona())
            {
                if (item.Correo == email && item.Password == password)
                {
                    ep = item;
                    break;
                }
            }
            if (rol== "Usuario")
            {
                EUsuario eu = null;
                try
                {
                    eu = iUsuario.getUsuario(ep.id);
                }
                catch (Exception)
                {
                }
                if (eu!=null)
                {
                    return ep;
                }
                else
                {
                    ep.pNombre = "ErrorRol";
                    return ep;
                }
            }

            if (rol == "Conductor")
            {
                EConductor eu = null;
                try
                {
                    eu = iConductor.getConductor(ep.id);
                }
                catch (Exception)
                {
                }
                if (eu != null)
                {
                    return ep;
                }
                else
                {
                    ep.pNombre = "ErrorRol";
                    return ep;
                }
            }
            if (rol == "Admin")
            {
                EAdmin eu = null;
                try
                {
                    eu = iAdmin.getAdmin(ep.id);
                }
                catch (Exception)
                {
                }
                if (eu != null)
                {
                    return ep;
                }
                else
                {
                    ep.pNombre = "ErrorRol";
                    return ep;
                }
            }

            if (rol == "SuperAdmin")
            {
                ESuperAdmin eu = null;
                try
                {
                    eu = iSuperAd.getSuperAdmin(ep.id);
                }
                catch (Exception)
                {
                }
                if (eu != null)
                {
                    return ep;
                }
                else
                {
                    ep.pNombre = "ErrorRol";
                    return ep;
                }
            }

            return res;
        }
    }
}
