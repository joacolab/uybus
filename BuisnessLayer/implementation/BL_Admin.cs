using BuisnessLayer.interfaces;
using DataAccessLayer.implementation;
using DataAccessLayer.interfaces;
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

        public BL_Admin()
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
        public ELinea crearLinea(string nombre)
        {
            return iLinea.addLinea(nombre);
        }

        public EParada crearParada(string nombre, double lat, double lon)
        {
            return iParada.addParada(nombre, lat, lon);
        }

        public ESalida crearSalida(int idConductor, string Matricula, int idLinea, TimeSpan horaInicio)
        {
            return iSalida.addSalida(Matricula, idLinea, horaInicio, idConductor);
        }

        public ETramo crearTramos(int idParada, int idLinea, int tiempoEst, int precio, DateTime FechaEntradaVigencia)
        {
            ETramo et = new ETramo();
            et = iTramo.addTramo(tiempoEst, idLinea, idParada);
            iPrecio.addPrecio(precio, FechaEntradaVigencia, idLinea, idParada);
            return et;
        }

        public EVehiculo crearVehiculos(string Marca, string Modelo, string Matrícula, int cantAsientos)
        {
            return iVehiculo.addVehiculo(Matrícula, Marca, Modelo, cantAsientos);
        }

        public List<EViaje> crearViajes(DateTime fechaInicio, DateTime fechaFinal, List<Dias> diasSemana, int idSalida, TimeSpan hrInicioReal)
        {
            List<EViaje> viajes = new List<EViaje>();

            // falta obtener fechas a partir de fechaInicio, fechaFinal, List<Dias> diasSeman

            List<DateTime> fechas = new List<DateTime>();

            foreach (var f in fechas)
            {
                EViaje ev = new EViaje();
                ev = iViaje.addViaje(false, f, hrInicioReal, idSalida);
                viajes.Add(ev);
            }

            return viajes;
        }

        public EVehiculo editarVehiculos(string Marca, string Modelo, string Matrícula, int cantAsientos)
        {
            return iVehiculo.editVehiculo(Matrícula, Marca, Modelo, cantAsientos);
        }

        public void gestionConductores(int idUsuario, DateTime venLibreta)
        {
            iConductor.updateFechaVencLib(idUsuario, venLibreta);
        }
    }
}
