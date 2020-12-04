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
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.WebSockets;
using WebApp.Autorisacion;
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

        [Autorizacion(logeado = false)]
        public ActionResult Login()
        {
            return View();
        }

        [Autorizacion(logeado = false)]
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

            string source = logf.password;

            using (SHA256 sha256Hash = SHA256.Create())
            {
                string hash = GetHash(sha256Hash, source);
                log.password = hash;
            }

            log.rol = logf.rol.ToString();

            DTOEpToken res = pxg.iniciarSesion(log);
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
                    Session["Password"] = res.Password; //ojo que es "null"
                    Session["tokenJWT"] = res.tokenJWT; //cargo el token

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
        private static string GetHash(HashAlgorithm hashAlgorithm, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
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