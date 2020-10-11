using DataAccessLayer.interfaces;
using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.implementation
{
    public class DAL_Conductor : IDAL_Conductor
    {
        public EConductor addConductor(int idPersona, DateTime FechaVenc)
        {
            throw new NotImplementedException();
        }

        public void addFechaVencLib(int idConductor, DateTime FechaVenc)
        {
            throw new NotImplementedException();
        }

        public List<EConductor> getAllConductores()
        {
            throw new NotImplementedException();
        }

        public EConductor getConductores(int idConductor)
        {
            throw new NotImplementedException();
        }
    }
}
