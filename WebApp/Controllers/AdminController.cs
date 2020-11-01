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

        public ActionResult traerVehiculos()
        {
            return View(Task.Run(() => pxa.getAllVehiculos()).Result);
        }

        public ActionResult crearVehiculo(EVehiculo vehiculo)
        {
            return View(pxa.crearVehiculo(vehiculo));
        }

        public ActionResult editarVehiculo(EVehiculo vehiculo)
        {
            return View(pxa.editarVehiculo(vehiculo));
            //return RedirectToAction("Index");
        }
    }
}