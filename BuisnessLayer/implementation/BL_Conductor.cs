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
    public class BL_Conductor : IBL_Conductor
    {
        private IDAL_Viaje iViaje;
        private IDAL_Pasaje iPasaje;

        public BL_Conductor(IDAL_Viaje _iViaje, IDAL_Pasaje _iPasaje)
        {
            iViaje = _iViaje;
            iPasaje = _iPasaje;
        }
        public void iniciarViaje(int idViaje, TimeSpan horaInicioR)
        {
            iViaje.iniciarViaje(idViaje, horaInicioR);
        }

        /// <summary>
        /// retorna true, si el id de la parada_Destino del pasaje con "idPasaje", coinside con "idParada"
        /// </summary>
        /// <param name="idPasaje"></param>
        /// <param name="idParada"></param>
        /// <returns></returns>
        public bool verificarPasaje(int idPasaje, int idParada)
        {
            EPasaje ep = iPasaje.getPasajes(idPasaje);
            Console.WriteLine(idParada +" "+ ep.IdParadaOrigen);
            if (idParada== ep.IdParadaOrigen) return true;
            else return false;

            //EParada epDestino = iParada.getParada(ep.IdParadaDestino);
            //EParada epOrigen = iParada.getParada(ep.IdParadaOrigen);

            /*
            EViaje ev = iViaje.getViaje(ep.IdViaje);
            ESalida es = iSalida.getSalidas(ev.IdSalida);
            ELinea el = iLinea.getLinea(es.IdLinea);

            List<ETramo> tramos = el.Tramo.ToList<ETramo>(); //tramo es un ICollection<Etramo>

            List<EParada> lstEp = new List<EParada>();
            foreach (var t in tramos)
            {
                EParada epar = iParada.getParada(t.IdParada);
                lstEp.Add(epar);
            }
            if (lstEp.Contains(epDestino) && lstEp.Contains(epOrigen)) return true;
            else return false;
            */

        }
    }
}
