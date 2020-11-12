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
    public class SuperAdminController : Controller
    {

        private ProxySuperAdmin pxsa = new ProxySuperAdmin();
        // GET: SuperAdmin
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult traerPersonas()
        {
          return View(Task.Run(() => pxsa.GetAllPersonas()).Result);
        }

        public ActionResult asignarRol(int id)
        {
            DTORolPersona per = new DTORolPersona();
            per.idPersona = id;
            return View(per);
        }

        [HttpPost]
        public ActionResult asignarRol(DTORolPersona persona)
        {
            DTOPersonaRol per = new DTOPersonaRol();
            per.idPersona = persona.idPersona;
            per.rol = (int)persona.rol;

            pxsa.asignarRol(per);
            return RedirectToAction("traerPersonas");
        }

        //---------------------------ubicarvehiculo-----------------------------


        public ActionResult traerVehiculos()
        {
            List<DTOubicacion> ubics = Task.Run(() => pxsa.ubicarVehiculo()).Result;

            double shift = 0.00001; //corrimineto
            foreach (var u in ubics)
            {
                u.lat = u.lat + shift;
                u.lon = u.lon + shift;
                shift = shift + shift;
            }

            return View(ubics);
        }



        





    }
}