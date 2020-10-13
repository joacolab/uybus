using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.interfaces
{
    public interface IBL_Invitado
    {
        EUsuario registrarse(string Documento, string Correo, string Password, int TipoDocumento, string pNombre, string sNombre, string pApellido, string sApellido);
    }
}
