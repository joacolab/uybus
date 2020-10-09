using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.interfaces
{
    public interface IBL_Invitado
    {
        void registrarse(string Documento, string Correo, string Password, string TipoDocumento,string Nombre);
    }
}
