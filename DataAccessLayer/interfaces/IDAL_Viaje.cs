using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.interfaces
{
    public interface IDAL_Viaje
    {
        EViaje addViaje(bool finalizdo, DateTime Fecha, TimeSpan HoraInicioReal, int IdSalida);
        List<EViaje> getAllViajes();
        EViaje getViaje(int idViaje);


    }
}
