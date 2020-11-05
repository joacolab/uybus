using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace WebApp.Proxys
{
    public class ProxyInvitado
    {
        public string Baseurl = "https://localhost:44330/invitado/";



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
    }
}
