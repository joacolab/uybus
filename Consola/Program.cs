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
            //EParada ep = bla.crearParada("Parada1", -34.333432, -56.324321);

            //ESalida es = bla.crearSalida(); //falta testear

            Console.WriteLine("\nPrecione Enter  para finalizar.");
            Console.Read();
        }
    }
}



