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
        private IDAL_Linea iLinea;
        private IDAL_Salida iSalida;
        private IDAL_Tramo iTramo;
        private IDAL_Viaje iViaje;
        private IDAL_Pasaje iPasaje;
        private IDAL_Parametro iParametro;

        public BL_Usuario(IDAL_Persona _iPersona, IDAL_Usuario _iUsuario, IDAL_Linea _iLinea, IDAL_Salida _iSalida, IDAL_Tramo _iTramo, IDAL_Viaje _iViaje, IDAL_Pasaje _iPasaje, IDAL_Parametro _iParametro)
        {
            iPersona = _iPersona;
            iUsuario = _iUsuario;
            iLinea = _iLinea;
            iSalida = _iSalida;
            iTramo = _iTramo;
            iViaje = _iViaje;
            iPasaje = _iPasaje;
            iParametro = _iParametro;
        }
        /// <summary>
        ///  
        /// </summary>
        /// <param name="idViaje"></param>
        /// <param name="idUsuario"> -1 si el usuario no esta logeado. </param>
        /// <param name="idParadaOrigen"></param>
        /// <param name="idParadaDestino"></param>
        /// <param name="tipoDoc"> "vacio" si el usaurio esta logeado.</param>
        /// <param name="documento"> "vacio" si el usaurio esta  logeado.</param>
        /// <param name="asiento"> Se gurdara -1 si, el costo de pasaje es inferior al parámetro.</param>
        /// <returns></returns>
        public EPasaje comprarPasaje(int idViaje, int idUsuario, int idParadaOrigen, int idParadaDestino, string tipoDoc, string documento, int asiento)
        {

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
            
            if (epara.Valor > cosotP) asiento = -1;
            Console.WriteLine(cosotP);
            EPasaje ep = new EPasaje();
            if (idUsuario == -1) //Usuario NOO logeado
            {

              
                ep = iPasaje.addPasaje(asiento, documento, tipoDoc, idViaje, idParadaDestino, idParadaOrigen, idUsuario);
            }
            else //Usuario Logeado
            {
                EPersona epe = iPersona.getPersona(idUsuario);
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
