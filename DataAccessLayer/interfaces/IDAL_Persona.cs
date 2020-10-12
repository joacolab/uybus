using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Share.entities;
using Share.enums;

namespace DataAccessLayer.interfaces
{
    public interface IDAL_Persona
    {
        List<Rol> getRol(int id);
        EPersona getPersona(int id);
        EPersona addPersona(string Documento, string Correo, string Password, int TipoDocumento, string pNombre, string sNombre, string pApellido, string sApellido);

    }
}