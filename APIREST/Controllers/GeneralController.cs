using BuisnessLayer.implementation;
using BuisnessLayer.interfaces;
using DataAcessLayer.implementation;
using Share.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace APIREST.Controllers
{
    [RoutePrefix("general")]
    public class GeneralController : ApiController
    {
        IBL_General cGeneral = new BL_General(new DAL_Viaje(), new DAL_Llegada(), new DAL_Salida(), new DAL_Linea(), new DAL_Tramo(), new DAL_Parada(), new DAL_Pasaje(), new DAL_Usuario(), new DAL_Vehiculo(), new DAL_Persona(), new DAL_Admin(), new DAL_Conductor(), new DAL_SuperAdmin());

        //----------------------------------Viajes----------------------------------------
        // https://localhost:44330/general/login
        //funciona
        /*
            {
                "email" : "ConductorGuille@gmail.com",
                "password" :"1234",
                "rol" : "Conductor"
            }
        */
        [HttpPost]
        [Route("login")]
        [ResponseType(typeof(bool))]
        public IHttpActionResult iniciarSesion([FromBody] DTOLogin log)
        {
            try
            {
                if (log == null)
                {
                    return Content(HttpStatusCode.BadRequest, "No.");
                }

                bool res = cGeneral.iniciarSesion(log.email, log.password, log.rol);

                return Ok(res);

            }
            catch (Exception)
            {
                return NotFound();
            }
        }

    }

}
