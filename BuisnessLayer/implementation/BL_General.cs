using BuisnessLayer.interfaces;
using DataAcessLayer.implementation;
using DataAcessLayer.interfaces;
using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.implementation
{
    public class BL_General : IBL_General
    {

        private IDAL_Linea iLinea;
        private IDAL_Parada iParada;
        private IDAL_Salida iSalida;
        private IDAL_Vehiculo iVehiculo;
        private IDAL_Conductor iConductor;
        private IDAL_Tramo iTramo;
        private IDAL_Precio iPrecio;
        private IDAL_Viaje iViaje;
        private IDAL_Llegada iLllegada;


        public BL_General()
        {
            iLinea = new DAL_Linea();
            iParada = new DAL_Parada();
            iSalida = new DAL_Salida();
            iVehiculo = new DAL_Vehiculo();
            iConductor = new DAL_Conductor();
            iTramo = new DAL_Tramo();
            iPrecio = new DAL_Precio();
            iViaje = new DAL_Viaje();
            iLllegada = new DAL_Llegada();
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
            throw new NotImplementedException();
        }

        public float reporteUtilidad(int idViaje, DateTime fechaDesde, DateTime fechaHasat, int linea, int salida)
        {
            throw new NotImplementedException();
        }

        public List<EPasaje> reposrtesPasajes(DateTime fechaDesde, DateTime fechaHasat, int linea, int salida)
        {
            throw new NotImplementedException();
        }
    }
}
