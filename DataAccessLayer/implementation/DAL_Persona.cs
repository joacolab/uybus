using DataAccessLayer.interfaces;
using Share.entities;
using Share.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.implementation
{
    public class DAL_Persona : IDAL_Persona
    {
        public EPersona addPersona(string Documento, string Correo, string Password, int TipoDocumento, string pNombre, string sNombre, string pApellido, string sApellido)
        {
            throw new NotImplementedException();
        }

        public EPersona getPersona(int id)
        {
            throw new NotImplementedException();
        }

        public List<Rol> getRol(int id)
        {
            throw new NotImplementedException();
        }
    }
}
