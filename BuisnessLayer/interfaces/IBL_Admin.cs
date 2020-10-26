using Share.entities;
using Share.enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.interfaces
{
    public interface IBL_Admin
    {
        /// <summary>
        /// Crea un conjunto de viajes para ser utilizados más adelante
        /// desde "fechaInicio" hasta "fechaFinal", los dias "diasSemana"
        /// ej: 01/06/2020, 30/06/2020, l ma mi j v, son 22 viajes
        /// </summary>
        /// <param name="fechaInicio">Fecha inicial en la que se crearan los viajes</param>
        /// <param name="fechaFinal">Fecha de finalización del conjutno de viajes</param>
        /// <param name="diasSemana">Días de la semana en los que se realiza el viaje</param>
        /// <param name="idSalida">Identificador de salida correspondiente a los horarios de salida</param>
        /// <returns></returns>
        List<EViaje> crearViajes(DateTime fechaInicio, DateTime fechaFinal, List<Dias> diasSemana, int idSalida);
        EVehiculo crearVehiculos(string Marca, string Modelo, string Matrícula, int cantAsientos);
        EVehiculo editarVehiculos(string Marca, string Modelo, string Matrícula, int cantAsientos);

        EParada crearParada(string nombre, double lat, double lon);

        ELinea crearLinea(string nombre);

        ETramo crearTramos(int idParada, int idLinea, int tiempoEst, int orden, int precio, DateTime FechaEntradaVigencia);

        /// <summary>
        /// aniade la fecha de vencimiento de libreta de conducir al condutor
        /// </summary>
        /// <param name="idUsuario">id del conductor</param>
        /// <param name="venLibreta">fecha de venciemiento de libreta de conducir</param>
        /// <returns></returns>
        void gestionConductores(int idUsuario, DateTime venLibreta);

        ESalida crearSalida(int idConductor, string Matricula, int idLinea, TimeSpan horaInicio);
    }
}
