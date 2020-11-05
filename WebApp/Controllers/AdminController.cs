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

        
        public ActionResult crearParada()
        {
            return View();
        }

        [HttpPost]
        public ActionResult crearParada(DTOParada parada)
        {
            pxa.crearParada(parada);
            return RedirectToAction("traerParadas");
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
            pxa.crearLinea(linea);
            return RedirectToAction("traerLinea");
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
        
        //----------------------------tramo-------------------------------------------
        public ActionResult traerTramo()
        {
            return View(Task.Run(() => pxa.GetAllTramos()).Result);
        }
        
        public ActionResult crearTramo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult crearTramo(DTOTramoPrecio dtoTramoPrecio)
        {
            pxa.crearTramo(dtoTramoPrecio);
            return RedirectToAction("traerTramo");
        }

             
        public ActionResult editarTramo(int id, int id2)
        {
            DTOTramo p = new DTOTramo();
            p.IdLinea = id2;
            p.IdParada = id;
            return View(p);
        }

        [HttpPost]
        public ActionResult editarTramo(DTOTramo tramo)
        {
            pxa.editarTramo(tramo);
            return RedirectToAction("traerTramo");
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


        public ActionResult reporteUtilidad()
        {
            return View();
        }

        [HttpPost]
        public ActionResult reporteUtilidad(DTOUtilidad utilidad)
        {
         
            if (utilidad.fechaDesde == null) utilidad.fechaDesde = "1900,01,01";
            if (utilidad.fechaHasat == null) utilidad.fechaHasat = "1900,01,01";
            DTOUtilidadFinal ut = new DTOUtilidadFinal();
            float result = Task.Run(() => pxa.reporteUtilidad(utilidad)).Result;
            ut.Valor = result;
            return RedirectToAction("verUtilidad", ut);
        }


        public ActionResult verUtilidad(DTOUtilidadFinal result)
        {
            return View(result);
        }


        //-----------------------------reporte pasaje -------------------------------





    }
}