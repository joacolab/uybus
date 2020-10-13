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

        public BL_Admin()
        {
            iLinea = new DAL_Linea();
            iParada = new DAL_Parada();
            iSalida = new DAL_Salida();
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
            throw new NotImplementedException();
        }

        public EVehiculo crearVehiculos(string Marca, string Modelo, string Matrícula, int cantAsientos)
        {
            throw new NotImplementedException();
        }

        public List<EViaje> crearViajes(DateTime fechaInicio, DateTime fechaFinal, List<Dias> diasSemana, int idSalida)
        {
            throw new NotImplementedException();
        }

        public EVehiculo editarVehiculos(string Marca, string Modelo, string Matrícula, int cantAsientos)
        {
            throw new NotImplementedException();
        }

        public void gestionConductores(int idUsuario, DateTime venLibreta)
        {
            throw new NotImplementedException();
        }
    }
}
