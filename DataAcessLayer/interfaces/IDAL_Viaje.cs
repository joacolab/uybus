using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.interfaces
{
    public interface IDAL_Viaje
    {
        EViaje addViaje(bool finalizdo, DateTime Fecha, int IdSalida);
        List<EViaje> getAllViajes();
        EViaje getViaje(int idViaje);
        EViaje iniciarViaje(int idViaje, TimeSpan HoraInicioReal);
        void finalizarViaje(int idViaje);

        EViaje editViaje(int idViaje, bool finalizdo, DateTime Fecha, TimeSpan? HoraInicioReal, int IdSalida);
    }
}