using BuisnessLayer.interfaces;
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
        public ELinea crearLinea(string nombre)
        {
            throw new NotImplementedException();
        }

        public EParada crearParada(string nombre, float lat, float lon)
        {
            throw new NotImplementedException();
        }

        public ESalida crearSalida(int idConductor, string Matricula, int idLinea, TimeSpan horaInicio)
        {
            throw new NotImplementedException();
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
