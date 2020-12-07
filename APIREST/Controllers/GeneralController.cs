using APIREST.Token;
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
    [RoutePrefix("general")]
    public class GeneralController : ApiController
    {
        IBL_General cGeneral = new BL_General(new DAL_Viaje(), new DAL_Llegada(), new DAL_Salida(), new DAL_Linea(), new DAL_Tramo(), new DAL_Parada(), new DAL_Pasaje(), new DAL_Usuario(), new DAL_Vehiculo(), new DAL_Persona(), new DAL_Admin(), new DAL_Conductor(), new DAL_SuperAdmin());

        //-------------llegada---------------------------
        // https://localhost:44330/general/llegada
        //funciona
        /*
            {
                "idViaje" : 2,
                "hora" : "11:22:00",
                "fecha": "2020-12-03"
            }
        */
        [Authorize(Roles = "Conductor")]
        [HttpPost]
        [Route("llegada")]
        [ResponseType(typeof(DTOnextBus))]
        public IHttpActionResult llegada([FromBody] DTOLegada llegada)
        {
            try
            {
                if (llegada == null)
                {
                    return Content(HttpStatusCode.BadRequest, "No.");
                }

                DTOnextBus res = cGeneral.CrearLlegada(llegada.idViaje, TimeSpan.Parse(llegada.hora), Convert.ToDateTime(llegada.fecha));

                return Ok(res);

            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        
        [AllowAnonymous]
        [HttpGet]
        [Route("echoping")]
        public IHttpActionResult EchoPing()
        {
            return Ok(true);
        }

        //----------------------------------login----------------------------------------
        // https://localhost:44330/general/login
        //funciona
        /*
            {
                "email" : "ConductorGuille@gmail.com",
                "password" :"1234",
                "rol" : "Conductor"
            }
        */
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        [ResponseType(typeof(EPersona))]
        public IHttpActionResult iniciarSesion([FromBody] DTOLogin log)
        {
            try
            {
                if (log == null)
                {
                    return Content(HttpStatusCode.BadRequest, "No.");
                }

                EPersona res = cGeneral.iniciarSesion(log.email, log.password, log.rol);
                DTOEpToken ept = new DTOEpToken();
                ept.id = res.id;
                ept.Password = "null";
                ept.Correo = res.Correo;
                ept.Documento = res.Documento;
                ept.TipoDocumento = res.TipoDocumento;
                ept.pNombre = res.pNombre;
                ept.sNombre = res.sNombre;
                ept.pApellido = res.pApellido;
                ept.sApellido = res.sApellido;
                ept.tokenJWT = TokenGenerator.GenerateTokenJwt(log.email);

                return Ok(ept);

            }
            catch (Exception)
            {
                return NotFound();
            }
        } 

    }

}
