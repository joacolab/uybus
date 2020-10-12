using DataAccessLayer.interfaces;
using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.implementation
{
    public class DAL_Tramo : IDAL_Tramo
    {
        public ETramo addTramo(int tiempoEstimado, int idLinea, int idParada)
        {
            throw new NotImplementedException();
        }

        public List<ETramo> getAllTramos()
        {
            throw new NotImplementedException();
        }

        public EPrecio getPrecioVigente(int idLinea, int idParada)
        {
            throw new NotImplementedException();
        }

        public ETramo getTramos(int idLinea, int idParada)
        {
            throw new NotImplementedException();
        }
    }
}
