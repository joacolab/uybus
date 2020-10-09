using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.interfaces
{
    public interface IBL_Conductor
    {
        bool verificarPasaje(int codigoQR, int idParada);
        void iniciarViaje(int idViaje, int idSalida);
    }
}
