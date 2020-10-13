using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.interfaces
{
    public interface IDAL_Pasaje
    {
        EPasaje addPasaje(int asiento, string documento, string tipoDocumento, int viaje, int paradaDestino, int paradaOrigen, int idUsuario);
        List<EPasaje> getAllPasajes();
        EPasaje getPasajes(int idPasaje);
    }
}
