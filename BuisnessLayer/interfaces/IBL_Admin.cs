using Share.entities;
using Share.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.interfaces
{
    public interface IBL_Admin
    {
        /// <summary>
        /// Crea un conjunto de viajes para ser utilizados más adelante
        /// </summary>
        /// <param name="fechaInicio">Fecha inicial en la que se crearan los viajes</param>
        /// <param name="fechaFinal">Fecha de finalización del conjutno de viajes</param>
        /// <param name="diasSemana">Días de la semana en los que se realiza el viaje</param>
        /// <param name="idSalida">Identificador de salida correspondiente a los horarios de salida</param>
        /// <returns></returns>
        List<Viaje> crearViajes(DateTime fechaInicio, DateTime fechaFinal, List<Dias> diasSemana, int idSalida);


    }
}
