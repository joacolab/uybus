using DataAccessLayer.interfaces;
using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.implementation
{
    public class DAL_Pasaje : IDAL_Pasaje
    {
        public EPasaje addPasaje(int asiento, string documento, string tipoDocumento, int viaje, int paradaDestino, int paradaOrigen, int idUsuario)
        {
            throw new NotImplementedException();
        }

        public List<EPasaje> getAllPasajes()
        {
            throw new NotImplementedException();
        }

        public EPasaje getPasajes(int idPasaje)
        {
            throw new NotImplementedException();
        }
    }
}
