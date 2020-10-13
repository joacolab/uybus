using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.interfaces
{
    public interface IDAL_Precio
    {
        EPrecio addPrecio(int precio, DateTime fechaEntrVig, int idLinea, int idParada);
        List<EPrecio> getAllPrecios();
        EPrecio getPrecios(int idLinea, int idParada);
    }
}
