using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.interfaces
{
    public interface IBL_General
    {
        void finalizarViaje(int idViaje);
        List<Pasaje> reposrtesPasajes(DateTime fechaDesde, DateTime fechaHasat, int linea, int horario);
        void notificacionProximidad();
        /// <summary>
        /// debuelbe 1, si el viaje con ese "idViaje", tiene todos los asientos del vehiculo ocupados, desde el origen hasta el final.
        /// </summary>
        /// <param name="idViaje"></param>
        /// <returns>porcentaje de utilidad</returns>
        float reporteUtilidad(int idViaje, DateTime fechaDesde, DateTime fechaHasat, int linea, int salida);
    }
}
