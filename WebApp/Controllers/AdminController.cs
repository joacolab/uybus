using Share.DTOs;
using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApp.Proxys;

namespace WebApp.Controllers
{
    public class AdminController : Controller
    {
        private ProxyAdmin pxa = new ProxyAdmin();
        private static List<int> idPars = new List<int>();
        public ActionResult Index()
        {
            return View();
        }
        //---------------------------------------------------------------

        public ActionResult traerVehiculos()
        {
            return View(Task.Run(() => pxa.getAllVehiculos()).Result);
        }

        public ActionResult crearVehiculo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult crearVehiculo(EVehiculo vehiculo)
        {
            pxa.crearVehiculo(vehiculo);
            return RedirectToAction("traerVehiculos");
        }

        
        public ActionResult editarVehiculo(string id)
        {
            EVehiculo ev = new EVehiculo();
            ev.Matricula = id;
            return View(ev);
        }

        [HttpPost]
        public ActionResult editarVehiculo(EVehiculo vehiculo)
        {
            pxa.editarVehiculo(vehiculo);
            return RedirectToAction("traerVehiculos");
        }
        //------------------------VIAJES---------------------------------------
        public ActionResult traerViajes()
        {
            return View(Task.Run(() => pxa.getAllViajes()).Result);
        }

        
        public ActionResult crearViaje()
        {
            return View();
        }

        [HttpPost]
        public ActionResult crearViaje(DTOCrearViajes viajes)
        {
            pxa.crearViajes(viajes);
            return RedirectToAction("traerViajes");
        }

        
        public ActionResult editarViaje(int id)
        {
            DTOViaje ev = new DTOViaje();
            ev.IdViaje = id;
            return View(ev);
        }
        
        [HttpPost]
        public ActionResult editarViaje(DTOViaje viajes)
        {
            pxa.editarViaje(viajes);
            return RedirectToAction("traerViajes");
        }
        

        //-----------------------------parada---------------------------------
        public ActionResult traerParadas()
        {
            return View(Task.Run(() => pxa.GetAllParada()).Result);
        }



        public ActionResult crearParada()
        {
            ViewBag.errorNP = "";
            ViewBag.errorPP = "";
            return View();
        }

        [HttpPost]
        public ActionResult crearParada(DTOParada pa)
        {
            foreach (var parada in Task.Run(() => pxa.GetAllParada()).Result)
            {
                if (parada.Nombre == pa.Nombre)
                {
                    ViewBag.errorNP = "Ese nombre ya existe";
                    return View();
                }
                if (parada.Lat.ToString() == pa.Lat && parada.Long.ToString() == pa.Long)
                {
                    ViewBag.errorPP = "Ya existe una parada en esa posición.";
                    return View();
                }
            }

            pxa.crearParada(pa);
            return RedirectToAction("traerParadas");
        }



        public ActionResult editarParada(int id)
        {
            DTOParada p = new DTOParada();
            p.IdParada = id;
            return View(p);
        }

        [HttpPost]
        public ActionResult editarParada(DTOParada parada)
        {
            pxa.editarParada(parada);
            return RedirectToAction("traerParadas");
        }
        

        //-------------------------------linea----------------------------------------

        public ActionResult traerLinea()
        {
            idPars.Clear();
            Session["Nuevalinea"] = null;
            Session["selecParadaId"] = null;
            Session["errorNLinea"] = null;
            Session["ordenParada"] = null;
            return View(Task.Run(() => pxa.GetAllLineas()).Result);
        }

        
        public ActionResult crearLinea()
        {
            if (Session["errorNLinea"]!=null)
            {
                ViewBag.Message = Session["errorNLinea"];
            }
            return View();
        }

        [HttpPost]
        public ActionResult crearLinea(DTOLinea linea)
        {
            foreach (var li in Task.Run(() => pxa.GetAllLineas()).Result)
            {
                if (linea.Nombre == li.Nombre)
                {
                    Session["errorNLinea"] = "Ya existe una linea con ese nombre";
                    return RedirectToAction("crearLinea");
                }
            }
            Session["Nuevalinea"] = pxa.crearLinea(linea).IdLinea;
            return RedirectToAction("traerParadaL");//lista las paradas
        }

