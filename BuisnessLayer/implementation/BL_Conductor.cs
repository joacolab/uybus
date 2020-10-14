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
    public class BL_Conductor : IBL_Conductor
    {
        private IDAL_Linea iLinea;
        private IDAL_Parada iParada;
        private IDAL_Salida iSalida;
        private IDAL_Vehiculo iVehiculo;
        private IDAL_Conductor iConductor;
        private IDAL_Tramo iTramo;
        private IDAL_Precio iPrecio;
        private IDAL_Viaje iViaje;



        public BL_Conductor()
        {
            iLinea = new DAL_Linea();
            iParada = new DAL_Parada();
            iSalida = new DAL_Salida();
            iVehiculo = new DAL_Vehiculo();
            iConductor = new DAL_Conductor();
            iTramo = new DAL_Tramo();
            iPrecio = new DAL_Precio();
            iViaje = new DAL_Viaje();
        }
        public void iniciarViaje(int idViaje, TimeSpan horaInicioR)
        {
            iViaje.iniciarViaje(idViaje, horaInicioR);
        }

        public bool verificarPasaje(int codigoQR, int idParada)
        {
            throw new NotImplementedException();
        }
    }
}
