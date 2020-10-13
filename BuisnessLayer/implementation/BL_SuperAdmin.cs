using BuisnessLayer.interfaces;
using DataAcessLayer.implementation;
using DataAcessLayer.interfaces;
using Share.entities;
using Share.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.implementation
{
    public class BL_SuperAdmin : IBL_SuperAdmin
    {
        private IDAL_Persona iPersona;
        private IDAL_Usuario iUsuario;
        private IDAL_Admin iAdmin;
        private IDAL_Conductor iConductor;

        public BL_SuperAdmin()
        {
            iPersona = new DAL_Persona();
            iUsuario = new DAL_Usuario();
            iAdmin = new DAL_Admin();
            iConductor = new DAL_Conductor();
        }
        public EPersona asignarRol(int id, Rol rol)
        {
            EPersona ep = iPersona.getPersona(id);
            if (rol == Rol.Admin)
            {
                iAdmin.addAdmin(ep.id);
                return ep;
            }
            if (rol == Rol.Conductor)
            {
                iConductor.addConductor(ep.id, new DateTime(1900,10,10)); // 10/10/1900 significa NULL
                return ep;
            }
            if (rol == Rol.Usuario)
            {
                iUsuario.addUsuario(ep.id);
                return ep;
            }
            return ep;
        }

        public void ubicarVehiculo()
        {
            throw new NotImplementedException();
        }
    }
}
