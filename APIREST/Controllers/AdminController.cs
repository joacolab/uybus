using System;
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

        //----------------------------------Viajes----------------------------------------
        [HttpPost]
        [Route("crear/viajes")]
        public List<EViaje> crearViajes(DateTime fechaInicio, DateTime fechaFinal, List<Dias> diasSemana, int idSalida)
        {
            List<EViaje> viajes = cAdmin.crearViajes(fechaInicio, fechaFinal, diasSemana, idSalida);
            return viajes;
        }
        //----------------------------------vehiculo-------------------------------------
        //https://localhost:44330/admin/crear/vehiculo
        /*
        {
            "Matricula" : "MDS342"
            "Modelo" : "Modelo"
            "Marca" : "marca"
            "CantAsientos" : 4
            "Salida" : []
        }
        */
        [HttpPost]
        [Route("crear/vehiculo")]
        [ResponseType(typeof(EVehiculo))]
        public IHttpActionResult crearVehiculos([FromBody] EVehiculo vehiculo)
        {
            
            try
            {
                if (String.IsNullOrEmpty(vehiculo.Marca) || String.IsNullOrEmpty(vehiculo.Modelo) || String.IsNullOrEmpty(vehiculo.Matricula) )
                {
                    return Content(HttpStatusCode.BadRequest, "No se creó el nuevo vehiculo, parametros no validos.");
                }
                else
                {
                    EVehiculo ev = cAdmin.crearVehiculos(vehiculo.Marca, vehiculo.Modelo, vehiculo.Matricula, vehiculo.CantAsientos);
                    if (ev != null)
                    {
                        return Ok(ev);
                    }
                    return Content(HttpStatusCode.NotFound, "La matricula ya existe");
                }
            }
            catch (Exception)
            {
                return NotFound();
            }

        }

        //https://localhost:44330/admin/traer/vehiculo
        //SAF3465
        [HttpGet]
        [Route("traer/vehiculo")]
        [ResponseType(typeof(List<EVehiculo>))]
        public IHttpActionResult GetAllVehiculos(string matricula)
        {
            return Ok(cAdmin.getVehiculo(matricula)); //sin sus salidas
        }

        //https://localhost:44330/admin/traer/vehiculos
        [HttpGet]
        [Route("traer/vehiculos")]
        [ResponseType(typeof(List<EVehiculo>))]
        public IHttpActionResult GetAllVehiculos()
        {
            return Ok(cAdmin.getAllVehiculos());
        }

        [HttpPut]
        [Route("editar/vehiculo")]
        EVehiculo editarVehiculos(string Marca, string Modelo, string Matricula, int cantAsientos)
        {
            return cAdmin.editarVehiculos(Marca, Modelo, Matricula, cantAsientos);
        }
        //------------------------------------parada----------------------------------
        //funciona
        //https://localhost:44330/admin/crear/parada
        /*
         {
            "IdParada" : "",
            "Nombre" : "MontevideoPrueba",
            "Lat" : "-32,23",
            "Long" : "79,12"
        }
        */
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
        //-------------------------------linea----------------------------------------
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
        //----------------------------tramo-------------------------------------------
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
        //-----------------------------conductor------------------------------------------
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
