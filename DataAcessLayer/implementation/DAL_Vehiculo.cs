using DataAcessLayer.conversores;
using DataAcessLayer.interfaces;
using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.implementation
{
    public class DAL_Vehiculo : IDAL_Vehiculo
    {
        public EVehiculo addVehiculo(string matricula, string marca, string modelo, int cantAsientos)
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    Vehiculo v = new Vehiculo();
                    v.Matricula = matricula;
                    v.Modelo = modelo;
                    v.Marca = marca;
                    v.CantAsientos = cantAsientos;
                    db.Vehiculo.Add(v);
                    db.SaveChanges();

                    EVehiculo ev = new EVehiculo();
                    ev = Converter.vehiculoAEVehiculo(v);
                    return ev;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public EVehiculo editVehiculo(string matricula, string marca, string modelo, int cantAsientos)
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    Vehiculo v = db.Vehiculo.Find(matricula);
                    v.Modelo = modelo;
                    v.Marca = marca;
                    v.CantAsientos = cantAsientos;
                    db.Entry(v).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    return Converter.vehiculoAEVehiculo(v); 
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public List<EVehiculo> getAllVehiculos()
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    List<EVehiculo> lstEv = new List<EVehiculo>();

                    var veics = db.Vehiculo;

                    foreach (var v in veics)
                    {

                        EVehiculo ev = new EVehiculo();
                        ev = Converter.vehiculoAEVehiculo(v);
                        lstEv.Add(ev);
                    }
                    return lstEv;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public EVehiculo getVehiculos(string matricula)
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    Vehiculo v = db.Vehiculo.Find(matricula);
                    if (v == null) return null;
                    EVehiculo ev = new EVehiculo();
                    ev = Converter.vehiculoAEVehiculo(v);
                    return ev;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
