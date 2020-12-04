using Share.DTOs;
using Share.entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace WebApp.Proxys
{
    public class ProxyGeneral
    {
        public string Baseurl = ConfigurationManager.AppSettings["baseURL"] + "/general/";
        //public string Baseurl = "https://localhost:44330/general/";

        public DTOEpToken iniciarSesion(DTOLogin log)
        {
            
            using (var client = new HttpClient())
            {
                var task = client.PostAsJsonAsync(Baseurl + "login", log)
                         .ContinueWith(x => x.Result.Content.ReadAsAsync<DTOEpToken>().Result);
                task.Wait();
                return task.Result;

            }
            
        }
    }
}