using BuisnessLayer.interfaces;
using DataAcessLayer.implementation;
using DataAcessLayer.interfaces;
using Share.DTOs;
using Share.entities;
using Share.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.implementation
{
    public class BL_Admin : IBL_Admin
    {
        private IDAL_Linea iLinea;
        private IDAL_Parada iParada;
        private IDAL_Salida iSalida;
        private IDAL_Vehiculo iVehiculo;
        private IDAL_Conductor iConductor;
        private IDAL_Tramo iTramo;
        private IDAL_Precio iPrecio;
        private IDAL_Viaje iViaje;

        public BL_Admin(IDAL_Linea _iLinea, IDAL_Parada _iParada, IDAL_Salida _iSalida,
            IDAL_Vehiculo _iVehiculo, IDAL_Conductor _iConductor, IDAL_Tramo _iTramo,
            IDAL_Precio _iPrecio, IDAL_Viaje _iViaje)
        {
            iLinea = _iLinea;
            iParada = _iParada;
            iSalida = _iSalida;
            iVehiculo = _iVehiculo;
            iConductor = _iConductor;
            iTramo = _iTramo;
            iPrecio = _iPrecio;
            iViaje = _iViaje;
        }
        public ELinea crearLinea(string nombre)
        {
            return iLinea.addLinea(nombre);
        }
        public List<EParada> getAllParada()
        {
            return iParada.getAllParadas(); ;
        }
        public EParada crearParada(string nombre, double lat, double lon)
        {
            return iParada.addParada(nombre, lat, lon);
        }
        public EParada editarParada(int parada, string nombre, double lat, double lon)
        {
            return iParada.editParada(parada, nombre, lat, lon);
        }

        public ESalida crearSalida(int idConductor, string Matricula, int idLinea, TimeSpan horaInicio)
        {
            return iSalida.addSalida(Matricula, idLinea, horaInicio, idConductor);
        }

        public ETramo crearTramos(int idParada, int idLinea, int tiempoEst, int  orden, int precio, DateTime FechaEntradaVigencia)
        {
            ETramo et = new ETramo();
            et = iTramo.addTramo(tiempoEst, idLinea, idParada, orden);
            iPrecio.addPrecio(precio, FechaEntradaVigencia, idLinea, idParada);
            return et;
        }

        public EVehiculo crearVehiculos(string Marca, string Modelo, string Matrícula, int cantAsientos)
        {
            return iVehiculo.addVehiculo(Matrícula, Marca, Modelo, cantAsientos);
        }

        static public string diasToDays(Dias dia)
        {
            if (dia == Dias.Lunes) return "Monday";
            if (dia == Dias.Martes) return "Tuesday";
            if (dia == Dias.Miercoles) return "Wednesday";
            if (dia == Dias.Jueves) return "Thursday";
            if (dia == Dias.Viernes) return "Friday";
            if (dia == Dias.Sabado) return "Saturday";
            else return "Sunday";
        }
        static public List<DateTime> getFechas(DateTime incio, DateTime final, List<Dias> dias)
        {
            List<DateTime> resultado = new List<DateTime>();

            int diaInicio = incio.DayOfYear;
            int diaFinal = final.DayOfYear;
            int canDias = diaFinal - diaInicio;

            for (DateTime n = incio; n.CompareTo(final) <= 0; n = n.AddDays(1))
            {
                foreach (var d in dias)
                {
                    if (n.DayOfWeek.ToString() == diasToDays(d))
                    {
                        resultado.Add(n);
                        break;
                    }
                }
            }
            return resultado;
        }
        public List<EViaje> crearViajes(DateTime fechaInicio, DateTime fechaFinal, List<Dias> diasSemana, int idSalida)
        {
            List<EViaje> viajes = new List<EViaje>();
            List<DateTime> fechas = new List<DateTime>();

            fechas = getFechas(fechaInicio, fechaFinal, diasSemana);

            foreach (var f in fechas)
            {
                EViaje ev = new EViaje();
                ev = iViaje.addViaje(false, f, idSalida);
                viajes.Add(ev);
            }

            return viajes;
        }

        public EVehiculo editarVehiculos(string Marca, string Modelo, string Matricula, int cantAsientos)
        {
            return iVehiculo.editVehiculo(Matricula, Marca, Modelo, cantAsientos);
        }


        public EViaje editarViaje(int IdViaje, bool Finalizado, DateTime Fecha, TimeSpan? HoraInicioReal, int IdSalida)
        {
            return iViaje.editViaje(IdViaje, Finalizado, Fecha, HoraInicioReal, IdSalida);
        }


        public void gestionConductores(int idUsuario, DateTime venLibreta)
        {
            iConductor.updateFechaVencLib(idUsuario, venLibreta);
        }

        public List<EVehiculo> getAllVehiculos()
        {
            return iVehiculo.getAllVehiculos();
        }

        public EVehiculo getVehiculo(string matricula)
        {
            EVehiculo ev = iVehiculo.getVehiculos(matricula);
            ev.Salida = new List<ESalida>();
            return ev;
        }

        public List<EViaje> getAllViaje()
        {
            return iViaje.getAllViajes();  
        }

        public List<ELinea> getAllLineas() 
        {
            return iLinea.getAllLineas();
        }


        public ELinea editarLinea(int IdLinea, string Nombre)
        {
            return iLinea.editLinea(IdLinea, Nombre);
        }

        public ETramo getTramo(int IdParada, int IdLinea) 
        {
            return iTramo.getTramos(IdLinea, IdLinea);
        }

        public List<ETramo> getAllTramos()
        {
            return iTramo.getAllTramos();
        }

        public ETramo editarTramo(int IdLinea, int IdParada, DTOTramo tramo)
        {
            return iTramo.editarTramo(IdLinea, IdParada, tramo);
        }

        public List<EConductor> GetAllConductores()
        {
            return iConductor.getAllConductores();
        }

        public ESalida editarSalida(int IdSalida, TimeSpan HoraInicio, int IdConductor, string IdVehiculo, int IdLinea)
        {
            return iSalida.editSalida(IdSalida, HoraInicio, IdConductor, IdVehiculo, IdLinea);
        }


        public List<ESalida> GetAlSalidas()
        {
            return iSalida.getAllSalidas();
        }
    }
}