        public ActionResult traerParadaL()
        {
            List<EParada> retorno = new List<EParada>();

            List<EParada> paradas = Task.Run(() => pxa.GetAllParada()).Result;
            retorno.AddRange(paradas);

            if (idPars.Count()>0)
            {


                foreach (var p in paradas)
                {
                    foreach (var ip in idPars)
                    {
                        if (p.IdParada == ip)
                        {
                            retorno.Remove(p);
                        }
                    }
                }


                return View(retorno);
            }
            return View(paradas);
        }

        public ActionResult asignarParada(int id)
        {
            Session["selecParadaId"] = id;
            idPars.Add(id);
            return View();
        }

        [HttpPost]
        public ActionResult asignarParada(DTOTramoParada tp)
        {
            if (Session["ordenParada"]==null)
            {
                Session["ordenParada"] = 2;
            }

            if (!tp.isFinal)
            {

                DTOTramoPrecio tpre = new DTOTramoPrecio();
                tpre.IdLinea = (int)Session["Nuevalinea"];
                tpre.IdParada = (int)Session["selecParadaId"];
                //tpre.Orden =tp.Orden;

                if (tp.isOrigen)
                {
                    tpre.Orden = 1;

                    tpre.TiempoEstimado = 0;
                    tpre.FechaEntradaVigencia = "2000-01-01";
                    tpre.Precio = 0;
                }
                else
                {

                    tpre.Orden = (int)Session["ordenParada"];
                    Session["ordenParada"] = (int)Session["ordenParada"] + 1;

                    tpre.TiempoEstimado = tp.TiempoEstimado;
                    tpre.FechaEntradaVigencia = tp.FechaEntradaVigencia;
                    tpre.Precio = tp.Precio;
                }

                pxa.crearTramo(tpre);
                return RedirectToAction("traerParadaL");
            }
            else
            {
                DTOTramoPrecio tpre = new DTOTramoPrecio();
                tpre.IdLinea = (int)Session["Nuevalinea"];
                tpre.IdParada = (int)Session["selecParadaId"];
                tpre.Orden = (int)Session["ordenParada"];
                tpre.TiempoEstimado = tp.TiempoEstimado;
                tpre.FechaEntradaVigencia = tp.FechaEntradaVigencia;
                tpre.Precio = tp.Precio;
                pxa.crearTramo(tpre);
                Session["ordenParada"] = null;
                Session["Nuevalinea"] = null;
                Session["selecParadaId"] = null;
                Session["errorNLinea"] = null;
                idPars.Clear();
                return RedirectToAction("Index");
            }
        }


        public ActionResult editarLinea(int id)
        {
            DTOLinea p = new DTOLinea();
            p.IdLinea = id;
            return View(p);
        }

        [HttpPost]
        public ActionResult editarLinea(DTOLinea linea)
        {
            pxa.editarLinea(linea);
            return RedirectToAction("traerLinea");
        }
        

        //-----------------------------Salida------------------------------------------

        public ActionResult traerSalida()
        {
            return View(Task.Run(() => pxa.GetAllSalida()).Result);
        }

        public ActionResult traerCondSallida()
        {
            return View(Task.Run(() => pxa.GetAllConductores()).Result);
        }

        public ActionResult listVeic(int id) //id del conductor, se listan los veiculos
        {
            Session["conductorId"] = id;
            return View(Task.Run(() => pxa.getAllVehiculos()).Result);
        }

        public ActionResult selecLine(string id) //matricula, se listan las lineas
        {
            Session["veiculoMat"] = id;
            return View(Task.Run(() => pxa.GetAllLineas()).Result);
        }
        

        public ActionResult crearSalida(int id)//id salida
        {
            Session["lineId"] = id;
            return View();
        }

        [HttpPost]
        public ActionResult crearSalida(DTOSalida salida)
        {
            salida.IdLinea = (int)Session["lineId"];
            salida.IdVehiculo = Session["veiculoMat"].ToString();
            salida.IdConductor = (int)Session["conductorId"];
            pxa.crearSalida(salida);
            return RedirectToAction("traerSalida");
        }
        

