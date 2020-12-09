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
    public class DAL_Precio : IDAL_Precio
    {
        public EPrecio addPrecio(int precio, DateTime fechaEntrVig, int idLinea, int idParada)
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    Precio pre = new Precio();
                    pre.Precio1 = precio;
                    pre.FechaEntradaVigencia = fechaEntrVig;
                    pre.IdLinea = idLinea;
                    pre.IdParada = idParada;
                    db.Precio.Add(pre);
                    db.SaveChanges();
                    return Converter.precioAEPrecio(pre);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error en DAL_Precio, en addPrecio " + ex.Message);
                throw ex;

            }
        }

        public List<EPrecio> getAllPrecios()
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    List<EPrecio> lstEp = null;

                    var Prec = db.Precio;

                    foreach (var p in Prec)
                    {
                        EPrecio ep = Converter.precioAEPrecio(p);
                        lstEp.Add(ep);
                    }
                    return lstEp;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error en DAL_Precio, en getAllPrecios" + ex.Message);
                throw ex;
            }
        }

        public EPrecio getPrecios(int idLinea, int idParada)
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    Precio p = db.Precio.Find(idLinea, idParada);
                    if (p == null) return null;
                    return Converter.precioAEPrecio(p);
                }

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error en DAL_Precio, en getPrecios " + ex.Message);

                throw ex;
            }
        }
    }
}