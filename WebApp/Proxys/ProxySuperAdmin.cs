using Newtonsoft.Json;
using Share.DTOs;
using Share.entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace WebApp.Proxys
{
    public class ProxySuperAdmin
    {
        public string Baseurl = ConfigurationManager.AppSettings["baseURL"] + "/super-admin/";
        //public string Baseurl = "https://localhost:44330/super-admin/";


        public async Task<List<EPersona>> GetAllPersonas()
        {
            List<EPersona> ePersona = new List<EPersona>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("traer/Personas");

                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    ePersona = JsonConvert.DeserializeObject<List<EPersona>>(EmpResponse);
                }
                return ePersona;
            }
        }

        public void asignarRol(DTOPersonaRol persona)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                var putTask = client.PutAsJsonAsync($"asignar-rol/{persona.idPersona}", persona);
                putTask.Wait();
                var result = putTask.Result;
            }
        }




        public async Task<List<DTOubicacion>> ubicarVehiculo()
        {
            List<DTOubicacion> ubicaciones = new List<DTOubicacion>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("ubicarVehiculo");

                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    ubicaciones = JsonConvert.DeserializeObject<List<DTOubicacion>>(EmpResponse);
                }
                return ubicaciones;
            }
        }

        



    }
}