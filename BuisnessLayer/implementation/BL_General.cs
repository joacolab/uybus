using BuisnessLayer.interfaces;
using DataAcessLayer;
using DataAcessLayer.implementation;
using DataAcessLayer.interfaces;
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

        public BL_General(IDAL_Viaje _iViaje, IDAL_Llegada _iLllegada, IDAL_Salida _iSalida,IDAL_Linea _iLinea, IDAL_Tramo _iTramo,IDAL_Parada _iParada,IDAL_Pasaje _iPasaje)
        {
            iViaje = _iViaje;
            iLllegada = _iLllegada;
            iSalida = _iSalida;
            iLinea = _iLinea;
            iTramo = _iTramo;
            iParada = _iParada;
            iPasaje = _iPasaje;
        }

        public ELlegada CrearLlegada(int idParada, int idViaje, TimeSpan hora)
        {
            return iLllegada.addLlegada(idParada, idViaje, hora);
            
        }

        public void finalizarViaje(int idViaje)
        {
            iViaje.finalizarViaje(idViaje);
        }

        public List<EUsuario> notificacionProximidad(int Parada, int viaje)
        {

            List<EUsuario> usuarios = new List<EUsuario>();
            int idL = iSalida.getSalidas(iViaje.getViaje(viaje).IdSalida).IdLinea;

             ETramo tramo = iTramo.getTramos(idL ,Parada);

            List<ETramo> etramos = iLinea.getLinea(idL).Tramo.ToList();
            EParada proximaParada = null;
            
            foreach (var item in etramos)
            {
               
                if (item.Orden == tramo.Orden +1) {
                    proximaParada = iParada.getParada(item.IdParada);
                    break;
                }

               
            }
            if (proximaParada == null) throw new Exception("Parada no encontrada");

            foreach (var item in proximaParada.Pasaje1.ToList())
            {
                if(item.Usuario != null)   usuarios.Add(item.Usuario);
            }


            return usuarios;
        }

        public float reporteUtilidad(int idViaje, DateTime fechaDesde, DateTime fechaHasat, int linea, int salida)
        {
            throw new NotImplementedException();
        }
        private List<DateTime> obtenerFechas(DateTime fechaDesde, DateTime fechaHasat) {
            List<DateTime> resultado = new List<DateTime>();

            int anioInicio = fechaDesde.Year;
            int anioFinal = fechaHasat.Year;
            int cantAnios = anioFinal - anioInicio;



            int cantDias = fechaDesde.DayOfYear - fechaHasat.DayOfYear;
            for (int i = 0; i <= cantAnios; i++)
            {
                for (int e = 0; e <= cantDias; e++)
                {
                    resultado.Add(fechaDesde.AddYears(i).AddDays(e));
                    
                }

            }
            foreach (var item in resultado)
            {
                Console.WriteLine(item);

            }
            return resultado;
        }
        private List<EPasaje> pasajesDeViaje(int viaje) {
            return iViaje.getViaje(viaje).Pasaje.ToList();
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
            foreach (var viaje in iSalida.getSalidas(salida).Viaje.ToList())
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
            foreach (var salida in iLinea.getLinea(linea).Salida.ToList())
            {

                pasajes.Concat(pasajesDeSalida(salida.IdSalida, fechas));
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
    }
}
