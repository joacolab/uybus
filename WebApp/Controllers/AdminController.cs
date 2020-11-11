using Share.DTOs;
using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApp.Proxys;

namespace WebApp.Controllers
{
    public class AdminController : Controller
    {
        private ProxyAdmin pxa = new ProxyAdmin();

        public ActionResult Index()
        {
            return View();
        }
        //---------------------------------------------------------------

        public ActionResult traerVehiculos()
        {
            return View(Task.Run(() => pxa.getAllVehiculos()).Result);
        }

        public ActionResult crearVehiculo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult crearVehiculo(EVehiculo vehiculo)
        {
            pxa.crearVehiculo(vehiculo);
            return RedirectToAction("traerVehiculos");
        }

        
        public ActionResult editarVehiculo(string id)
        {
            EVehiculo ev = new EVehiculo();
            ev.Matricula = id;
            return View(ev);
        }

        [HttpPost]
        public ActionResult editarVehiculo(EVehiculo vehiculo)
        {
            pxa.editarVehiculo(vehiculo);
            return RedirectToAction("traerVehiculos");
        }
        //------------------------VIAJES---------------------------------------
        public ActionResult traerViajes()
        {
            return View(Task.Run(() => pxa.getAllViajes()).Result);
        }

        
        public ActionResult crearViaje()
        {
            return View();
        }

        [HttpPost]
        public ActionResult crearViaje(DTOCrearViajes viajes)
        {
            pxa.crearViajes(viajes);
            return RedirectToAction("traerViajes");
        }

        
        public ActionResult editarViaje(int id)
        {
            DTOViaje ev = new DTOViaje();
            ev.IdViaje = id;
            return View(ev);
        }
        
        [HttpPost]
        public ActionResult editarViaje(DTOViaje viajes)
        {
            pxa.editarViaje(viajes);
            return RedirectToAction("traerViajes");
        }
        

        //-----------------------------parada---------------------------------
        public ActionResult traerParadas()
        {
            return View(Task.Run(() => pxa.GetAllParada()).Result);
        }

        public ActionResult editarParada(int id)
        {
            DTOParada p = new DTOParada();
            p.IdParada = id;
            return View(p);
        }

        [HttpPost]
        public ActionResult editarParada(DTOParada parada)
        {
            pxa.editarParada(parada);
            return RedirectToAction("traerParadas");
        }
        

        //-------------------------------linea----------------------------------------

        public ActionResult traerLinea()
        {
            return View(Task.Run(() => pxa.GetAllLineas()).Result);
        }

        
        public ActionResult crearLinea()
        {
            return View();
        }

        [HttpPost]
        public ActionResult crearLinea(DTOLinea linea)
        {
            Session["Nuevalinea"] = pxa.crearLinea(linea);

            //ELinea el = (ELinea)Session["Nuevalinea"];

            return RedirectToAction("asignarParada");
            //return RedirectToAction("traerLinea");
        }

        public ActionResult asignarParada()
        {
            return View();
        }

        [HttpPost]
        public ActionResult asignarParada(DTOTramoParada tp)
        {
            if (!tp.isFinal)
            {
                DTOParada par = new DTOParada();
                par.IdParada = tp.IdParada;
                par.Lat = tp.Lat;
                par.Long = tp.Long;
                par.Nombre = tp.Nombre;
                EParada ep = pxa.crearParada(par);
                DTOTramoPrecio tpre = new DTOTramoPrecio();
                ELinea el = (ELinea)Session["Nuevalinea"];
                tpre.IdLinea = el.IdLinea;
                tpre.IdParada = ep.IdParada;
                tpre.Orden =tp.Orden;
                tpre.TiempoEstimado = tp.TiempoEstimado;

                if (tp.isOrigen)
                {
                    tpre.FechaEntradaVigencia = "2000-01-01";
                    tpre.Precio = 0;
                }
                else
                {
                    tpre.FechaEntradaVigencia = tp.FechaEntradaVigencia;
                    tpre.Precio = tp.Precio;
                }

                pxa.crearTramo(tpre);
                return View();
            }
            else
            {
                DTOParada par = new DTOParada();
                par.IdParada = tp.IdParada;
                par.Lat = tp.Lat;
                par.Long = tp.Long;
                par.Nombre = tp.Nombre;
                EParada ep = pxa.crearParada(par);
                DTOTramoPrecio tpre = new DTOTramoPrecio();
                ELinea el = (ELinea)Session["Nuevalinea"];
                tpre.IdLinea = el.IdLinea;
                tpre.IdParada = ep.IdParada;
                tpre.Orden = tp.Orden;
                tpre.TiempoEstimado = tp.TiempoEstimado;
                tpre.FechaEntradaVigencia = tp.FechaEntradaVigencia;
                tpre.Precio = tp.Precio;
                pxa.crearTramo(tpre);

                return RedirectToAction("Index");
            }
        }


