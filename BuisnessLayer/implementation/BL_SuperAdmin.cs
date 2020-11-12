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
        private IDAL_Parada iParada;
        private IDAL_Salida iSalida;
        private IDAL_Vehiculo iVehiculo;
        private IDAL_Viaje iViaje;

        public BL_SuperAdmin(IDAL_Persona _iPersona, IDAL_Usuario _iUsuario, IDAL_Admin _iAdmin, IDAL_Conductor _iConductor, IDAL_Llegada _iLlegada, IDAL_Parada _iParada, IDAL_Salida _iSalida, IDAL_Vehiculo _iVehiculo, IDAL_Viaje _iViaje)
        {
            iPersona = _iPersona;
            iUsuario = _iUsuario;
            iAdmin = _iAdmin;
            iConductor = _iConductor;
            iLlegada = _iLlegada;
            iParada = _iParada;
            iSalida = _iSalida;
            iVehiculo = _iVehiculo;
            iViaje = _iViaje;
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

        public List<EPersona> GetAllPersonas()
        {
            return iPersona.getAllPersona();
        }

        public DTOubicacion ultimaFechaYHora(string matricula, List<DTOubicacion> lstdto)
        {
            List<DTOubicacion> ve = new List<DTOubicacion>();
            foreach (var item in lstdto)
            {
                if (item.matricula == matricula)
                {
                    ve.Add(item);
                }
            }
            DTOubicacion ultimaFecha = ve.OrderByDescending(x => x.fecha).FirstOrDefault();


            List<DTOubicacion> vev = new List<DTOubicacion>();
            foreach (var item in lstdto)
            {
                if (item.matricula == ultimaFecha.matricula && item.fecha == ultimaFecha.fecha)
                {
                    vev.Add(item);
                }
            }

            DTOubicacion ultimaHora = vev.OrderByDescending(x => x.hora).FirstOrDefault();

            return ultimaHora;
        }
        public List<DTOubicacion> ubicarVehiculo()
        {
            List<DTOubicacion> lstDto = new List<DTOubicacion>();

            List<ELlegada> lstLL = iLlegada.getAllLlegadas();

            foreach (var l in lstLL)
            {
                DTOubicacion dtou = new DTOubicacion();

                dtou.matricula = iVehiculo.getVehiculos(iSalida.getSalidas(iViaje.getViaje(l.idViaje).IdSalida).IdVehiculo).Matricula;
                dtou.lat = iParada.getParada(l.idParada).Lat;
                dtou.lon = iParada.getParada(l.idParada).Long;
                dtou.hora = l.hora;
                dtou.fecha = l.fecha;
                lstDto.Add(dtou);
            }

            List<string> matriculas = new List<string>();
            foreach (var dtoo in lstDto)
            {
                matriculas.Add(dtoo.matricula);
            }
            List<string> matriculasUncas = matriculas.Distinct().ToList();

            List<DTOubicacion> lstdtoFinal = new List<DTOubicacion>();
            foreach (var matU in matriculasUncas)
            {
                DTOubicacion ultimaFechaYHoras = ultimaFechaYHora(matU, lstDto);
                lstdtoFinal.Add(ultimaFechaYHoras);
            }

            return lstdtoFinal;
        }
    }
}
