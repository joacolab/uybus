using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.interfaces
{
    public interface IBL_Conductor
    {
        bool verificarPasaje(int idPasaje, int idParada);

        /// <summary>
        /// Se setea la "horaInicioR" a una instancia Viaje cuyo id es "idViaje"
        /// </summary>
        /// <param name="idViaje"></param>
        /// <param name="horaInicioR"></param>
        void iniciarViaje(int idViaje, TimeSpan horaInicioR);
    }
}
