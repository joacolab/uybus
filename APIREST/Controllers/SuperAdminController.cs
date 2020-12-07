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
    [Authorize(Roles = "SuperAdmin")]
    [RoutePrefix("super-admin")]
    public class SuperAdminController : ApiController
    {
        IBL_SuperAdmin cSuperAdmin = new BL_SuperAdmin(new DAL_Persona(), new DAL_Usuario(), new DAL_Admin(), new DAL_Conductor(),
    new DAL_Llegada(), new DAL_Parada(), new DAL_Salida(), new DAL_Vehiculo(), new DAL_Viaje());

        IBL_Admin cAdmin = new BL_Admin(new DAL_Linea(), new DAL_Parada(), new DAL_Salida(),
new DAL_Vehiculo(), new DAL_Conductor(), new DAL_Tramo(), new DAL_Precio(), new DAL_Viaje());

        //https://localhost:44330/admin/traer/paradas
        //funciona
        [HttpGet]
        [Route("traer/paradas")]
        [ResponseType(typeof(List<EParada>))]
        public IHttpActionResult GetAllParada()
        {
            return Ok(cAdmin.getAllParada());
        }

        //https://localhost:44330/super-admin/traer/Personas
        //funciona
        [HttpGet]
        [Route("traer/Personas")]
        [ResponseType(typeof(List<EPersona>))]
        public IHttpActionResult GetAllPersonas()
        {
            return Ok(cSuperAdmin.GetAllPersonas());
        }

        //-------------------------------ubicarVehiculo------------------------------------------
        //https://localhost:44330/super-admin/ubicarVehiculo

        [HttpGet]
        [Route("ubicarVehiculo")]
        [ResponseType(typeof(List<DTOubicacion>))]
        public IHttpActionResult ubicarVehiculo()
        {
            return Ok(cSuperAdmin.ubicarVehiculo());
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

                EPersona ePersona = cSuperAdmin.asignarRol(IdPersona, (Rol)PersonaRol.rol);
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
