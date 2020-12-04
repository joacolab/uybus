using BuisnessLayer.implementation;
using BuisnessLayer.interfaces;
using DataAcessLayer.implementation;
using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Share.DTOs;
using Share.enums;

namespace APIREST.Controllers

{
    [AllowAnonymous]
    [RoutePrefix("invitado")]
    public class InvitadoController : ApiController
    {
        IBL_Invitado bli = new BL_Invitado(new DAL_Persona(), new DAL_Usuario());
        IBL_General blg = new BL_General(new DAL_Viaje(), new DAL_Llegada(), new DAL_Salida(), new DAL_Linea(), new DAL_Tramo(), new DAL_Parada(), new DAL_Pasaje(), new DAL_Usuario(), new DAL_Vehiculo(), new DAL_Persona(), new DAL_Admin(), new DAL_Conductor(), new DAL_SuperAdmin());

        //-----------------------------------------  correoUnico  --------------------------------------
        //https://localhost:44330/invitado/verificar
        //"ConductorGuille@gmail.com"

        [HttpPost]
        [Route("verificar")]
        [ResponseType(typeof(bool))]
        public IHttpActionResult correoUnico([FromBody] string email)
        {

            try
            {
                return Ok(blg.correoUnico(email));
            }

            catch (Exception)
            {
                return NotFound();
            }
        }

        //----------------------------------------  ---------------------------------------------------------
        /* Funciona:
        * Copiar el siguiente codigo y ejecutarlo el el gitbash:
        * 
          curl -v -X POST -k -H 'Content-Type: application/json; charset=utf-8' \
          -d '{"Documento":"87779994", "Correo":"correo@hotmail.com", "Password":"","TipoDocumento":1,"pNombre":"Ramon", "sNombre":"Carlos","pApellido":"Ramirez", "sApellido":""}' \
          https://localhost:44330/invitado/registrarse
        */
        [HttpPost]
        [Route("registrarse")]
        [ResponseType(typeof(DTOPersona))]
        public IHttpActionResult Registrarse([FromBody] EPersona persona)
        {   try
            {
                if (String.IsNullOrEmpty(persona.pNombre))
                {
                    return Content(HttpStatusCode.BadRequest, "¡El primer nombre es no es válido!");
                }
                if (String.IsNullOrEmpty(persona.pApellido))
                {
                    return Content(HttpStatusCode.BadRequest, "¡El primer apellido es no es válido!");
                }
                if (String.IsNullOrEmpty(persona.sNombre))
                {
                    persona.sNombre = "";
                }
                if (String.IsNullOrEmpty(persona.sApellido))
                {
                    persona.sApellido = "";
                }
                if (String.IsNullOrEmpty(persona.Documento))
                {
                    return Content(HttpStatusCode.BadRequest, "¡El documento no es válido!");
                }
                if (String.IsNullOrEmpty(persona.Correo))
                {
                    return Content(HttpStatusCode.BadRequest, "¡El correo no es válido!");
                }
                int tipoDoc; // Almacena el int que representa el tipo de documento
                if (!int.TryParse(persona.TipoDocumento.ToString(), out tipoDoc))
                {
                    return Content(HttpStatusCode.BadRequest, "¡El tipo de documento '" + persona.TipoDocumento.ToString() + "' no es válido!");
                }

                EUsuario eUsuario = bli.registrarse(persona.Documento, persona.Correo, persona.Password, persona.TipoDocumento,
                    persona.pNombre, persona.sNombre, persona.pApellido, persona.sApellido);
                if (eUsuario == null)
                {
                    return Content(HttpStatusCode.BadRequest, "¡Error al intentar registrar el nuevo usuario!");
                }
                DTOPersona dtoPersona = new DTOPersona();
                dtoPersona.id = eUsuario.Id;
                dtoPersona.pNombre = persona.pNombre;
                dtoPersona.pApellido = persona.pApellido;
                dtoPersona.sNombre = persona.sNombre;
                dtoPersona.sApellido = persona.sApellido;
                dtoPersona.Documento = persona.Documento;
                dtoPersona.TipoDocumento = persona.TipoDocumento;
                dtoPersona.Correo = persona.Correo;
                
                return Ok(dtoPersona);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
