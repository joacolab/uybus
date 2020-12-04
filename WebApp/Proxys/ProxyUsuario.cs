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
    public class ProxyUsuario
    {
        public string Baseurl = ConfigurationManager.AppSettings["baseURL"] + "/usuario/";
        //public string Baseurl = "https://localhost:44330/usuario/";

        public async Task<List<ELinea>> listarLineas(string tokenJWT)
        {
            List<ELinea> elineas = new List<ELinea>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJWT);
                HttpResponseMessage Res = await client.GetAsync("listar/lineas");

                if (Res.IsSuccessStatusCode)
                {
                    var respuesta = Res.Content.ReadAsStringAsync().Result;
                    elineas = JsonConvert.DeserializeObject<List<ELinea>>(respuesta);
                }
                return elineas;
            }
        }

        public async Task<List<EParada>> listarParadasOrigen(int IdLinea, string tokenJWT)
        {
            List<EParada> eparada = new List<EParada>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJWT);
                HttpResponseMessage Res = await client.GetAsync("listar/paradas/"+ IdLinea);

                if (Res.IsSuccessStatusCode)
                {
                    var respuesta = Res.Content.ReadAsStringAsync().Result;
                    eparada = JsonConvert.DeserializeObject<List<EParada>>(respuesta);
                }
                return eparada;
            }
        }

        public async Task<List<EParada>> listarParadasDestino(int IdLinea, int IdParada, string tokenJWT)
        {
            List<EParada> eparada = new List<EParada>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJWT);
                HttpResponseMessage Res = await client.GetAsync("listar/pdestino/" + IdLinea +"/"+ IdParada);

                if (Res.IsSuccessStatusCode)
                {
                    var respuesta = Res.Content.ReadAsStringAsync().Result;
                    eparada = JsonConvert.DeserializeObject<List<EParada>>(respuesta);
                }
                return eparada;
            }
        }

        public async Task<List<ESalida>> listarSalidas(int IdLinea, string tokenJWT)
        {
            List<ESalida> esalida = new List<ESalida>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJWT);
                HttpResponseMessage Res = await client.GetAsync("listar/salidas/" + IdLinea);

                if (Res.IsSuccessStatusCode)
                {
                    var respuesta = Res.Content.ReadAsStringAsync().Result;
                    esalida = JsonConvert.DeserializeObject<List<ESalida>>(respuesta);
                }
                return esalida;
            }
        }

        public async Task<List<EViaje>> listarViajes(int IdSalida, string tokenJWT)
        {
            List<EViaje> eviaje = new List<EViaje>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJWT);
                HttpResponseMessage Res = await client.GetAsync("listar/viajes/" + IdSalida);

                if (Res.IsSuccessStatusCode)
                {
                    var respuesta = Res.Content.ReadAsStringAsync().Result;
                    eviaje = JsonConvert.DeserializeObject<List<EViaje>>(respuesta);
                }
                return eviaje;
            }
        }

        public async Task<bool> canSelectSeat(int IdLinea, int IdParadaOrigen, int IdParadaDestino, string tokenJWT)
        {
            bool canAsientos = false;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJWT);
                HttpResponseMessage Res = await client.GetAsync("asiento/" + IdLinea + "/" + IdParadaOrigen  + "/" + IdParadaDestino );

                if (Res.IsSuccessStatusCode)
                {
                    var respuesta = Res.Content.ReadAsStringAsync().Result;
                    canAsientos = JsonConvert.DeserializeObject<bool>(respuesta);
                }
                return canAsientos;
            }
        }

        public async Task<List<int>> listarAsientos(int idViaje, string tokenJWT)
        {
            List<int> asientos = new List<int>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJWT);
                HttpResponseMessage Res = await client.GetAsync("listar/asientos/" + idViaje);

                if (Res.IsSuccessStatusCode)
                {
                    var respuesta = Res.Content.ReadAsStringAsync().Result;
                    asientos = JsonConvert.DeserializeObject<List<int>>(respuesta);
                }
                return asientos;
            }
        }

        public async Task<int> costoPasaje(int IdLinea, int IdParadaOrigen, int IdParadaDestino, string tokenJWT)
        {
            int costo= 0;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJWT);
                HttpResponseMessage Res = await client.GetAsync("precio/" + IdLinea +"/"+ IdParadaOrigen+"/"+ IdParadaDestino);

                if (Res.IsSuccessStatusCode)
                {
                    var respuesta = Res.Content.ReadAsStringAsync().Result;
                    costo = JsonConvert.DeserializeObject<int>(respuesta);
                }
                return costo;
            }
        }

        public void comprarPasaje(DTOComprarPasaje comprar, string tokenJWT)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl + "comprar");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJWT);
                var postTask = client.PostAsJsonAsync<DTOComprarPasaje>("comprar", comprar);
                postTask.Wait();
                var result = postTask.Result;
            }
        }


        //----------------------proximo vehiculo-------------------
        public async Task<List<EParada>> sinterminal(string tokenJWT)
        {
            List<EParada> eparada = new List<EParada>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJWT);
                HttpResponseMessage Res = await client.GetAsync("sinterminal");

                if (Res.IsSuccessStatusCode)
                {
                    var respuesta = Res.Content.ReadAsStringAsync().Result;
                    eparada = JsonConvert.DeserializeObject<List<EParada>>(respuesta);
                }
                return eparada;
            }
        }
        public async Task<List<DTOproxVehiculo>> proximoVehiculo(int IdUsuario, int IdParada, string tokenJWT)
        {
            List<DTOproxVehiculo> lstVeiculosProximos = new List<DTOproxVehiculo>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJWT);
                HttpResponseMessage Res = await client.GetAsync("proximos/" + IdUsuario + "/" + IdParada );

                if (Res.IsSuccessStatusCode)
                {
                    var respuesta = Res.Content.ReadAsStringAsync().Result;
                    lstVeiculosProximos = JsonConvert.DeserializeObject<List<DTOproxVehiculo>>(respuesta);
                }
                return lstVeiculosProximos;
            }
        }


    }
}