using Share.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApp.Proxys;
using MercadoPago;
using MercadoPago.Resources;
using MercadoPago.DataStructures.Preference;
using MercadoPago.Common;

namespace WebApp.Controllers
{
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
            int idL = (int)Session["idLinea"];
            int idPo = (int)Session["idPOrigen"];
            int idPD = (int)Session["idPDestino"];
            int costo = Task.Run(() => pxu.costoPasaje(idL, idPo, idPD)).Result;
            Session["costo"] = costo;
            ViewBag.Message = costo;

            return View();
        }

        [HttpPost]
        public ActionResult documento(DTOCompPasaje p)
        {
            DTOComprarPasaje pasaje = new DTOComprarPasaje();

            pasaje.idViaje = (int)Session["idViaje"];
            pasaje.idParadaOrigen = (int)Session["idPOrigen"];
            pasaje.idParadaDestino = (int)Session["idPDestino"];

            if(Session["asiento"] == null) pasaje.asiento = -1;
            else pasaje.asiento = (int)Session["asiento"];
            
            pasaje.documento = p.documento;
            pasaje.tipoDoc = p.tipoDoc.ToString();

            pasaje.idUsuario = -1; //usuario no logeado, arreglar esto <<<<---------!!!!--------------
            pxu.comprarPasaje(pasaje); // se complra el pasaje
            Session.Clear();//flush session

            if (Session["idPersona"] != null)
            {
                pasaje.idUsuario = (int)Session["idPersona"];
                pxu.comprarPasaje(pasaje);
            }
            else
            {
                pasaje.idUsuario = -1; //usuario no logeado, arreglar esto <<<<---------!!!!--------------
                pxu.comprarPasaje(pasaje);
            }

            return RedirectToAction("Index");
            //return View("Index");
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

        private void realizarPago()
        {

            Payer pagodor = new Payer()
            {
                Name = "Charles",
                Surname = "Luevano",
                Email = "charles@hotmail.com",
                Phone = new Phone()
                {
                    AreaCode = "",
                    Number = "949 128 866"
                },

                Identification = new Identification()
                {
                    Type = "DNI",
                    Number = "12345678"
                },

                Address = new Address()
                {
                    StreetName = "Cuesta Miguel Armendáriz",
                    StreetNumber = int.Parse("1004"),
                    ZipCode = "11020"
                }
            };
            // Agrega credenciales
            MercadoPago.SDK.AccessToken = "TEST-7973387597353528-111100-22a223faad023d7803c3d6cbcd7842e8-247519004";
            // Crea un objeto de preferencia
            Preference preference = new Preference();
            // Crea un ítem en la preferencia
            preference.Items.Add(
              new Item()
              {
                  Title = "Mi producto",
                  Quantity = 1,
                  CurrencyId = CurrencyId.UYU,
                  UnitPrice = (decimal)75.56
              }
            );
            //define las urls de retorno
            preference.BackUrls = new BackUrls()
            {
                Success = "https://www.tu-sitio/success",
                Failure = "http://www.tu-sitio/failure",
                Pending = "http://www.tu-sitio/pendings"
            };
            preference.AutoReturn = AutoReturnType.approved;
            preference.Save();
        }
        












    }
}