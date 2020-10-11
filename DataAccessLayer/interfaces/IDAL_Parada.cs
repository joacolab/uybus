using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.interfaces
{
    public interface IDAL_Parada
    {
        EParada addParada(int idParada, List<EPasaje> pasajesDestino, List<EPasaje> pasajesOrigen, List<ETramo> tramos, string nombre, float lat, float lon);
        List<EParada> getAllParadas();
        EParada getParada(int parada);

        void addTramo(int idParada, List<ETramo> tramos);
        void addPasajeDestino(int idParada, List<EPasaje> pasajesDestino);
        void addPasajeOrigen(int idParada, List<EPasaje> pasajesOrigen);
    }
}
