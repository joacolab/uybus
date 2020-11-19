using Newtonsoft.Json;
using Share.DTOs;
using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace WebApp.Proxys
{
    public class ProxyConductor
    {
        public string Baseurl = "https://localhost:44330/conductor/";


        public ELlegada llegada(DTOLegada llegada)
        {
            using (var client = new HttpClient())
            {
                var response = client.PostAsJsonAsync("https://localhost:44330/general/llegada", llegada).Result;
                ELlegada returnValue = response.Content.ReadAsAsync<ELlegada>().Result;
                return returnValue;
            }

        }

        public async Task<List<EViaje>> getAllViajes()
        {
            List<EViaje> eViajes = new List<EViaje>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("traer/viajes");

                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    eViajes = JsonConvert.DeserializeObject<List<EViaje>>(EmpResponse);
                }
                return eViajes;
            }
        }
        public void iniciarViaje(int IdViaje, string HoraInicioReal)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                var putTask = client.PutAsJsonAsync($"iniciar-viaje/{IdViaje}", HoraInicioReal);
                putTask.Wait();
                var result = putTask.Result;
            }
        }

        public async Task<List<EParada>> GetAllParada()
        {
            List<EParada> eParada = new List<EParada>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("traer/paradas");

                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    eParada = JsonConvert.DeserializeObject<List<EParada>>(EmpResponse);
                }
                return eParada;
            }
        }

        public async Task<bool> verificarPasaje(int idPasaje, int idParada)
        {
            bool resp = false;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
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