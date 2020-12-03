using Share.DTOs;
using Share.entities;
using Share.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Proxys;

namespace WebApp.Controllers
{
    [HandleError]
    public class InvitadoController : Controller
    {
        private ProxyInvitado pxi = new ProxyInvitado();
        private ProxyGeneral pxg = new ProxyGeneral();
        // GET: Invitado
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult registrarse()
        {
            return View();
        }

        [HttpPost]
        public ActionResult registrarse(DTORegistro persona)
        {
            EPersona per = new EPersona();
            per.id = persona.id;
            per.Documento = persona.Documento;
            per.Correo = persona.Correo;
            per.Password = persona.Password;
            per.TipoDocumento = (int)persona.TipoDocumento;
            per.pNombre = persona.pNombre;
            per.sNombre = persona.sNombre;
            per.pApellido = persona.pApellido;
            per.sApellido = persona.sApellido;


            if (pxi.existEmail(persona.Correo))
            {
                ViewBag.Message = "El correo ya existe.";
                return View();
            }
            else
            {
                pxi.crearPersona(per);
                //return RedirectToAction("Index");

                DTOLogin log = new DTOLogin();

                log.email = persona.Correo;
                log.password = persona.Password;
                log.rol = "Usuario";
                EPersona res = pxg.iniciarSesion(log);

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

                return RedirectToAction("Index", "usuario");
            }

        }



        
    }
}
