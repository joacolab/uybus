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
    public class DAL_Viaje : IDAL_Viaje
    {
        public EViaje addViaje(bool finalizdo, DateTime Fecha, TimeSpan HoraInicioReal, int IdSalida)
        {
            throw new NotImplementedException();
        }

        public List<EViaje> getAllViajes()
        {
            throw new NotImplementedException();
        }

        public EViaje getViaje(int idViaje)
        {
            throw new NotImplementedException();
        }
    }
}
