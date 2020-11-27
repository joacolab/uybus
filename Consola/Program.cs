using BuisnessLayer.implementation;
using BuisnessLayer.interfaces;
using DataAcessLayer.implementation;
using Share.DTOs;
using Share.entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Consola
{
    class Program
    {
       
        static void Main(string[] args)
        {
            IBL_Admin bla = new BL_Admin(new DAL_Linea(), new DAL_Parada(), new DAL_Salida(), new DAL_Vehiculo(), new DAL_Conductor(), new DAL_Tramo(), new DAL_Precio(), new DAL_Viaje());
            IBL_Usuario blu = new BL_Usuario(new DAL_Persona(), new DAL_Usuario(), new DAL_Linea(), new DAL_Salida(), new DAL_Tramo(), new DAL_Viaje(), new DAL_Pasaje(), new DAL_Parametro(), new DAL_Parada(), new DAL_Llegada(), new DAL_Vehiculo());
            IBL_Invitado bli = new BL_Invitado(new DAL_Persona(), new DAL_Usuario());
            IBL_General blg = new BL_General(new DAL_Viaje(), new DAL_Llegada(), new DAL_Salida(), new DAL_Linea(), new DAL_Tramo(), new DAL_Parada(), new DAL_Pasaje(), new DAL_Usuario(), new DAL_Vehiculo(), new DAL_Persona(), new DAL_Admin(), new DAL_Conductor(), new DAL_SuperAdmin());
            IBL_Conductor iConductor = new BL_Conductor(new DAL_Viaje(), new DAL_Pasaje(), new DAL_Llegada(), new DAL_Tramo(), new DAL_Salida(), new DAL_Linea());
            IBL_SuperAdmin bls = new BL_SuperAdmin(new DAL_Persona(), new DAL_Usuario(), new DAL_Admin(), new DAL_Conductor(), new DAL_Llegada(), new DAL_Parada(), new DAL_Salida(), new DAL_Vehiculo(), new DAL_Viaje());

            // ----------------- Testeado -------------------
            //EUsuario eu = bli.registrarse("55615808", "carlos@gmail.com", "1234", 1, "Carlos", "Mauro","Gonzalez","Perez");//testeado
            //EPersona ep = bls.asignarRol(1,Rol.Conductor);//testeada
            //bla.gestionConductores(1,new DateTime(2021,10,10));//testeada
            //EParada pa = bla.crearParada("Parada2", -34.333432, -56.324321);//testeado
            //ELinea el = bla.crearLinea("B");//testeado
            //EVehiculo ev = bla.crearVehiculos( "Mercedez-benz", "we3", "ABC1234", 42);//testeado
            //EVehiculo eve = bla.editarVehiculos("Mercedez-benz", "ert", "ABC1234", 42);//testeado
            //ESalida es = bla.crearSalida(1, "ABC1234", 1, new TimeSpan(8, 30, 00)); //testeada

            /*
            List<Dias> dias = new List<Dias>();
            dias.Add(Dias.Lunes);
            Console.WriteLine(dias.First());
            List<EViaje> viajes = bla.crearViajes(new DateTime(2020,10,2), new DateTime(2020, 10, 30), dias, 1); //testeado
            */
            //ETramo et = bla.crearTramos(1,1,1000,15,new DateTime(2019,04,04));//testeada
            //ELlegada ell = blg.CrearLlegada(2, 2, new TimeSpan(03, 03, 03));//Testeada

            //blc.iniciarViaje(1, new TimeSpan(20,0,0)); //testeado
            //blg.finalizarViaje(1);//testeado

            /*
            List<DTOubicacion> lstdto = bls.ubicarVehiculo();
            foreach (var l in lstdto)
            {
                Console.WriteLine(l.hora + " " + l.lat +" "+ l.lon +" "+ l.matricula);//testeado
            }*/

            // EPasaje ep = blu.comprarPasaje(1, 2, 1, 2, "null", "null", 2); //testeado

            EPasaje ep = blu.comprarPasaje(1, 2, 2, 5, "CI", "43338737", 18); //testeado

            //Console.WriteLine(blc.verificarPasaje(1, 1));//testeado
            //List<DTOproxVehiculo>  pv = blu.proximoVehiculo(2, 3);//testeado

            /*List<EPasaje> pasajes = blg.reposrtesPasajes(new DateTime(2020,12,01), new DateTime(2020,12,04),1,-1,-1); //testeado
            foreach (var pasaje in pasajes)
            {
                Console.WriteLine(pasaje.IdPasaje);
            }*/
            /*List<EUsuario> usuarios =  blg.notificacionProximidad(1, 1);
            foreach (var usuario in usuarios)
            {
                Console.WriteLine(usuario.Id);
            }*/

            //Console.WriteLine(blg.reporteUtilidad(1, new DateTime(2020,12,01),new DateTime(2020,12,04), -1, -1));//testeado


            // ----------------- Falta testear -------------------

            //foreach (var item in blu.GetFechasViajes(1))
            //{
            //  Console.WriteLine(item.IdSalida);

            // }

            //blu.canSelectSeat(1, 1, 2);
            /*
            foreach (var item in blu.sinTerminales())
            {
                Console.WriteLine(item.IdParada);
            }*/
            //Console.WriteLine(blg.CrearLlegada(2,new TimeSpan(10,22,00), new DateTime(2020 , 12 , 03)));



            Console.WriteLine("\nPrecione Enter  para finalizar.");
            Console.Read();
        }
    }
}



