using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.interfaces
{
    public interface IDAL_Conductor
    {
        EConductor addConductor(int idPersona, DateTime FechaVenc, List<ESalida> salidas);
        List<EConductor> getAllConductores();
        EConductor getConductores(int idConductor);

        void addSalidas(int idConductor, List<ESalida> salidas);

        List<ESalida> getSalidas(int idConductor);

        EConductor addFechaVencLib(int idConductor, DateTime FechaVenc);
    }
}
