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
        private IDAL_Llegada iLllegada;
        private IDAL_Viaje iViaje;
        private IDAL_Pasaje iPasaje;
        private IDAL_Linea iLinea;
        private IDAL_Salida iSalida;
        private IDAL_Tramo iTramo;

        public BL_Conductor(IDAL_Viaje _iViaje, IDAL_Pasaje _iPasaje, IDAL_Llegada _iLllegada, IDAL_Tramo _iTramo, IDAL_Salida _iSalida, IDAL_Linea _iLinea)
        {
            iViaje = _iViaje;
            iPasaje = _iPasaje;
            iLllegada = _iLllegada;
            iSalida = _iSalida;
            iLinea = _iLinea;
            iTramo = _iTramo;
        }

        public void iniciarViaje(int idViaje, TimeSpan horaInicioR)
        {

            iViaje.iniciarViaje(idViaje, horaInicioR);
            int idP = iLinea.getLinea(iSalida.getSalidas(iViaje.getViaje(idViaje).IdSalida).IdLinea).Tramo.ToList().First().IdParada;
            iLllegada.addLlegada(idP, idViaje, horaInicioR, iViaje.getViaje(idViaje).Fecha);
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
            //Console.WriteLine(idParada +" "+ ep.IdParadaOrigen);
            if (idParada== ep.IdParadaOrigen) return true;
            else return false; 

        }
    }
}
