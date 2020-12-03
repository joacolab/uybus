using MercadoPago.Common;
using MercadoPago.DataStructures.Payment;
using MercadoPago.Resources;
using Share.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApp.Autorisacion;
using WebApp.Proxys;


namespace WebApp.Controllers
{
    [HandleError]
    [Autorizacion(usuario = true)]
    public class UsuarioController : Controller
    {
        private ProxyUsuario pxu = new ProxyUsuario();

        public ActionResult Index()
        {
            if (Session["pNombre"] != null && Session["pApellido"] != null)
            {
                ViewBag.nombreUsu = Session["pNombre"].ToString() + " " + Session["pApellido"].ToString();
            }
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

            int costo = Task.Run(() => pxu.costoPasaje(idL, idPo, idPD)).Result;
            Session["costo"] = costo;
            ViewBag.Message = costo;

            return RedirectToAction("documento");
            //return View("documento");//ingresar docu y tipoDocu
        }

        public ActionResult selectAsiento(int id) // asiento
        {
            Session["asiento"] = id;//me guardo el asiento para despues

            int idL = (int)Session["idLinea"];
            int idPo = (int)Session["idPOrigen"];
            int idPD = (int)Session["idPDestino"];


            int costo = Task.Run(() => pxu.costoPasaje(idL, idPo, idPD)).Result;
            Session["costo"] = costo;
            ViewBag.Message = costo;

            return RedirectToAction("documento");
            //return View("documento");//ingresar docu y tipoDocu
        }

        public ActionResult documento() 
        {
            ViewBag.ErrorPago = false;
            if (Session["ErrorPago"] != null)
            {
                if (Session["ErrorPago"].ToString() == "Error")
                {
                    ViewBag.ErrorPago = true;
                }
            }
            int idL = (int)Session["idLinea"];
            int idPo = (int)Session["idPOrigen"];
            int idPD = (int)Session["idPDestino"];
            int costo = Task.Run(() => pxu.costoPasaje(idL, idPo, idPD)).Result;
            Session["costo"] = costo;
            ViewBag.Message = costo;

            return View();
        }

        public ActionResult pago(FormCollection pago)
        {
            try
            {
                MercadoPago.SDK.SetAccessToken("TEST-995817817198514-111820-6429e0e59a4e1b887c6d078d7b5a0e32-174046938");
                Payment payment = new Payment()
                {
                    TransactionAmount = (int)Session["costo"],
                    Token = pago["token"],
                    Description = "Pago de pasaje",
                    Installments = int.Parse(pago["installments"]),
                    PaymentMethodId = pago["payment_method_id"],
                    IssuerId = pago["issuer_id"],
                    Payer = new Payer()
                    {
                        Email = "uruguaybus.2020@gmail.com"
                    }
                };
                payment.Save();
                if (payment.Status != PaymentStatus.approved)
                {
                    Session["ErrorPago"] = "Error";
                    return RedirectToAction("documento");
                }

                DTOComprarPasaje pasaje = new DTOComprarPasaje();
                pasaje.idViaje = (int)Session["idViaje"];
                pasaje.idParadaOrigen = (int)Session["idPOrigen"];
                pasaje.idParadaDestino = (int)Session["idPDestino"];
                if (Session["asiento"] == null) pasaje.asiento = -1;
                else pasaje.asiento = (int)Session["asiento"];
                pasaje.documento = Session["Documento"].ToString();
                pasaje.tipoDoc = Session["TipoDocumento"].ToString();
                pasaje.idUsuario = (int)Session["idPersona"];

                pxu.comprarPasaje(pasaje);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                Session["ErrorPago"] = "Error";
                return RedirectToAction("documento");
            }
            
        }

        //----------------proximos vehiculos-----------------
        public ActionResult proxVehiculos()
        {
            return View(Task.Run(() => pxu.sinterminal()).Result);
        }

        public ActionResult verVehiculoP(int id)
        {
            Session["idUsuario"] = 2; // arreglar esto <<<< --------------------- !!!!!
            int idUsuario = (int)Session["idUsuario"]; // esto no iria
            return View(Task.Run(() => pxu.proximoVehiculo(idUsuario,id)).Result);
        }

    }
}