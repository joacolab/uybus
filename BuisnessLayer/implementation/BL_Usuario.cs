using BuisnessLayer.interfaces;
using DataAcessLayer.implementation;
using DataAcessLayer.interfaces;
using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.implementation
{
    public class BL_Usuario : IBL_Usuario
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
        private IDAL_Pasaje iPasaje;
        private IDAL_Parametro iParametro;

        public BL_Usuario()
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
            iPasaje = new DAL_Pasaje();
            iParametro = new DAL_Parametro();
        }

        public EPasaje comprarPasaje(int idViaje, int idUsuario, int idParadaOrigen, int idParadaDestino, string tipoDoc, string documento, int asiento)
        {

            EPasaje ep = new EPasaje();
            EUsuario eu = iUsuario.getUsuario(idUsuario);
            EPersona epe = iPersona.getPersona(idUsuario);

            //-------------------------------
            
            EViaje ev = iViaje.getViaje(idViaje);
            ESalida es = iSalida.getSalidas(ev.IdSalida);
            ELinea el = iLinea.getLinea(es.IdLinea);
            List<ETramo> tramos = el.Tramo.ToList<ETramo>();

            int posOrigen = -1;
            int posdestino = -1;
            foreach (var t in tramos)
            {
                if (t.IdLinea == el.IdLinea && t.IdParada == idParadaOrigen)
                {
                    posOrigen = tramos.IndexOf(t);
                }
                if (t.IdLinea == el.IdLinea && t.IdParada == idParadaDestino)
                {
                    posdestino = tramos.IndexOf(t);
                }
            }
            
            List<ETramo> subTramos = new List<ETramo>();
            
            for (int e = posOrigen; e <= posdestino; e++)
            {
                subTramos.Add(tramos.ElementAt(e));
            }
            
            int cosotP = 0;

            foreach (var s in subTramos)
            {
                cosotP = cosotP + iTramo.valorVigente(s.IdLinea, s.IdParada);
            }
            
            EParametro epara = iParametro.getAllParametros().Last();
            
            if (epara.Valor < cosotP) asiento = -1;
            
            if (idUsuario == -1) //Usuario NOO logeado
            {
                ep = iPasaje.addPasaje(asiento, documento, tipoDoc, idViaje, idParadaDestino, idParadaOrigen, idUsuario);
            }
            else //Usuario Logeado
            {
                string strTipoDoc;
                if (epe.TipoDocumento == 1) strTipoDoc = "CI";
                else strTipoDoc = "Credencial";

                ep = iPasaje.addPasaje(asiento, epe.Documento, strTipoDoc, idViaje, idParadaDestino, idParadaOrigen, idUsuario);
                
            }
            return ep;
           
        }

        public List<string> proximoVehiculo(int idUsuario, int idParada)
        {
            throw new NotImplementedException();
        }
    }
}
