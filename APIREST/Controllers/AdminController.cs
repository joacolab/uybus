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
using System.Reflection;

namespace APIREST.Controllers
{
    [RoutePrefix("admin")]
    public class AdminController : ApiController
    {
        IBL_Admin cAdmin = new BL_Admin(new DAL_Linea(), new DAL_Parada(), new DAL_Salida(),
        new DAL_Vehiculo(), new DAL_Conductor(), new DAL_Tramo(), new DAL_Precio(), new DAL_Viaje());

        //----------------------------------Viajes----------------------------------------
        // https://localhost:44330/admin/crear/viajes
        //funciona
        /*
            {
            "fechaInicio" : "02/03/2020",
            "fechaFinal" : "02/04/2020",
            "diasSemana" : [1,2,3,4,5],
            "idSalida" : 2
            }
        */
        [HttpPost]
        [Route("crear/viajes")]
        [ResponseType(typeof(List<EViaje>))]
        public IHttpActionResult crearViajes([FromBody] DTOCrearViajes dTOCV)
        {
            try
            {
                if (dTOCV == null) 
                {
                    return Content(HttpStatusCode.BadRequest, "No se crearon los viajes, parametros no validos.");
                }
                List<Dias> LSTDias = new List<Dias>();
                foreach (var dia in dTOCV.diasSemana)
                {
                    LSTDias.Add((Dias)dia);
                }

                 List<EViaje> viajes = cAdmin.crearViajes(Convert.ToDateTime(dTOCV.fechaInicio), Convert.ToDateTime(dTOCV.fechaFinal), LSTDias, dTOCV.idSalida);

                if (viajes != null)
                {
                    return Ok(viajes);
                }
                return Content(HttpStatusCode.NotFound, "Los viajes no se han podido crear");
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        //funciona
        //https://localhost:44330/admin/traer/viajes
        [HttpGet]
        [Route("traer/viajes")]
        [ResponseType(typeof(List<EViaje>))]
        public IHttpActionResult GetAllViajes()
        {
            return Ok(cAdmin.getAllViaje());
        }

        //https://localhost:44330/admin/editar/viaje/3
        //funciona
        /*
            {
                "IdViaje" : 3,
                "Finalizado" : false,
                "Fecha" : "2020-12-04",
                "HoraInicioReal" : "08:01:00",
                "IdSalida" : 1
            } 
        
        */
        [HttpPut]
        [Route("editar/viaje/{IdViaje}")]              
        [ResponseType(typeof(EViaje))]
        public IHttpActionResult editarViaje(int IdViaje, [FromBody] DTOViaje viaje)
        {
            try
            {
                TimeSpan? FIR = null;
                if (viaje.HoraInicioReal != null) FIR = TimeSpan.Parse(viaje.HoraInicioReal);
                EViaje v = cAdmin.editarViaje(viaje.IdViaje,viaje.Finalizado, Convert.ToDateTime(viaje.Fecha), FIR, viaje.IdSalida);

                if (v != null)
                {
                    return Ok(v);
                }
                return Content(HttpStatusCode.NotFound, "el viaje seleccionado ya existe");
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        //----------------------------------vehiculo-------------------------------------
        //https://localhost:44330/admin/crear/vehiculo
        // funciona
        /*
         * {
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

     /*   //https://localhost:44330/admin/traer/vehiculo
        //funciona
        //https://localhost:44330/admin/traer/vehiculo?Matricula=SAF3465
        [HttpGet]
        [Route("traer/vehiculo")]
        [ResponseType(typeof(List<EVehiculo>))]
        public IHttpActionResult GetVehiculo(string matricula)
        {
            return Ok(cAdmin.getVehiculo(matricula)); //sin sus salidas
        }
     */

        //https://localhost:44330/admin/traer/vehiculos
        //funciona
        [HttpGet]
        [Route("traer/vehiculos")]
        [ResponseType(typeof(List<EVehiculo>))]
        public IHttpActionResult GetAllVehiculos()
        {
            return Ok(cAdmin.getAllVehiculos());
        }


        //Funciona
        /*
        https://localhost:44330/admin/editar/vehiculo/SAF3465
        https://localhost:44330/admin/editar/vehiculo?Matricula=MDS342

        {
            "Matricula" : "SAF3465",
            "Modelo" : "Modelo",
            "Marca" : "Marraca",
            "CantAsientos" : 4
        }
        */

        [HttpPut]
        [Route("editar/vehiculo/{Matricula}")]
        [ResponseType(typeof(EVehiculo))]
        public IHttpActionResult editarVehiculos(string Matricula, [FromBody] EVehiculo vehiculo)
        {
            try
            {
                EVehiculo ev = cAdmin.editarVehiculos(vehiculo.Marca, vehiculo.Modelo, Matricula, vehiculo.CantAsientos);
                if (ev != null)
                {
                    return Ok(ev);
                }
                return Content(HttpStatusCode.NotFound, "La matricula ya existe");
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        /*
        //https://localhost:44330/admin/editar/vehiculo?Matricula=SAF3465&Modelo=e&Marca=e&CantAsientos=11

        [HttpGet]
        [Route("editar/vehiculo")]
        [ResponseType(typeof(EVehiculo))]
        public IHttpActionResult editarVehiculos(string Matricula, string Modelo, string Marca, int CantAsientos)
        {
            try
            {
                EVehiculo ev = cAdmin.editarVehiculos(Marca, Modelo, Matricula, CantAsientos);
                if (ev != null)
                {
                    return Ok(ev);
                }
                return Content(HttpStatusCode.NotFound, "La matricula ya existe");
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        */

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

        //https://localhost:44330/admin/traer/paradas
        //funciona
        [HttpGet]
        [Route("traer/paradas")]
        [ResponseType(typeof(List<EParada>))]
        public IHttpActionResult GetAllParada()
        {
            return Ok(cAdmin.getAllParada());
        }

     

        /* funciona
           https://localhost:44330/admin/editar/parada/1
           {
                "IdParada" : "1",
                "Nombre" : "Nueva",
                "Lat" : "-34.999999",
                "Long" : "34.111111"
           }
           */

        [HttpPut]
        [Route("editar/parada/{IdParada}")]
        [ResponseType(typeof(EParada))]
        public IHttpActionResult editarParada(int IdParada, [FromBody] EParada parada)
        {
            try
            {
                EParada p = cAdmin.editarParada(parada.IdParada, parada.Nombre, parada.Lat, parada.Long);
                if (p != null)
                {
                    return Ok(p);
                }
                return Content(HttpStatusCode.NotFound, "La parada ya existe");
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        //-------------------------------linea----------------------------------------
        //
        //https://localhost:44330/admin/crear/linea
        /*
         {
            "Nombre" : "Esta"
        }
        */
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


        //https://localhost:44330/admin/traer/linea
        //funciona
        [HttpGet]
        [Route("traer/linea")]
        [ResponseType(typeof(List<ELinea>))]
        public IHttpActionResult GetAllLineas()
        {
            return Ok(cAdmin.getAllLineas());
        }



        /* funciona
           https://localhost:44330/admin/editar/linea/1

                "Nueva"
           */

        [HttpPut]
        [Route("editar/linea/{IdLinea}")]
        [ResponseType(typeof(ELinea))]
        public IHttpActionResult editarLinea(int IdLinea, [FromBody] string Nombre)
        {
            try
            {
                ELinea li = cAdmin.editarLinea(IdLinea,Nombre);
                if (li != null)
                {
                    return Ok(li);
                }
                return Content(HttpStatusCode.NotFound, "La linea ya existe");
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        //----------------------------tramo-------------------------------------------
        //funciona
        //https://localhost:44330/admin/crear/tramo
        /*
         {
            "IdParada" : 10,
            "IdLinea" : 1,
            "Orden" : 6,
            "TiempoEstimado": 1200,
            "Precio" : 54,
            "FechaEntradaVigencia" : "2020-12-04"
        }
        */
        [HttpPost]
        [Route("crear/tramo")]
        [ResponseType(typeof(ETramo))]
        public IHttpActionResult crearTramos([FromBody] DTOTramoPrecio dtoTramoPrecio)
        {

            try
            {
                ETramo etramo = cAdmin.crearTramos(dtoTramoPrecio.IdParada, dtoTramoPrecio.IdLinea, dtoTramoPrecio.Orden, dtoTramoPrecio.TiempoEstimado, dtoTramoPrecio.Precio, Convert.ToDateTime(dtoTramoPrecio.FechaEntradaVigencia));
                if (etramo != null)
                {
                    return Ok(etramo);
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, "No se créo el tramo");
                }
            }
            catch (Exception)
            {

                return NotFound();
            }
        }

        //https://localhost:44330/admin/traer/tramo
        //funciona
        [HttpGet]
        [Route("traer/tramo")]
        [ResponseType(typeof(List<ETramo>))]
        public IHttpActionResult GetAllTramos()
        {
            return Ok(cAdmin.getAllTramos());
        }

        //https://localhost:44330/admin/editar/linea/1/1
        /*Funciona
         {
            "IdParada" : 1,
            "IdLinea" : 1,
            "Orden" : 6,
            "TiempoEstimado": 3000,
            "Precio" : 100,
            "FechaEntradaVigencia" : "2020-12-04"
        }
        */
        [HttpPut]
        [Route("editar/linea/{IdLinea}/{IdParada}")]
        [ResponseType(typeof(ETramo))]
        public IHttpActionResult editarTramo(int IdLinea, int IdParada, [FromBody] DTOTramo tramo)
        {
            try
            {
                ETramo t = cAdmin.editarTramo(IdLinea, IdParada, tramo);
                if (t != null)
                {
                    return Ok(t);
                }
                return Content(HttpStatusCode.NotFound, "El tramo ya existe");
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        //-----------------------------Salida------------------------------------------
        //
        //https://localhost:44330/admin/crear/salida
        /*
         {
            "IdConductor": 7,
            "IdVehiculo" : "MAT6548",
            "IdLinea" : 1
            "HoraInicio" : "08:01:00"
        }
        */
        [HttpPost]
        [Route("crear/salida")]
        [ResponseType(typeof(ESalida))]
        public IHttpActionResult crearSaida([FromBody] DTOSalida dtoSal)
        {

            try
            {
                ESalida sal = cAdmin.crearSalida(dtoSal.IdConductor, dtoSal.IdVehiculo, dtoSal.IdLinea, TimeSpan.Parse(dtoSal.HoraInicio));
                if (dtoSal != null)
                {
                    return Ok(dtoSal);
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, "No se créo la salida");
                }
            }
            catch (Exception)
            {

                return NotFound();
            }
        }




        //https://localhost:44330/admin/traer/salida
        //funciona
        [HttpGet]
        [Route("traer/salida")]
        [ResponseType(typeof(List<ESalida>))]
        public IHttpActionResult GetAlSalidas()
        {
            return Ok(cAdmin.GetAlSalidas());
        }


        /* funciona
           https://localhost:44330/admin/editar/salida/1



        {
            "IdSalida" : 1,
            "IdConductor": 7,
            "IdVehiculo" : "MAT6548",
            "IdLinea" : 1
            "HoraInicio" : "08:01:00",
        }
               
           */

        [HttpPut]
        [Route("editar/salida/{IdSalida}")]
        [ResponseType(typeof(ESalida))]
        public IHttpActionResult F(int IdSalida, [FromBody] DTOSalida salida)
        {
            try
            {
                ESalida li = cAdmin.editarSalida(salida.IdSalida, TimeSpan.Parse(salida.HoraInicio), salida.IdConductor, salida.IdVehiculo, salida.IdLinea);

                if (li != null)
                {
                    return Ok(li);
                }
                return Content(HttpStatusCode.NotFound, "La salida ya existe");
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        //-----------------------------conductor------------------------------------------


        //https://localhost:44330/admin/traer/Conductores
        //funciona
        [HttpGet]
        [Route("traer/Conductores")]
        [ResponseType(typeof(List<EConductor>))]
        public IHttpActionResult GetAllConductores()
        {
            return Ok(cAdmin.GetAllConductores());
        }

        //https://localhost:44330/admin/editar/conductor/7
        /*Funciona
         {
            "VencimientoLicencia": "2021-02-02"
        }
        */
        [HttpPut]
        [Route("editar/conductor/{Id}")]
        [ResponseType(typeof(EConductor))]
        public IHttpActionResult gestionConductores(int Id, [FromBody] string venLibreta)
        {
            try
            {
                cAdmin.gestionConductores(Id, Convert.ToDateTime(venLibreta));
                return Ok();
                
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

    }
}
