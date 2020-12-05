using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Share.entities;
using Share.enums;
using Share.DTOs;
using System.Web.Http.Description;
using BuisnessLayer.implementation;
using BuisnessLayer.interfaces;
using DataAcessLayer.implementation;

namespace APIREST.Controllers
{
    [Authorize(Roles = "Usuario")]
    [RoutePrefix("usuario")]
    public class UsuarioController : ApiController
    {
        IBL_Usuario cUsuario = new BL_Usuario( new DAL_Persona(), new DAL_Usuario(), new DAL_Linea(), new DAL_Salida(),
            new DAL_Tramo(), new DAL_Viaje(), new DAL_Pasaje(), new DAL_Parametro(), new DAL_Parada(), new DAL_Llegada(),
            new DAL_Vehiculo());

        /* Funciona
         * curl -v -k -H 'Content-Type: application/json' https://localhost:44330/usuario/listar/lineas
         */
        [HttpGet]
        [Route("listar/lineas")]
        [ResponseType(typeof(List<ELinea>))]
        public IHttpActionResult listarLineas()
        { 
            try
            {
                List<ELinea> lineas = cUsuario.listarLineas();
                return Ok(lineas);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        /* Funciona
         * curl -v -k -H 'Content-Type: application/json' https://localhost:44330/usuario/listar/paradas/1
         */
        [HttpGet]
        [Route("listar/paradas/{IdLinea}")]
        [ResponseType(typeof(List<EParada>))]
        public IHttpActionResult listarParadas(int IdLinea)
        {
            try
            {
                List<EParada> paradas = cUsuario.listarParadas(IdLinea);
                return Ok(paradas);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        /* funciona
         * curl -v -k -H 'Content-Type: application/json' https://localhost:44330/usuario/listar/paradas/1
         */
        [HttpGet]
        [Route("listar/pdestino/{IdLinea}/{IdParada}")]
        [ResponseType(typeof(List<EParada>))]
        public IHttpActionResult listarParadasDestino(int IdLinea, int IdParada)
        {
            try
            {
                List<EParada> paradas = cUsuario.listarParadasD(IdLinea, IdParada);
                return Ok(paradas);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        /* Funciona
         * Sin probar, porque no hay datos
         * curl -v -k -H 'Content-Type: application/json' https://localhost:44330/usuario/listar/salidas/1
         */
        [HttpGet]
        [Route("listar/salidas/{IdLinea}")]
        [ResponseType(typeof(List<ESalida>))]
        public IHttpActionResult GetSalidas(int IdLinea)
        {
            try
            {
                List<ESalida> salidas = cUsuario.GetSalidas(IdLinea);
                return Ok(salidas);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        /* funciona
         * Sin probar, porque no hay datos
         * curl -v -k -H 'Content-Type: application/json' https://localhost:44330/usuario/listar/viajes/1
         */
        [HttpGet]
        [Route("listar/viajes/{IdSalida}")]
        [ResponseType(typeof(List<EViaje>))]
        public IHttpActionResult GetFechasViajes(int IdSalida)
        {
            try
            {
                List<EViaje> viajes = cUsuario.GetFechasViajes(IdSalida);
                return Ok(viajes);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }


        /* funicona
         * Salta una excepcion
         * curl -v -k -H 'Content-Type: application/json' https://localhost:44330/usuario/listar/asientos/idViaje
         */
        [HttpGet]
        [Route("listar/asientos/{idViaje}")]
        [ResponseType(typeof(List<int>))]
        public IHttpActionResult GetAsientos(int idViaje)
        {
            try
            {
                List<int> asisentos = cUsuario.GetAsientos(idViaje);
                return Ok(asisentos);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        /* funciona
         * Sin Probar
         * curl -v -k https://localhost:44330/usuario/asiento/1/1/5
         */
        [HttpGet]
        [Route("asiento/{IdLinea}/{IdParadaOrigen}/{IdParadaDestino}")]
        [ResponseType(typeof(bool))]
        public IHttpActionResult canSelectSeat(int IdLinea, int IdParadaOrigen, int IdParadaDestino)
        {
            try
            {
                bool res = cUsuario.canSelectSeat(IdLinea, IdParadaOrigen, IdParadaDestino);
                return Ok(res);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        /* funciona
         * Sin Probar
         * curl -v -k https://localhost:44330/usuario/paradas/1/1
         */
        [HttpGet]
        [Route("paradas/{IdLinea}/{IdParada}")]
        public IHttpActionResult listarParadasD(int IdLinea, int IdParada)
        {
            try
            {
                List<EParada> paradas = cUsuario.listarParadasD(IdLinea, IdParada);
                return Ok(paradas);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        /* funciona
         * Sin Probar
         * curl -v -k https://localhost:44330/usuario/paradas/1/1
         */
        [HttpGet]
        [Route("sinterminal")]
        public IHttpActionResult sinTerminal()
        {
            try
            {
                List<EParada> paradas = cUsuario.sinTerminales();
                return Ok(paradas);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        /* funciona
            curl -v -X POST -k -H 'Content-Type: application/json; charset=utf-8' \
            -d '{"idViaje":2, "idUsuario":1, "idParadaOrigen":2, "idParadaDestino":4, "tipoDoc":1, "documento":"87779994", "asiento":12}' \
            https://localhost:44330/usuario/comprar
            {
                "idViaje":1,
                "idUsuario":2,
                "idParadaOrigen":1,
                "idParadaDestino":2,
                "tipoDoc":"null",
                "documento":"null",
                "asiento":2
            }
         */
        [HttpPost]
        [Route("comprar")]
        [ResponseType(typeof(EPasaje))]
        public IHttpActionResult comprarPasaje([FromBody]DTOComprarPasaje p)
        {
            try
            {
                EPasaje pasaje = cUsuario.comprarPasaje(p.idViaje, p.idUsuario, p.idParadaOrigen, 
                    p.idParadaDestino, p.tipoDoc, p.documento, p.asiento);
                if (pasaje == null) return Content(HttpStatusCode.BadRequest, "¡No se pudo realizar la compra del pasaje!");
                return Ok(pasaje);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        //funciona
        //https://localhost:44330/usuario/proximos/2/3
        [HttpGet]
        [Route("proximos/{IdUsuario}/{IdParada}")]
        [ResponseType(typeof(List<DTOproxVehiculo>))]
        public IHttpActionResult proximoVehiculo(int IdUsuario, int IdParada)
        {
            try
            {
                List<DTOproxVehiculo> proximos = cUsuario.proximoVehiculo(IdUsuario, IdParada);
                if (proximos == null) return Content(HttpStatusCode.BadRequest, "¡No se encontraron resultados para los datos ingresados!");
                return Ok(proximos);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        //funciona
        //https://localhost:44330/usuario/precio/1/1/2
        [HttpGet]
        [Route("precio/{IdLinea}/{IdParadaOrigen}/{IdParadaDestino}")]
        public IHttpActionResult precioDelPasaje(int IdLinea, int IdParadaOrigen, int IdParadaDestino)
        {
            try
            {
                int precio = cUsuario.precioDelPasaje(IdLinea, IdParadaOrigen, IdParadaDestino);
                return Ok(precio);
            }
            catch (Exception)
            {
                return NotFound();
            }

            throw new NotImplementedException();
        }
    }
}
