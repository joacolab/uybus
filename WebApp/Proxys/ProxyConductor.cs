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
    public class ProxyConductor
    {
        public string Baseurl = ConfigurationManager.AppSettings["baseURL"] + "/conductor/";

        //public string Baseurl = "https://localhost:44330/conductor/";

        public DTOnextBus llegada(DTOLegada llegada, string tokenJWT)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJWT);
                string URLespecial = ConfigurationManager.AppSettings["baseURL"] + "/general/llegada";
                var response = client.PostAsJsonAsync(URLespecial, llegada).Result;
                DTOnextBus returnValue = response.Content.ReadAsAsync<DTOnextBus>().Result;
                return returnValue;
            }

        }

        public async Task<List<EViaje>> getAllViajes(string tokenJWT)
        {
            List<EViaje> eViajes = new List<EViaje>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJWT);
                HttpResponseMessage Res = await client.GetAsync("traer/viajes");

                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    eViajes = JsonConvert.DeserializeObject<List<EViaje>>(EmpResponse);
                }
                return eViajes;
            }
        }
        public void iniciarViaje(int IdViaje, string HoraInicioReal, string tokenJWT)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJWT);
                var putTask = client.PutAsJsonAsync($"iniciar-viaje/{IdViaje}", HoraInicioReal);
                putTask.Wait();
                var result = putTask.Result;
            }
        }

        public async Task<List<EParada>> GetAllParada(string tokenJWT)
        {
            List<EParada> eParada = new List<EParada>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJWT);
                HttpResponseMessage Res = await client.GetAsync("traer/paradas");

                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    eParada = JsonConvert.DeserializeObject<List<EParada>>(EmpResponse);
                }
                return eParada;
            }
        }

        public async Task<bool> verificarPasaje(int idPasaje, int idParada, string tokenJWT)
        {
            bool resp = false;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJWT);
                HttpResponseMessage Res = await client.GetAsync("verifiacer-pasaje/" + idPasaje +"/" + idParada);

                if (Res.IsSuccessStatusCode)
                {
                    var respuesta = Res.Content.ReadAsStringAsync().Result;
                    resp = JsonConvert.DeserializeObject<bool>(respuesta);
                }
                return resp;
            }
        }

    }
}