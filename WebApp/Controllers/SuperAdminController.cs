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
    [Autorizacion(superadmin = true)]
    public class SuperAdminController : Controller
    {
        //private ProxyAdmin pxa = new ProxyAdmin();

        private ProxySuperAdmin pxsa = new ProxySuperAdmin();
        // GET: SuperAdmin
        public ActionResult Index()
        {
            if (Session["pNombre"] != null && Session["pApellido"] != null)
            {
                ViewBag.nombreUsu = Session["pNombre"].ToString() + " " + Session["pApellido"].ToString();
            }
            return View();
        }

        
        public ActionResult traerPersonas()
        {
          return View(Task.Run(() => pxsa.GetAllPersonas(Session["tokenJWT"].ToString())).Result);
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

            pxsa.asignarRol(per, Session["tokenJWT"].ToString());
            return RedirectToAction("traerPersonas");
        }

        //---------------------------ubicarvehiculo-----------------------------


        public ActionResult traerVehiculos()
        {

            ViewBag.ListaParada = Task.Run(() => pxsa.GetAllParada(Session["tokenJWT"].ToString())).Result;
            List<DTOubicacion> ubics = Task.Run(() => pxsa.ubicarVehiculo(Session["tokenJWT"].ToString())).Result;

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