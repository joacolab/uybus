using DataAccessLayer.interfaces;
using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.implementation
{
    public class DAL_Precio : IDAL_Precio
    {
        public EPrecio addPrecio(int precio, DateTime fechaEntrVig, int idLinea, int idParada)
        {
            throw new NotImplementedException();
        }

        public List<EPrecio> getAllPrecios()
        {
            throw new NotImplementedException();
        }

        public EPrecio getPrecios(int idLinea, int idParada)
        {
            throw new NotImplementedException();
        }
    }
}
