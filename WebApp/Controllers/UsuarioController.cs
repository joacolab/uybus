using Share.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApp.Proxys;

namespace WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        private ProxyUsuario pxu = new ProxyUsuario();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult traerLineas()
        {
            return View(Task.Run(() => pxu.listarLineas()).Result); // se listan las lineas
        }

        public ActionResult selectLinea(int id) // id de la linea seleccionada
        {
            Session["idLinea"] = id; //me guardo la linea para despues
            return View(Task.Run(() => pxu.listarParadasOrigen(id)).Result); //se listan las paradas O, de esa linea
        }

        public ActionResult selectPOrigen(int id) // id de la parada de origen
        {
            Session["idPOrigen"] = id; //me guardo la paradaO para despues
            int idLinea = (int)Session["idLinea"]; //obtengo el idLinea, de la session

            return View(Task.Run(() => pxu.listarParadasDestino(idLinea, id)).Result);//se listan las paradas D, de esa linea
        }

        public ActionResult selectPDestino(int id) // id de la parada de destino
        {
            Session["idPDestino"] = id;//me guardo la paradaD para despues
            int idLinea = (int)Session["idLinea"]; //obtengo el idLinea, de la session
            return View(Task.Run(() => pxu.listarSalidas(idLinea)).Result);//se listan las salidas de esa linea
        }

        public ActionResult selecSalida(int id) // id de la salida
        {
            Session["idSalida"] = id;//me guardo la salida para despues
            return View(Task.Run(() => pxu.listarViajes(id)).Result);//se listan los viajes de esa salida
        }

        public ActionResult selecViaje(int id) // id del viaje
        {
            Session["idViaje"] = id;//me guardo el viaje para despues

            int idLinea = (int)Session["idLinea"];
            int idPOrigen = (int)Session["idPOrigen"];
            int idPDestino = (int)Session["idPDestino"];

            if (Task.Run(() => pxu.canSelectSeat(idLinea, idPOrigen, idPDestino)).Result) //hay que ver si puede seleccionar un asiento
            {
                return View(Task.Run(() => pxu.listarAsientos(id)).Result);//se listan los asientos de ese viaje
            }
            int idL = (int)Session["idLinea"];
            int idPo = (int)Session["idPOrigen"];
            int idPD = (int)Session["idPDestino"];
            ViewBag.Message = Task.Run(() => pxu.costoPasaje(idL, idPo, idPD)).Result;
            return RedirectToAction("documento");
            //return View("documento");//ingresar docu y tipoDocu
        }

        public ActionResult selectAsiento(int id) // asiento
        {
            Session["asiento"] = id;//me guardo el asiento para despues

            int idL = (int)Session["idLinea"];
            int idPo = (int)Session["idPOrigen"];
            int idPD = (int)Session["idPDestino"];
            ViewBag.Message = Task.Run(() => pxu.costoPasaje(idL, idPo, idPD)).Result;
            return RedirectToAction("documento");
            //return View("documento");//ingresar docu y tipoDocu
        }

        public ActionResult documento() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult documento(DTOCompPasaje p)
        {
            DTOComprarPasaje pasaje = new DTOComprarPasaje();

            pasaje.idViaje = (int)Session["idViaje"];
            pasaje.idParadaOrigen = (int)Session["idPOrigen"];
            pasaje.idParadaDestino = (int)Session["idPDestino"];
            pasaje.asiento = (int)Session["asiento"];
            pasaje.documento = p.documento;
            pasaje.tipoDoc = p.tipoDoc.ToString();

            pasaje.idUsuario = -1; //usuario no logeado, arreglar esto <<<<---------!!!!--------------

            pxu.comprarPasaje(pasaje); // se complra el pasaje
            Session.Clear();//flush session

            return RedirectToAction("Index");
            //return View("Index");
        }











    }
}