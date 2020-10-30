using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.interfaces
{
    public interface IDAL_Linea
    {
        ELinea addLinea(string nombre);
        List<ELinea> getAllLineas();
        ELinea getLinea(int idLinea);
        ELinea editLinea(int IdLinea, string nombre);
    }
}