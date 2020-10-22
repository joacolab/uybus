using BuisnessLayer.implementation;
using BuisnessLayer.interfaces;
using DataAcessLayer.implementation;
using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIREST.Controllers
{
    public class invitadoController : ApiController
    {
        IBL_Invitado bli = new BL_Invitado(new DAL_Persona(), new DAL_Usuario());

        //https://localhost:44330/reg?d="23434565"&c="abc@gmail.com"&p="1234"&t=1&n="Juan"&nn="Es"&a="Un"&aa="Maestro"
        [HttpGet]
        [Route("reg")]
        public EUsuario Get(string d, string c, string p, int t, string n, string nn, string a, string aa)
        {
            EUsuario eu = bli.registrarse(d, c, p, t, n, nn, a, aa);//testeado
            return eu;
        }

        /*
        //https://localhost:44366/foo?id=2
        [HttpGet]
        [Route("foo")]
        public int Get(int id)
        {
            return id;
        }

        //https://localhost:44366/foo2?id=3
        [HttpPost]
        [Route("foo2")]
        public int Post(int id)
        {
            return id;
        }
        */
    }
}
