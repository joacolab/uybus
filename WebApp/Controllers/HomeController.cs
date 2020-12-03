using Newtonsoft.Json;
using Share.DTOs;
using Share.entities;
using Share.enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.WebSockets;
using WebApp.Proxys;

namespace WebApp.Controllers
{
    [HandleError]

    public class HomeController : Controller
    {
        private ProxyGeneral pxg = new ProxyGeneral();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public RedirectToRouteResult registrarse()
        {
            return RedirectToAction("registrarse", "Invitado");
        }


        public ActionResult cerrarSesion()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Login(DTOLogForm logf)
        {
            Session.Clear();
            DTOLogin log = new DTOLogin();

            log.email = logf.email;
            log.password = logf.password;
            log.rol = logf.rol.ToString();

            EPersona res = pxg.iniciarSesion(log);
            if (res.pNombre=="Error")
            {
                ViewBag.Message = "Usuario no registrado";
                return View();
            }
            else
            {
                if (res.pNombre == "ErrorRol")
                {
                    ViewBag.Message = "Rol Incorrecto";
                    return View();
                }
                else
                {
                    Session["idPersona"] = res.id;
                    Session["pNombre"] = res.pNombre;
                    Session["sNombre"] = res.sNombre;
                    Session["pApellido"] = res.pApellido;
                    Session["sApellido"] = res.sApellido;
                    Session["Correo"] = res.Correo;
                    Session["Password"] = res.Password;

                    TipoDoc r = (TipoDoc)res.TipoDocumento;
                    Session["TipoDocumento"] = r.ToString();

                    Session["Documento"] = res.Documento;
                    Session["Rol"] = log.rol;

                    if (log.rol=="Admin")
                    {
                        return RedirectToAction("admin");
                    }
                    if (log.rol == "SuperAdmin")
                    {
                        return RedirectToAction("superAdmin");
                    }
                    if (log.rol== "Usuario")
                    {
                        return RedirectToAction("usuario");
                    }
                    if (log.rol == "Conductor")
                    {
                        return RedirectToAction("conductor");
                    }
                    return RedirectToAction("Index");

                }
            }
        }

        
        public RedirectToRouteResult Admin()
        {
            return RedirectToAction("Index", "Admin");
        }
        public RedirectToRouteResult Invitado()
        {
            return RedirectToAction("Index", "invitado");
        }
        public RedirectToRouteResult superAdmin()
        {
            return RedirectToAction("Index", "superAdmin");
        }

        public RedirectToRouteResult usuario()
        {
            return RedirectToAction("Index", "usuario");
        }

        public RedirectToRouteResult conductor()
        {
            return RedirectToAction("Index", "conductor");
        }


    }
}