using DataAccessLayer.conversores;
using DataAccessLayer.interfaces;
using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.implementation
{
    public class DAL_Salida : IDAL_Salida
    {
        public ESalida addSalida(string matricula, int linea, TimeSpan horaInicio, int idConductor)
        {
            throw new NotImplementedException();
        }

        public List<ESalida> getAllSalidas()
        {
            throw new NotImplementedException();
        }

        public ESalida getSalidas(int idSalida)
        {
            throw new NotImplementedException();
        }
    }
}
