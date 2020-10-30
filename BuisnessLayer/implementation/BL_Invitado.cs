using BuisnessLayer.interfaces;
using DataAcessLayer.implementation;
using DataAcessLayer.interfaces;
using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.implementation
{
    public class BL_Invitado : IBL_Invitado
    {
        private IDAL_Usuario iUsuario;
        private IDAL_Persona iPersona;

        public BL_Invitado(IDAL_Persona _iPersona, IDAL_Usuario _iUsuario)
        {
            iUsuario = _iUsuario;
            iPersona = _iPersona;
        }
        public EUsuario registrarse(string Documento, string Correo, string Password, int TipoDocumento, string pNombre, string sNombre, string pApellido, string sApellido)
        {
            EPersona ep = iPersona.addPersona(Documento, Correo, Password, TipoDocumento, pNombre, sNombre, pApellido, sApellido);
            if (ep == null)
            {
                return null;
            }
            EUsuario eu = iUsuario.addUsuario(ep.id);
            return eu;
        }
    }
}