        public ActionResult editarSalida(int id)
        {
            DTOSalida p = new DTOSalida();
            p.IdSalida = id;
            return View(p);
        }

        [HttpPost]
        public ActionResult editarSalida(DTOSalida salida)
        {
            pxa.editarSalida(salida);
            return RedirectToAction("traerSalida");
        }
        //----------------Conductor------------------------------------


        public ActionResult traerConductores()
        {
            return View(Task.Run(() => pxa.GetAllConductores()).Result);
        }


        public ActionResult editarConductor(int id)
        {
            EConductor p = new EConductor();
            p.Id = id;
            return View(p);
        }

        [HttpPost]
        public ActionResult editarConductor(EConductor conductor)
        {
            pxa.editarConductor(conductor);
            return RedirectToAction("traerConductores");
        }

        //----------------------------reporte utilidad ------------------------------
        public ActionResult SelectreporteU()
        {
            return View();
        }

        public ActionResult reporteV()
        {
            Session["reporte"] = "v";
            return RedirectToAction("reporteUtilidad");
        }

        public ActionResult reporteS()
        {
            Session["reporte"] = "s";
            return RedirectToAction("reporteUtilidad");
        }

        public ActionResult reporteL()
        {
            Session["reporte"] = "l";
            return RedirectToAction("reporteUtilidad");
        }

        public ActionResult reporteUtilidad()
        {
            if (Session["reporte"].ToString() == "v") ViewBag.Message = "v";
            if (Session["reporte"].ToString() == "s") ViewBag.Message = "s";
            if (Session["reporte"].ToString() == "l") ViewBag.Message = "l";
            return View();
        }

        [HttpPost]
        public ActionResult reporteUtilidad(DTOUtilidad utilidad)
        {
            if (Session["reporte"].ToString() == "v")
            {
                utilidad.linea=-1;
                utilidad.salida=-1;
            }
            if (Session["reporte"].ToString() == "s")
            {
                utilidad.idViaje = -1;
                utilidad.linea = -1;
            }
            if (Session["reporte"].ToString() == "l")
            {
                utilidad.idViaje = -1;
                utilidad.salida = -1;
            }

            if (utilidad.fechaDesde == null) utilidad.fechaDesde = "1900,01,01";
            if (utilidad.fechaHasat == null) utilidad.fechaHasat = "1900,01,01";
            DTOUtilidadFinal ut = new DTOUtilidadFinal();
            float result = Task.Run(() => pxa.reporteUtilidad(utilidad)).Result;
            ut.Valor = result*100;
            return RedirectToAction("verUtilidad", ut);


        }


        public ActionResult verUtilidad(DTOUtilidadFinal result)
        {
            return View(result);
        }


        //-----------------------------reporte pasaje -------------------------------

        public ActionResult selectRepP()
        {
            return View();
        }

        public ActionResult reportePV()
        {
            Session["reporteP"] = "v";
            return RedirectToAction("reportePasaje");
        }

        public ActionResult reportePS()
        {
            Session["reporteP"] = "s";
            return RedirectToAction("reportePasaje");
        }

        public ActionResult reportePL()
        {
            Session["reporteP"] = "l";
            return RedirectToAction("reportePasaje");
        }
        public ActionResult reportePasaje()
        {
            if (Session["reporteP"].ToString() == "v") ViewBag.Message = "v";
            if (Session["reporteP"].ToString() == "s") ViewBag.Message = "s";
            if (Session["reporteP"].ToString() == "l") ViewBag.Message = "l";
            return View();
        }

        [HttpPost]
        public ActionResult reportePasaje(DTOreportePasaje repoPasaje)
        {
            if (Session["reporteP"].ToString() == "v")
            {
                repoPasaje.linea = -1;
                repoPasaje.salida = -1;
            }
            if (Session["reporteP"].ToString() == "s")
            {
                repoPasaje.viaje = -1;
                repoPasaje.linea = -1;
            }
            if (Session["reporteP"].ToString() == "l")
            {
                repoPasaje.viaje = -1;
                repoPasaje.salida = -1;
            }
            List<EPasaje> result = Task.Run(() => pxa.reportedePasaje(repoPasaje)).Result;
            return View("verReportePasaje", result);
        }


    }
}