using BuisnessLayer.implementation;
using BuisnessLayer.interfaces;
using DataAcessLayer.implementation;
using Share.entities;
using Share.DTOs;
using Share.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;


namespace APIREST.Controllers
{
    [RoutePrefix("super-admin")]
    public class SuperAdminController : ApiController
    {
        IBL_SuperAdmin cSuperAdmin = new BL_SuperAdmin(new DAL_Persona(), new DAL_Usuario(), new DAL_Admin(), new DAL_Conductor(),
    new DAL_Llegada(), new DAL_Parada(), new DAL_Salida(), new DAL_Vehiculo(), new DAL_Viaje());



        //https://localhost:44330/super-admin/traer/Personas
        //funciona
        [HttpGet]
        [Route("traer/Personas")]
        [ResponseType(typeof(List<EPersona>))]
        public IHttpActionResult GetAllPersonas()
        {
            return Ok(cSuperAdmin.GetAllPersonas());
        }

        //---------------------------------- Asignar Rol ---------------------------------------------------------
        /* Funciona:
         * Copiar el siguiente codigo y ejecutarlo el el gitbash:
         * 
        curl -v -X PUT -k -H 'Content-Type: application/json; charset=utf-8' \
        -d '{"idPersona":4,"rol":48}' \
        https://localhost:44330/super-admin/asignar-rol/4
        */
        [Route("asignar-rol/{IdPersona}")]
        [HttpPut]
        [ResponseType(typeof(EPersona))]
        public IHttpActionResult AsignarRol(int IdPersona, [FromBody] DTOPersonaRol PersonaRol)
        {
            try
            {
                int id, rol;

                if (!int.TryParse(IdPersona.ToString(), out id))
                {
                    return Content(HttpStatusCode.BadRequest, "¡El id '" + IdPersona.ToString() + "' de la url no es válido!");
                }
                if (!int.TryParse(PersonaRol.idPersona.ToString(), out id))
                {
                    return Content(HttpStatusCode.BadRequest, "¡El id '" + PersonaRol.idPersona.ToString() + "' del json no es válido!");
                }
                if (!int.TryParse(PersonaRol.rol.ToString(), out rol))
                {
                    return Content(HttpStatusCode.BadRequest, "¡El rol '" + PersonaRol.rol.ToString() + "' del json no es válido!");
                }
                if (IdPersona != PersonaRol.idPersona)
                {
                    return Content(HttpStatusCode.BadRequest, "¡El id de la url no coincide con el del json");
                }
                Rol rolRecibido = (Rol)PersonaRol.rol;

                if (!Enum.IsDefined(typeof(Rol), rolRecibido))
                {
                    return Content(HttpStatusCode.BadRequest, "¡El rol ingresado no es válido!");
                }

                EPersona ePersona = cSuperAdmin.asignarRol(IdPersona, rolRecibido);
                if (ePersona == null)
                {
                    return Content(HttpStatusCode.BadRequest, "¡Error al intentar asignar un nuevo rol!");
                }
                return Ok(ePersona);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
