using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.interfaces
{
    public interface IDAL_Linea
    {
        ELinea addLinea(string nombre, List<ESalida> salidas, List<ETramo> tramos);
        List<ELinea> getAllLineas();
        ELinea getLineas(int idLinea);

        void addSalidas(List<ESalida> salidas);
        void addTramos(List<ETramo> addTramos);
    }
}
