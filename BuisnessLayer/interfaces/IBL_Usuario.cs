using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.interfaces
{
    public interface IBL_Usuario
    {
        void comprarPasaje(int idViaje, int idUsuario, int idParadaOrigen, int idParadaDestino, System.DateTime fechaViaje, string tipoDoc, string documento, int idParametro, int asiento);
        void proximoVehiculo(int idUsuario, int idParada);
    }
}
