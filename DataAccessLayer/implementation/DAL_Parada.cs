using DataAccessLayer.interfaces;
using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.implementation
{
    public class DAL_Parada : IDAL_Parada
    {
        public EParada addParada(int idParada, string nombre, float lat, float lon)
        {
            throw new NotImplementedException();
        }

        public List<EParada> getAllParadas()
        {
            throw new NotImplementedException();
        }

        public EParada getParada(int parada)
        {
            throw new NotImplementedException();
        }
    }
}
