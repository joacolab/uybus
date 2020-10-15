using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.interfaces
{
    public interface IDAL_Tramo
    {
        ETramo addTramo(int tiempoEstimado, int idLinea, int idParada);
        List<ETramo> getAllTramos();
        ETramo getTramos(int idLinea, int idParada);

        int valorVigente(int idLinea, int idParada);
    }
}
