using DataAccessLayer.interfaces;
using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.implementation
{
    public class DAL_Linea : IDAL_Linea
    {
        public ELinea addLinea(string nombre, List<ESalida> salidas, List<ETramo> tramos)
        {
            throw new NotImplementedException();
        }

        public void addSalidas(List<ESalida> salidas)
        {
            throw new NotImplementedException();
        }

        public void addTramos(List<ETramo> addTramos)
        {
            throw new NotImplementedException();
        }

        public List<ELinea> getAllLineas()
        {
            throw new NotImplementedException();
        }

        public ELinea getLineas(int idLinea)
        {
            throw new NotImplementedException();
        }
    }
}
