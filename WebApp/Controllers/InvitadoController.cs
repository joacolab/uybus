using Share.DTOs;
using Share.entities;
using Share.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebApp.Autorisacion;
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

        [Autorizacion(logeado = false)]
        public ActionResult registrarse()
        {
            return View();
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

        [HttpPost]
        public ActionResult registrarse(DTORegistro persona)
        {
            EPersona per = new EPersona();
            per.id = persona.id;
            per.Documento = persona.Documento;
            per.Correo = persona.Correo;

            string source = persona.Password;

            using (SHA256 sha256Hash = SHA256.Create())
            {
                string hash = GetHash(sha256Hash, source);
                per.Password = hash;
            }





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
                log.password = per.Password;
                log.rol = "Usuario";
                DTOEpToken res = pxg.iniciarSesion(log);

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

                return RedirectToAction("Index", "usuario");
            }

        }



        
    }
}
