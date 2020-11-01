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
    public class ProxyAdmin
    {
        public string Baseurl = "https://localhost:44330/admin/";

        //-----------------------------Vehiculo----------------------------------
        public async Task<List<EVehiculo>> getAllVehiculos()
        {
            List<EVehiculo> eVehiculos = new List<EVehiculo>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("traer/vehiculos");

                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    eVehiculos = JsonConvert.DeserializeObject<List<EVehiculo>>(EmpResponse);
                }
                return eVehiculos;
            }
        }

        public EVehiculo crearVehiculo(EVehiculo vehiculo)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl + "crear/vehiculo");
                var postTask = client.PostAsJsonAsync<EVehiculo>("vehiculo", vehiculo);
                postTask.Wait();
                var result = postTask.Result;
            }
            return vehiculo;
        }

        public EVehiculo editarVehiculo(EVehiculo vehiculo)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                var putTask = client.PutAsJsonAsync($"editar/vehiculo/{vehiculo.Matricula}", vehiculo);
                putTask.Wait();
                //var result = putTask.Result;
            }
            return vehiculo;
        }

        //-----------------------------Viaje----------------------------------
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

        public void  crearViajes(DTOCrearViajes viaje)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl + "crear/viajes");
                var postTask = client.PostAsJsonAsync<DTOCrearViajes>("viaje", viaje);
                postTask.Wait();
                var result = postTask.Result;
            }
        }

        public void editarVehiculo(DTOViaje viaje)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                var putTask = client.PutAsJsonAsync($"editar/viajes/{viaje.IdViaje}", viaje);
                putTask.Wait();
                //var result = putTask.Result;
            }
        }
        //---------------------------------------------------------------------------------------------


    }
}