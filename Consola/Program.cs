using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BuisnessLayer.implementation;
using BuisnessLayer.interfaces;
using Share.entities;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            IBL_Admin bla = new BL_Admin();
            //ELinea el = bla.crearLinea("B");//testeado
            //EParada ep = bla.crearParada("Parada1", -34.333432, -56.324321);//testeado
            //EVehiculo ev = bla.crearVehiculos( "Mercedez-benz", "we3", "ABC1234", 42);//testeado
            //EVehiculo ev = bla.editarVehiculos("Mercedez-benz", "ert", "ABC1234", 42);//testeado

            //ETramo et = bla.crearTramos();//falta testear
            //ESalida es = bla.crearSalida(); //falta testear
            //bla.gestionConductores();//falta testear


            Console.WriteLine("\nPrecione Enter  para finalizar.");
            Console.Read();
        }
    }
}