        public ActionResult editarLinea(int id)
        {
            DTOLinea p = new DTOLinea();
            p.IdLinea = id;
            return View(p);
        }

        [HttpPost]
        public ActionResult editarLinea(DTOLinea linea)
        {
            pxa.editarLinea(linea);
            return RedirectToAction("traerLinea");
        }
        

        //-----------------------------Salida------------------------------------------

        public ActionResult traerSalida()
        {
            return View(Task.Run(() => pxa.GetAllSalida()).Result);
        }
               
        public ActionResult crearSalida()
        {
            return View();
        }

        [HttpPost]
        public ActionResult crearSalida(DTOSalida salida)
        {
            pxa.crearSalida(salida);
            return RedirectToAction("traerSalida");
        }
        

        public ActionResult editarSalida(int id)
        {
            DTOSalida p = new DTOSalida();
            p.IdSalida = id;
            return View(p);
        }

        [HttpPost]
        public ActionResult editarSalida(DTOSalida salida)
        {
            pxa.editarSalida(salida);
            return RedirectToAction("traerSalida");
        }
        //----------------Conductor------------------------------------


        public ActionResult traerConductores()
        {
            return View(Task.Run(() => pxa.GetAllConductores()).Result);
        }


        public ActionResult editarConductor(int id)
        {
            EConductor p = new EConductor();
            p.Id = id;
            return View(p);
        }

        [HttpPost]
        public ActionResult editarConductor(EConductor conductor)
        {
            pxa.editarConductor(conductor);
            return RedirectToAction("traerConductores");
        }

        //----------------------------reporte utilidad ------------------------------
        public ActionResult SelectreporteU()
        {
            return View();
        }

        public ActionResult reporteV()
        {
            Session["reporte"] = "v";
            return RedirectToAction("reporteUtilidad");
        }

        public ActionResult reporteS()
        {
            Session["reporte"] = "s";
            return RedirectToAction("reporteUtilidad");
        }

        public ActionResult reporteL()
        {
            Session["reporte"] = "l";
            return RedirectToAction("reporteUtilidad");
        }

        public ActionResult reporteUtilidad()
        {
            if (Session["reporte"].ToString() == "v") ViewBag.Message = "v";
            if (Session["reporte"].ToString() == "s") ViewBag.Message = "s";
            if (Session["reporte"].ToString() == "l") ViewBag.Message = "l";
            return View();
        }

        [HttpPost]
        public ActionResult reporteUtilidad(DTOUtilidad utilidad)
        {
            if (Session["reporte"].ToString() == "v")
            {
                utilidad.linea=-1;
                utilidad.salida=-1;
            }
            if (Session["reporte"].ToString() == "s")
            {
                utilidad.idViaje = -1;
                utilidad.linea = -1;
            }
            if (Session["reporte"].ToString() == "l")
            {
                utilidad.idViaje = -1;
                utilidad.salida = -1;
            }

            if (utilidad.fechaDesde == null) utilidad.fechaDesde = "1900,01,01";
            if (utilidad.fechaHasat == null) utilidad.fechaHasat = "1900,01,01";
            DTOUtilidadFinal ut = new DTOUtilidadFinal();
            float result = Task.Run(() => pxa.reporteUtilidad(utilidad)).Result;
            ut.Valor = result*100;
            return RedirectToAction("verUtilidad", ut);


        }


        public ActionResult verUtilidad(DTOUtilidadFinal result)
        {
            return View(result);
        }


        //-----------------------------reporte pasaje -------------------------------

        public ActionResult selectRepP()
        {
            return View();
        }

        public ActionResult reportePV()
        {
            Session["reporteP"] = "v";
            return RedirectToAction("reportePasaje");
        }

        public ActionResult reportePS()
        {
            Session["reporteP"] = "s";
            return RedirectToAction("reportePasaje");
        }

        public ActionResult reportePL()
        {
            Session["reporteP"] = "l";
            return RedirectToAction("reportePasaje");
        }
        public ActionResult reportePasaje()
        {
            if (Session["reporteP"].ToString() == "v") ViewBag.Message = "v";
            if (Session["reporteP"].ToString() == "s") ViewBag.Message = "s";
            if (Session["reporteP"].ToString() == "l") ViewBag.Message = "l";
            return View();
        }

        [HttpPost]
        public ActionResult reportePasaje(DTOreportePasaje repoPasaje)
        {
            if (Session["reporteP"].ToString() == "v")
            {
                repoPasaje.linea = -1;
                repoPasaje.salida = -1;
            }
            if (Session["reporteP"].ToString() == "s")
            {
                repoPasaje.viaje = -1;
                repoPasaje.linea = -1;
            }
            if (Session["reporteP"].ToString() == "l")
            {
                repoPasaje.viaje = -1;
                repoPasaje.salida = -1;
            }
            List<EPasaje> result = Task.Run(() => pxa.reportedePasaje(repoPasaje)).Result;
            return View("verReportePasaje", result);
        }


    }
}