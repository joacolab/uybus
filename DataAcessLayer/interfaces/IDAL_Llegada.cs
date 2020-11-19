using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.interfaces
{
    public interface IDAL_Llegada
    {
        ELlegada addLlegada(int idParada, int idViaje, TimeSpan hora, DateTime fecha);
        List<ELlegada> getAllLlegadas();
        ELlegada getLlegada(int idParada, int idViaje);
    }
}
