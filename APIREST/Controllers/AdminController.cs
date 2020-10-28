﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BuisnessLayer.implementation;
using BuisnessLayer.interfaces;
using DataAcessLayer.implementation;
using Share.entities;
using Share.enums;
using Share.DTOs;

namespace APIREST.Controllers
{
    [RoutePrefix("admin")]
    public class AdminController : ApiController
    {
        IBL_Admin cAdmin = new BL_Admin(new DAL_Linea(), new DAL_Parada(), new DAL_Salida(), 
        new DAL_Vehiculo(), new DAL_Conductor(), new DAL_Tramo(), new DAL_Precio(), new DAL_Viaje());

        [HttpPost]
        [Route("crear/viajes")]
        public List<EViaje> crearViajes(DateTime fechaInicio, DateTime fechaFinal, List<Dias> diasSemana, int idSalida)
        {
            List<EViaje> viajes = cAdmin.crearViajes(fechaInicio, fechaFinal, diasSemana, idSalida);
            return viajes;
        }


        [HttpPost]
        [Route("crear/vehiculo")]
        [ResponseType(typeof(EVehiculo))]
        public EVehiculo crearVehiculos(string Marca, string Modelo, string Matricula, int cantAsientos)
        {
            
            try
            {
                EVehiculo ev = cAdmin.crearVehiculos(Marca, Modelo, Matricula, cantAsientos);
                return ev;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        
        [HttpGet]
        [Route("GetAll/Vehiculos")]
        List<EVehiculo> GetAllVehiculos()
        {
            return cAdmin.getAllVehiculos();
        }

        [HttpPut]
        [Route("editar/vehiculo")]
        EVehiculo editarVehiculos(string Marca, string Modelo, string Matricula, int cantAsientos)
        {
            return cAdmin.editarVehiculos(Marca, Modelo, Matricula, cantAsientos);
        }

        //funciona
        [HttpPost]
        [Route("crear/parada")]
        [ResponseType(typeof(EParada))]
        public IHttpActionResult crearParada([FromBody] DTOParada parada)
        {
            try
            {
                if(parada != null )
                {
                    double longitud;
                    double latitud;
                    
                    if (String.IsNullOrEmpty(parada.Nombre))
                    {
                        return Content(HttpStatusCode.NotFound, "El nombre no es correcto");
                    } 
                    // Si no puede convertir la latitude responde un 404
                    if(!Double.TryParse(parada.Lat, out latitud))
                    {
                        return Content(HttpStatusCode.NotFound, "La latitude no tiene el formato correcto");
                    }
                    // Si no puede convertir la longitud responde un 404
                    if(!Double.TryParse(parada.Long, out longitud))
                    {
                        return Content(HttpStatusCode.NotFound, "La longitud no tiene el formato correcto");
                    }
                    EParada nuevaParada = cAdmin.crearParada(parada.Nombre, latitud, longitud);
                    if(nuevaParada == null)
                    {
                        return Content(HttpStatusCode.BadRequest, "Ya existe una parada con ese nombre");
                    }
                    return Ok(nuevaParada);
                }
                return Content(HttpStatusCode.BadRequest, "No se creó la nueva parada");
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        //funciona
        [HttpPost]
        [Route("crear/linea")]
        [ResponseType(typeof(ELinea))]
        public  IHttpActionResult crearLinea([FromBody]ELinea linea)
        {
            try
            {
                if(String.IsNullOrEmpty(linea.Nombre))
                {
                    return Content(HttpStatusCode.BadRequest, "No se creó la nueva Línea, el nombre no es válido");
                }
                else
                {
                    ELinea nuevaLinea = cAdmin.crearLinea(linea.Nombre);
                    if(nuevaLinea != null)
                    {
                        return Ok(nuevaLinea);
                    }
                    return Content(HttpStatusCode.NotFound , "El Nombre ya existe");
                }                
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("crear/tramo")]
        [ResponseType(typeof(ETramo))]
        public IHttpActionResult crearTramos([FromBody] DTOTramoPrecio dtoTramoPrecio)
        {
            ETramo etramo = cAdmin.crearTramos(dtoTramoPrecio.IdParada , dtoTramoPrecio.IdLinea, dtoTramoPrecio.Orden , dtoTramoPrecio.TiempoEstimado, dtoTramoPrecio.Precio , dtoTramoPrecio.FechaEntradaVigencia); 
            if(etramo != null)
            {
                return Ok(etramo);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, "No se créo el tramo");
            }
        }

        [HttpPut]
        [Route("editar/conductor")]
        void gestionConductores(int idUsuario, DateTime venLibreta)
        {
            cAdmin.gestionConductores(idUsuario, venLibreta);
        }

        [HttpPost]
        [Route("crear/salida")]
        ESalida crearSalida(int idConductor, string Matricula, int idLinea, TimeSpan horaInicio)
        {
            return crearSalida(idConductor, Matricula, idLinea, horaInicio);
        }

    }
}
