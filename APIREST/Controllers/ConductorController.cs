using BuisnessLayer.implementation;
using BuisnessLayer.interfaces;
using DataAcessLayer.implementation;
using Share.DTOs;
using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace APIREST.Controllers
{
    [Authorize(Roles = "Conductor")]
    [RoutePrefix("conductor")]
    public class ConductorController : ApiController
    {

        IBL_Admin cAdmin = new BL_Admin(new DAL_Linea(), new DAL_Parada(), new DAL_Salida(),
        new DAL_Vehiculo(), new DAL_Conductor(), new DAL_Tramo(), new DAL_Precio(), new DAL_Viaje());

        IBL_Conductor iConductor = new BL_Conductor(new DAL_Viaje(), new DAL_Pasaje(), new DAL_Llegada(), new DAL_Tramo(), new DAL_Salida(), new DAL_Linea());
        IBL_General cGeneral = new BL_General(new DAL_Viaje(), new DAL_Llegada(), new DAL_Salida(), new DAL_Linea(), new DAL_Tramo(), new DAL_Parada(), new DAL_Pasaje(), new DAL_Usuario(), new DAL_Vehiculo(), new DAL_Persona(), new DAL_Admin(), new DAL_Conductor(), new DAL_SuperAdmin());


        //-------------notificacion de profimidad---------
        //List<EUsuario> notificacionProximidad(int Parada, int viaje)
        
        //https://localhost:44330/conductor/notifProximi/2/3
        //funciona
        [HttpGet]
        [Route("notifProximi/{idParada}/{idviaje}")]
        [ResponseType(typeof(List<EUsuario>))]
        public IHttpActionResult notifProximi(int idParada, int idviaje)
        {
            try
            {
                return Ok(cGeneral.notificacionProximidad(idParada, idviaje));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        
        //-------------comienzo de viaje------------------

        //https://localhost:44330/conductor/traer/viajes
        //funciona
        [HttpGet]
        [Route("traer/viajes")]
        [ResponseType(typeof(List<EViaje>))]
        public IHttpActionResult GetAllViajes()
        {
            return Ok(cAdmin.getAllViaje());
        }

        //https://localhost:44330/conductor/iniciar-viaje/3
        //funciona
        /*
            "08:01:00"
        
        */
        [HttpPut]
        [Route("iniciar-viaje/{IdViaje}")]
        public IHttpActionResult editarViaje(int IdViaje, [FromBody] string HoraInicioReal)
        {
            try
            {
                iConductor.iniciarViaje(IdViaje, TimeSpan.Parse(HoraInicioReal));
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        //-----------------------------verificar paaje---------------

        //https://localhost:44330/conductor/traer/paradas
        //funciona
        [HttpGet]
        [Route("traer/paradas")]
        [ResponseType(typeof(List<EParada>))]
        public IHttpActionResult GetAllParada()
        {
            return Ok(cAdmin.getAllParada());
        }

        //https://localhost:44330/conductor/verifiacer-pasaje/1/1
        //funciona
        [HttpGet]
        [Route("verifiacer-pasaje/{idPasaje}/{idParada}")]
        [ResponseType(typeof(bool))]
        public IHttpActionResult verificarPasaje(int idPasaje, int idParada)
        {
            try
            {
                return Ok(iConductor.verificarPasaje(idPasaje, idParada));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

    }
}
