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
        ELinea addLinea(string nombre);
        List<ELinea> getAllLineas();
        ELinea getLineas(int idLinea);


    }
}
