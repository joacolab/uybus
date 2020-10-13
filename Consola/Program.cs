﻿using DataAcessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BuisnessLayer.implementation;
using BuisnessLayer.interfaces;
using Share.entities;
using Share.enums;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            IBL_Admin bla = new BL_Admin();
            IBL_Usuario blu = new BL_Usuario();
            IBL_Invitado bli = new BL_Invitado();
            IBL_General blg = new BL_General();
            IBL_Conductor blc = new BL_Conductor();
            IBL_SuperAdmin bls = new BL_SuperAdmin();


            //EUsuario eu = bli.registrarse("55615808", "carlos@gmail.com", "1234", 1, "Carlos", "Mauro","Gonzalez","Perez");//testeado
            //EPersona ep = bls.asignarRol(1,Rol.Conductor);//testeada
            //bla.gestionConductores(1,new DateTime(2021,10,10));//testeada
            //EParada pa = bla.crearParada("Parada1", -34.333432, -56.324321);//testeado
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


            Console.WriteLine("\nPrecione Enter  para finalizar.");
            Console.Read();
        }
    }
}



