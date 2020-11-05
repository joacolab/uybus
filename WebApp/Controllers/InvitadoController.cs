using Share.DTOs;
using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Proxys;

namespace WebApp.Controllers
{
    public class InvitadoController : Controller
    {
        private ProxyInvitado pxi = new ProxyInvitado();
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

            pxi.crearPersona(per);
            return RedirectToAction("Index");
        }



        
    }
}
