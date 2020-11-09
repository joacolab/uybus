using Newtonsoft.Json;
using Share.DTOs;
using Share.entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.WebSockets;
using WebApp.Proxys;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private ProxyGeneral pxg = new ProxyGeneral();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(DTOLogForm logf)
        {
            DTOLogin log = new DTOLogin();

            log.email = logf.email;
            log.password = logf.password;
            log.rol = logf.rol.ToString();

            /*DTOLogin log = new DTOLogin();
            log.email = "ConductorGuille@gmail.com";
            log.password = "1234";
            log.rol = "Conductor";*/

            bool res = pxg.iniciarSesion(log);
            if (!res)
            {
                ViewBag.Message = "Usuario no registrado";
                return View();
            }
            else
            {

                return View("Index");
            }
        }


        public RedirectToRouteResult Admin()
        {
            return RedirectToAction("Index", "Admin");
        }
        public RedirectToRouteResult Invitado()
        {
            return RedirectToAction("Index", "invitado");
        }
        public RedirectToRouteResult superAdmin()
        {
            return RedirectToAction("Index", "superAdmin");
        }

        public RedirectToRouteResult usuario()
        {
            return RedirectToAction("Index", "usuario");
        }

        public RedirectToRouteResult conductor()
        {
            return RedirectToAction("Index", "conductor");
        }






        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }





        /*
        //Hosted web API REST Service base url  
        string Baseurl = "https://localhost:44330/admin/";
        public async Task<ActionResult> Index()
        {
            List<EVehiculo> EmpInfo = new List<EVehiculo>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("traer/vehiculos");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    EmpInfo = JsonConvert.DeserializeObject<List<EVehiculo>>(EmpResponse);

                }
                //returning the employee list to view  
                return View(EmpInfo);
            }
        }
        
        public ActionResult nuevoVehiculo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult nuevoVehiculo(EVehiculo vehiculo)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44330/admin/crear/vehiculo");
                var postTask = client.PostAsJsonAsync<EVehiculo>("vehiculo", vehiculo);
                postTask.Wait();
                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Error, contactese con el administrador (Juan)");
            return View(vehiculo);
        }

        
        public ActionResult editarVehiculo()
        {
            return View();
        }
        

        /*
        public ActionResult editarVehiculo(string matricula)
        {
            EVehiculo vehiculo = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44330/admin/editar/vehiculo");
                var responeTask = client.GetAsync(matricula);
                responeTask.Wait();
                var result = responeTask.Result;
                if(result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<EVehiculo>();
                    readTask.Wait();
                    vehiculo = readTask.Result;
                }
            }
            return View(vehiculo);
        }
        */

        /*
        [HttpPost] //igual usamos Post aunnque sea put
        public ActionResult editarVehiculo(EVehiculo vehiculo)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44330/");
                var putTask = client.PutAsJsonAsync($"admin/editar/vehiculo/{vehiculo.Matricula}", vehiculo);
                putTask.Wait();
                var result = putTask.Result;
                if(result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(vehiculo);
        }
        
        */
    }
}