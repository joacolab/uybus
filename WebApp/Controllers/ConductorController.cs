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
    public class ConductorController : Controller
    {
        private ProxyConductor pxc = new ProxyConductor();

        public ActionResult Index()
        {
            if (Session["pNombre"] != null && Session["pApellido"] != null)
            {
                ViewBag.nombreUsu = Session["pNombre"].ToString() + " " + Session["pApellido"].ToString();
            }
            return View();
        }
        //-------llegada----------
        public ActionResult lstViajes()
        {
            List<EViaje> viajes = Task.Run(() => pxc.getAllViajes()).Result;
            List<EViaje> iniciados = new List<EViaje>();
            foreach (var viaje in viajes)
            {
                if((viaje.Finalizado==0 || viaje.Finalizado == null) && viaje.HoraInicioReal!=null) // si esta iniciado y no esta finalizado
                {
                    iniciados.Add(viaje);
                }
            }
            return View(iniciados);
        }

        public ActionResult ingresarHF(int id)
        {
            DTOLegada lleg = new DTOLegada();
            lleg.idViaje = id;
            return View(lleg);

        }

        [HttpPost]
        public ActionResult ingresarHF(DTOLegada llegada)
        {
            pxc.llegada(llegada);
            return RedirectToAction("lstViajes");
        }

        //-------iniciar viaje----------
        public ActionResult traerViajes()
        {
            List<EViaje> viajes = Task.Run(() => pxc.getAllViajes()).Result;
            List<EViaje> retorno = new List<EViaje>();
            foreach (var v in viajes)
            {
                if (v.HoraInicioReal==null)
                {
                    retorno.Add(v);
                }
            }
            return View(retorno);
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