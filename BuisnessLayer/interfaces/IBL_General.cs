using Share.DTOs;
using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.interfaces
{
    public interface IBL_General
    {
        List<string> rolesPorEmail(string correo);
        bool correoUnico(string email);
        EPersona iniciarSesion(string email, string password, string rol);
        void finalizarViaje(int idViaje);


        /// <summary>
        ///Si solo me pasan fechas retorno los pasajes de los viajes de esas fechas(No me deben pasar el id del viaje), 
        ///Si me pasan viaje retorno los pasajes del viaje (No me deben pasar fechas),
        ///Si me pasan salida retorno los pasajes de los viajes de la salida(No me deben pasar el id del viaje);
        ///si me pasan linea retorno los pasajes de los viajes de las salidas de la linea(No me deben pasar el id del viaje)
        ///     
        /// </summary>
        /// <param name="fechaDesde">(1900,01,01) si no es por fecha</param>
        /// <param name="fechaHasat">(1900,01,01) si no es por fecha</param>
        /// <param name="linea"> -1 si no es por linea</param>
        /// <param name="salida"> -1 si no es por salida</param>
        /// <param name="viaje"> -1 si no es por viaje</param>
        /// <returns></returns>
        List<EPasaje> reposrtesPasajes(DateTime fechaDesde, DateTime fechaHasat, int linea, int salida,int viaje);

        DTOnextBus CrearLlegada(int idViaje, TimeSpan hora, DateTime fecha);
        List<EUsuario> notificacionProximidad(int Parada, int viaje);
        /// <summary>
        /// debuelbe 1, si el viaje con ese "idViaje", tiene todos los asientos del vehiculo ocupados, desde el origen hasta el final.
        /// </summary>
        /// <param name="idViaje"></param>
        /// <returns>porcentaje de utilidad</returns>
        float reporteUtilidad(int idViaje, DateTime fechaDesde, DateTime fechaHasat, int linea, int salida);
    }
}
