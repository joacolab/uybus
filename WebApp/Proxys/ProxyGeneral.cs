using Share.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace WebApp.Proxys
{
    public class ProxyGeneral
    {
        public string Baseurl = "https://localhost:44330/general/";

        public bool iniciarSesion(DTOLogin log)
        {
            
            using (var client = new HttpClient())
            {
                var httpClient = new HttpClient();
                var task = httpClient.PostAsJsonAsync(Baseurl + "login", log)
                         .ContinueWith(x => x.Result.Content.ReadAsAsync<bool>().Result);
                task.Wait();
                bool response = task.Result;
                return response;

            }
            
        }
    }
}