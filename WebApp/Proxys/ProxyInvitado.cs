using Share.entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace WebApp.Proxys
{
    public class ProxyInvitado
    {
        public string Baseurl = ConfigurationManager.AppSettings["baseURL"] + "/invitado/";
        //public string Baseurl = "https://localhost:44330/invitado/";

        public bool existEmail(string correo)
        {
            using (var client = new HttpClient())
            {
                var response = client.PostAsJsonAsync(Baseurl + "verificar", correo).Result;
                bool returnValue = response.Content.ReadAsAsync<bool>().Result;
                return returnValue;
            }
        }

        public void crearPersona(EPersona registrarse)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl + "registrarse");
                var postTask = client.PostAsJsonAsync<EPersona>("registrarse", registrarse);
                postTask.Wait();
                var result = postTask.Result;
            }
        }
        //------------------------------iniciar sesion (correo , password)-------
        //-----------------------------devuelve : todos los datos del usuario mas el rol
    }
}
