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
    public class ConductorController : Controller
    {
        private ProxyConductor pxc = new ProxyConductor();
        public ActionResult Index()
        {
            return View();
        }
        //-------iniciar viaje----------
        public ActionResult traerViajes()
        {
            return View(Task.Run(() => pxc.getAllViajes()).Result);
        }

        public ActionResult iniciarViaje(int id)
        {
            EViaje ev = new EViaje();
            ev.IdViaje = id;
            ev.HoraInicioReal = null;
            return View(ev);
        }

        [HttpPost]
        public ActionResult iniciarViaje(EViaje ev)
        {
            pxc.iniciarViaje(ev.IdViaje,ev.HoraInicioReal.ToString());
            return RedirectToAction("traerViajes");
        }

        //-------verificar pasaje -----------
        public ActionResult traerParadas()
        {
            return View(Task.Run(() => pxc.GetAllParada()).Result);
        }
        public ActionResult verificarP(int id)
        {
            EPasaje ep = new EPasaje();
            ep.IdParadaOrigen = id;
            return View(ep);
        }

        [HttpPost]
        public ActionResult verificarP(EPasaje ep)
        {
            Session["isValid"] = Task.Run(() => pxc.verificarPasaje(ep.IdPasaje, ep.IdParadaOrigen)).Result;
            return RedirectToAction("pasajeValido");
        }

        public ActionResult pasajeValido()
        {
            ViewBag.Message = (bool)Session["isValid"];
            return View();
        }



    }
}