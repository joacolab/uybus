﻿using Share.DTOs;
using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.interfaces
{
    public interface IBL_Usuario
    {
        List<ELinea> listarLineas();
        EPasaje comprarPasaje(int idViaje, int idUsuario, int idParadaOrigen, int idParadaDestino, string tipoDoc, string documento, int asiento);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="idParada"></param>
        /// <returns>Matriculas de proximos vehiculos</returns>
        List<DTOproxVehiculo> proximoVehiculo(int idUsuario, int idParada);
    }
}
