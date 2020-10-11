using BuisnessLayer.interfaces;
using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.implementation
{
    public class BL_Usuario : IBL_Usuario
    {
        public EPasaje comprarPasaje(int idViaje, int idUsuario, int idParadaOrigen, int idParadaDestino, DateTime fechaViaje, string tipoDoc, string documento, int idParametro, int asiento)
        {
            throw new NotImplementedException();
        }

        public List<string> proximoVehiculo(int idUsuario, int idParada)
        {
            throw new NotImplementedException();
        }
    }
}
