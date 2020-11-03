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
using System.Web.Mvc.Ajax;

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
                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    Console.WriteLine();
                }
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

        public void crearViajes(DTOCrearViajes viajes)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl + "crear/viajes");
                var postTask = client.PostAsJsonAsync<DTOCrearViajes>("viajes", viajes);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    Console.WriteLine();
                }
            }
        }

        public void editarViaje(DTOViaje viaje)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                var putTask = client.PutAsJsonAsync($"editar/viajes/{viaje.IdViaje}", viaje);
                putTask.Wait();
                //var result = putTask.Result;
            }
        }
        //-------------------------------------paradas---------------------------------------

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
        public void crearParada(DTOParada DTOparada)
        {
            EParada parada = new EParada();
            parada.IdParada = DTOparada.IdParada;
            parada.Nombre = DTOparada.Nombre;
          
            parada.Lat = double.Parse(DTOparada.Lat);
            parada.Long = double.Parse(DTOparada.Long);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl + "crear/parada");
                var postTask = client.PostAsJsonAsync<EParada>("parada", parada);
                postTask.Wait();
                var result = postTask.Result;
            }
        }
        /*

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
        */

        //-------------------------------------lineas---------------------------------------
        public async Task<List<ELinea>> GetAllLineas()
        {
            List<ELinea> eLineas = new List<ELinea>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("traer/linea");

                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    eLineas = JsonConvert.DeserializeObject<List<ELinea>>(EmpResponse);
                }
                return eLineas;
            }
        }
    
         /*

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
 */

        //----------------------------tramo---------------------NO FUNCIONA____#####___###
        public async Task<List<ETramo>> GetAllTramos()
        {
            List<ETramo> eTramos = new List<ETramo>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("traer/tramo");

                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    eTramos = JsonConvert.DeserializeObject<List<ETramo>>(EmpResponse);
                }
                return eTramos;
            }
        }
        /*
 public void crearViajes(DTOCrearViajes viaje)
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
 */

        //-----------------------------Salida------------------------------------------
        

               public async Task<List<ESalida>> GetAllSalida()
        {
            List<ESalida> eSalida = new List<ESalida>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("traer/salida");

                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    eSalida = JsonConvert.DeserializeObject<List<ESalida>>(EmpResponse);
                }
                return eSalida;
            }
        }
        /*
 public void crearViajes(DTOCrearViajes viaje)
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
 */

    }
}