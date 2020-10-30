using Share.DTOs;
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
        ETramo addTramo(int tiempoEstimado, int idLinea, int idParada, int orden);
        List<ETramo> getAllTramos();
        ETramo getTramos(int idLinea, int idParada);
        ETramo editarTramo(int IdLinea, int IdParada, DTOTramo tramo);
        int valorVigente(int idLinea, int idParada);
    }
}
