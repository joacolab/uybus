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
            return View("traerVehiculos");
        }

        [HttpPost]
        public ActionResult crearVehiculo(EVehiculo vehiculo)
        {
            return View(pxa.crearVehiculo(vehiculo));
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

        /*
         *      public ActionResult crearVehiculo()
        {
            return View("traerVehiculos");
        }

        [HttpPost]
        public ActionResult crearVehiculo(EVehiculo vehiculo)
        {
            return View(pxa.crearVehiculo(vehiculo));
        }

        
        public ActionResult editarVehiculo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult editarVehiculo(EVehiculo vehiculo)
        {
            pxa.editarVehiculo(vehiculo);
            return RedirectToAction("traerVehiculos");
        }
         */

        //-----------------------------parada---------------------------------
        public ActionResult traerParadas()
        {
            return View(Task.Run(() => pxa.GetAllParada()).Result);
        }

        /*
        *      public ActionResult crearVehiculo()
        {
            return View("traerVehiculos");
        }

        [HttpPost]
        public ActionResult crearVehiculo(EVehiculo vehiculo)
        {
            return View(pxa.crearVehiculo(vehiculo));
        }


        public ActionResult editarVehiculo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult editarVehiculo(EVehiculo vehiculo)
        {
            pxa.editarVehiculo(vehiculo);
            return RedirectToAction("traerVehiculos");
        }
        */
        //-------------------------------linea----------------------------------------

        public ActionResult traerLinea()
        {
            return View(Task.Run(() => pxa.GetAllLineas()).Result);
        }
        /*
*      public ActionResult crearVehiculo()
{
    return View("traerVehiculos");
}

[HttpPost]
public ActionResult crearVehiculo(EVehiculo vehiculo)
{
    return View(pxa.crearVehiculo(vehiculo));
}


public ActionResult editarVehiculo()
{
    return View();
}

[HttpPost]
public ActionResult editarVehiculo(EVehiculo vehiculo)
{
    pxa.editarVehiculo(vehiculo);
    return RedirectToAction("traerVehiculos");
}
*/
        //----------------------------tramo-------------------------------------------
        public ActionResult traerTramo()
        {
            return View(Task.Run(() => pxa.GetAllTramos().Result));
        }
        /*
*      public ActionResult crearVehiculo()
{
    return View("traerVehiculos");
}

[HttpPost]
public ActionResult crearVehiculo(EVehiculo vehiculo)
{
    return View(pxa.crearVehiculo(vehiculo));
}


public ActionResult editarVehiculo()
{
    return View();
}

[HttpPost]
public ActionResult editarVehiculo(EVehiculo vehiculo)
{
    pxa.editarVehiculo(vehiculo);
    return RedirectToAction("traerVehiculos");
}
*/

        //-----------------------------Salida------------------------------------------

        public ActionResult traerSalida()
        {
            return View(Task.Run(() => pxa.GetAllSalida().Result));
        }
                /*
        *      public ActionResult crearVehiculo()
        {
            return View("traerVehiculos");
        }

        [HttpPost]
        public ActionResult crearVehiculo(EVehiculo vehiculo)
        {
            return View(pxa.crearVehiculo(vehiculo));
        }


        public ActionResult editarVehiculo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult editarVehiculo(EVehiculo vehiculo)
        {
            pxa.editarVehiculo(vehiculo);
            return RedirectToAction("traerVehiculos");
        }
        */  

    }
}