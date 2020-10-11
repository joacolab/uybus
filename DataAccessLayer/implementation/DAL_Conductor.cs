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
        public EConductor addConductor(int idPersona)
        {
            throw new NotImplementedException();
        }

        public EConductor addConductor(int idPersona, DateTime FechaVenc, List<ESalida> salidas)
        {
            throw new NotImplementedException();
        }

        public EConductor addFechaVencLib(int idConductor, DateTime FechaVenc)
        {
            throw new NotImplementedException();
        }

        public void addSalidas(int idConductor, List<ESalida> salidas)
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

        public List<ESalida> getSalidas(int idConductor)
        {
            throw new NotImplementedException();
        }
    }
}
