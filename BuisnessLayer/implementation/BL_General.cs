using BuisnessLayer.interfaces;
using DataAcessLayer;
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
    public class BL_General : IBL_General
    {
        private IDAL_Viaje iViaje;
        private IDAL_Llegada iLllegada;
        private IDAL_Salida iSalida;
        private IDAL_Linea iLinea;
        private IDAL_Tramo iTramo;
        private IDAL_Parada iParada;

        public BL_General(IDAL_Viaje _iViaje, IDAL_Llegada _iLllegada, IDAL_Salida _iSalida,IDAL_Linea _iLinea, IDAL_Tramo _iTramo,IDAL_Parada _iParada)
        {
            iViaje = _iViaje;
            iLllegada = _iLllegada;
            iSalida = _iSalida;
            iLinea = _iLinea;
            iTramo = _iTramo;
            iParada = _iParada;
        }

        public ELlegada CrearLlegada(int idParada, int idViaje, TimeSpan hora)
        {
            return iLllegada.addLlegada(idParada, idViaje, hora);
            
        }

        public void finalizarViaje(int idViaje)
        {
            iViaje.finalizarViaje(idViaje);
        }

        public List<EUsuario> notificacionProximidad(int Parada, int viaje)
        {

            List<EUsuario> usuarios = new List<EUsuario>();
            int idL = iSalida.getSalidas(iViaje.getViaje(viaje).IdSalida).IdLinea;

             ETramo tramo = iTramo.getTramos(idL ,Parada);

            List<ETramo> etramos = iLinea.getLinea(idL).Tramo.ToList();
            EParada proximaParada = null;
            
            foreach (var item in etramos)
            {
               
                if (item.Orden == tramo.Orden +1) {
                    proximaParada = iParada.getParada(item.IdParada);
                    break;
                }

               
            }
            if (proximaParada == null) throw new Exception("Parada no encontrada");

            foreach (var item in proximaParada.Pasaje1.ToList())
            {
                if(item.Usuario != null)   usuarios.Add(item.Usuario);
            }


            return usuarios;
        }

        public float reporteUtilidad(int idViaje, DateTime fechaDesde, DateTime fechaHasat, int linea, int salida)
        {
            throw new NotImplementedException();
        }

        public List<EPasaje> reposrtesPasajes(DateTime fechaDesde, DateTime fechaHasat, int linea, int salida)
        {
            throw new NotImplementedException();
        }
    }
}
