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
using System.Web.Mvc.Ajax;

namespace WebApp.Proxys
{
    public class ProxyAdmin
    {
        public string Baseurl = ConfigurationManager.AppSettings["baseURL"] + "/admin/";
        //public string Baseurl = "https://localhost:44330/admin/";

        //-----------------------------Vehiculo----------------------------------
        public async Task<List<EVehiculo>> getAllVehiculos(string tokenJWT)
        {
            List<EVehiculo> eVehiculos = new List<EVehiculo>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJWT);
                HttpResponseMessage Res = await client.GetAsync("traer/vehiculos");

                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    eVehiculos = JsonConvert.DeserializeObject<List<EVehiculo>>(EmpResponse);
                }
                return eVehiculos;
            }
        }

        public EVehiculo crearVehiculo(EVehiculo vehiculo, string tokenJWT)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl + "crear/vehiculo");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJWT);
                var postTask = client.PostAsJsonAsync<EVehiculo>("vehiculo", vehiculo);
                postTask.Wait();
                var result = postTask.Result;
            }
            return vehiculo;
        }

        public EVehiculo editarVehiculo(EVehiculo vehiculo, string tokenJWT)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJWT);
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

        public void crearViajes(DTOCrearViajes viajes, string tokenJWT)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl + "crear/viajes");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJWT);
                var postTask = client.PostAsJsonAsync<DTOCrearViajes>("viajes", viajes);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    Console.WriteLine();
                }
            }
        }

        public void editarViaje(DTOViaje viaje, string tokenJWT)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJWT);
                var putTask = client.PutAsJsonAsync($"editar/viaje/{viaje.IdViaje}", viaje);
                putTask.Wait();
                var result = putTask.Result;
            }
        }
        //-------------------------------------paradas---------------------------------------

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
        public EParada crearParada(DTOParada DTOparada, string tokenJWT)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl + "crear/parada");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJWT);
                var postTask = client.PostAsJsonAsync<DTOParada>("parada", DTOparada);
                postTask.Wait();
                var result = postTask.Result;

                return result.Content.ReadAsAsync<EParada>().Result;
            }
        }
        

        public void editarParada(DTOParada parada, string tokenJWT)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJWT);
                var putTask = client.PutAsJsonAsync($"editar/parada/{parada.IdParada}", parada);
                putTask.Wait();
                //var result = putTask.Result;
            }
        }


        //-------------------------------------lineas---------------------------------------
        public async Task<List<ELinea>> GetAllLineas(string tokenJWT)
        {
            List<ELinea> eLineas = new List<ELinea>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJWT);
                HttpResponseMessage Res = await client.GetAsync("traer/linea");

                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    eLineas = JsonConvert.DeserializeObject<List<ELinea>>(EmpResponse);
                }
                return eLineas;
            }
        }
 
         public ELinea crearLinea(DTOLinea linea, string tokenJWT)
         {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl + "crear/linea");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJWT);
                var postTask = client.PostAsJsonAsync<DTOLinea>("linea", linea);
                postTask.Wait();
                var result = postTask.Result;

                return result.Content.ReadAsAsync<ELinea>().Result;
            }
            
         }



        
        public void editarLinea(DTOLinea linea, string tokenJWT)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJWT);
                var putTask = client.PutAsJsonAsync($"editar/linea/{linea.IdLinea}", linea.Nombre);
                putTask.Wait();
                //var result = putTask.Result;
            }
        }
        

        //----------------------------tramo---------------------NO FUNCIONA____#####___###
        public async Task<List<ETramo>> GetAllTramos(string tokenJWT)
        {
            List<ETramo> eTramos = new List<ETramo>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJWT);
                HttpResponseMessage Res = await client.GetAsync("traer/tramo");

                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    eTramos = JsonConvert.DeserializeObject<List<ETramo>>(EmpResponse);
                }
                return eTramos;
            }
        }
    
         public ETramo crearTramo(DTOTramoPrecio tramo, string tokenJWT)
         {
             using (var client = new HttpClient())

             {
                 client.BaseAddress = new Uri(Baseurl + "crear/tramo");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJWT);
                var postTask = client.PostAsJsonAsync< DTOTramoPrecio> ("tramo", tramo);
                 postTask.Wait();
                 var result = postTask.Result;

                return result.Content.ReadAsAsync<ETramo>().Result;
            }
         }
        

         public void editarTramo(DTOTramo tramo, string tokenJWT)
         {
             using (var client = new HttpClient())
             {
                 client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJWT);
                var putTask = client.PutAsJsonAsync($"editar/linea/{tramo.IdLinea}/{tramo.IdParada}", tramo);
                 putTask.Wait();
                 //var result = putTask.Result;
             }
         }
         

        //-----------------------------Salida------------------------------------------


        public async Task<List<ESalida>> GetAllSalida(string tokenJWT)
        {
            List<ESalida> eSalida = new List<ESalida>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJWT);
                HttpResponseMessage Res = await client.GetAsync("traer/salida");

                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    eSalida = JsonConvert.DeserializeObject<List<ESalida>>(EmpResponse);
                }
                return eSalida;
            }
        }
        
         public void crearSalida(DTOSalida salida, string tokenJWT)
         {
             using (var client = new HttpClient())
             {
                 client.BaseAddress = new Uri(Baseurl + "crear/salida");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJWT);
                var postTask = client.PostAsJsonAsync<DTOSalida>("salida", salida);
                 postTask.Wait();
                 var result = postTask.Result;
             }
         }
        
         public void editarSalida(DTOSalida salida, string tokenJWT)
         {
             using (var client = new HttpClient())
             {
                 client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJWT);
                var putTask = client.PutAsJsonAsync($"editar/salida/{salida.IdSalida}",salida);
                 putTask.Wait();
                 //var result = putTask.Result;
             }
         }
        //-----------------------------Asignar Fecha Libreta Conductor------------------------------------------


        public async Task<List<EConductor>> GetAllConductores(string tokenJWT)
        {
            List<EConductor> eConductor = new List<EConductor>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJWT);
                HttpResponseMessage Res = await client.GetAsync("traer/Conductores");

                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    eConductor = JsonConvert.DeserializeObject<List<EConductor>>(EmpResponse);
                }
                return eConductor;
            }
        }
        public void editarConductor(EConductor conductor, string tokenJWT)
        {
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJWT);
                var putTask = client.PutAsJsonAsync($"editar/conductor/{conductor.Id}", conductor.VencimientoLicencia.ToString());
                putTask.Wait();
                //var result = putTask.Result;
            }
        }
        //------------------------------------Reporte Utilidad-------------------------------------


        public async Task<float> reporteUtilidad(DTOUtilidad reporteUtilidad, string tokenJWT)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl + "reporteUtilidad");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJWT);
                var postTask = await client.PostAsJsonAsync<DTOUtilidad>("reporteUtilidad", reporteUtilidad);
                return await postTask.Content.ReadAsAsync<float>();
            }
        }
        //------------------------------------Reporte de pasajes------------------------------------
        public async Task<List<EPasaje>> reportedePasaje(DTOreportePasaje reportePasaje, string tokenJWT)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl + "reportePasaje");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJWT);
                var postTask = await client.PostAsJsonAsync<DTOreportePasaje>("reportePasaje", reportePasaje);
                return await postTask.Content.ReadAsAsync<List<EPasaje>>();
            }
        }


    }
}