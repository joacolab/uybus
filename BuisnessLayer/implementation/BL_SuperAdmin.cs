using BuisnessLayer.interfaces;
using DataAcessLayer.implementation;
using DataAcessLayer.interfaces;
using Share.DTOs;
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
        private IDAL_Llegada iLlegada;
        private IDAL_Linea iLinea;
        private IDAL_Parada iParada;
        private IDAL_Salida iSalida;
        private IDAL_Vehiculo iVehiculo;
        private IDAL_Tramo iTramo;
        private IDAL_Precio iPrecio;
        private IDAL_Viaje iViaje;

        public BL_SuperAdmin()
        {
            iPersona = new DAL_Persona();
            iUsuario = new DAL_Usuario();
            iAdmin = new DAL_Admin();
            iConductor = new DAL_Conductor();
            iLlegada = new DAL_Llegada();
            iLinea = new DAL_Linea();
            iParada = new DAL_Parada();
            iSalida = new DAL_Salida();
            iVehiculo = new DAL_Vehiculo();
            iTramo = new DAL_Tramo();
            iPrecio = new DAL_Precio();
            iViaje = new DAL_Viaje();
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

        public List<DTOubicacion> ubicarVehiculo()
        {
            List<DTOubicacion> lstDto = new List<DTOubicacion>();
            List<ELlegada> lstLL = iLlegada.getAllLlegadas();

            foreach (var l in lstLL)
            {
                /*
                EViaje evi = iViaje.getViaje(l.idViaje);
                ESalida esa = iSalida.getSalidas(evi.IdSalida);
                EVehiculo eve = iVehiculo.getVehiculos(esa.IdVehiculo);
                string mat = eve.Matricula;
                */
                DTOubicacion dtou = new DTOubicacion();

                dtou.matricula = iVehiculo.getVehiculos(iSalida.getSalidas(iViaje.getViaje(l.idViaje).IdSalida).IdVehiculo).Matricula;
                dtou.lat = iParada.getParada(l.idParada).Lat;
                dtou.lon = iParada.getParada(l.idParada).Long;
                dtou.hora = l.hora;
                lstDto.Add(dtou);
            }
            return lstDto;
        }
    }
}
