using DataAcessLayer.conversores;
using DataAcessLayer.interfaces;
using Share.DTOs;
using Share.entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.implementation
{
    public class DAL_Tramo : IDAL_Tramo
    {
        public ETramo addTramo(int tiempoEstimado, int idLinea, int idParada, int orden)
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    Tramo t = new Tramo();

                    var l = db.Tramo;
                    foreach (var p in l)
                    {
                        if (p.IdParada == idParada && p.IdLinea == idLinea)
                        {
                            return null;
                        }
                    }

                    t.TiempoEstimado = tiempoEstimado;
                    t.IdParada = idParada;
                    t.IdLinea = idLinea;
                    t.Orden = orden;
                    db.Tramo.Add(t);
                    db.SaveChanges();

                    ETramo et = new ETramo();
                    et = Converter.tramoAETramo(t);
                    return et;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public List<ETramo> getAllTramos()
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    List<ETramo> lstET = new List<ETramo>();
                    var tramos = db.Tramo;
                    foreach (var t in tramos)
                    {
                        ETramo et = new ETramo();
                        et = Converter.tramoAETramo(t);
                        lstET.Add(et);
                    }
                    return lstET;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public ETramo getTramos(int idLinea, int idParada)
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    Tramo t = db.Tramo.Find(idLinea, idParada);

                    if (t == null) return null;
                    ETramo et = new ETramo();
                    et = Converter.tramoAETramo(t);
                    return et;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public int valorVigente(int idLinea, int idParada)
        {
            ETramo t = getTramos(idLinea, idParada);
            List<EPrecio> lst = t.Precio.ToList();            

            List<EPrecio> lst2 = new List<EPrecio>();

            foreach (var l in lst)
            {
                if (l.FechaEntradaVigencia.CompareTo(DateTime.Today) == -1)
                {
                    lst2.Add(l);
                }
            }

            lst2.OrderBy(r => r.FechaEntradaVigencia);

            return lst2.Last().Precio1;
        }

        public ETramo editarTramo(int IdLinea, int IdParada, DTOTramo tramo)
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {

                    Tramo t = db.Tramo.Find(IdLinea, IdParada);

                    t.TiempoEstimado = tramo.TiempoEstimado;
                    t.IdParada = IdParada;
                    t.IdLinea = IdLinea;
                    t.Orden = tramo.Orden;
                    db.Entry(t).State = EntityState.Modified;
                    db.SaveChanges();
                    return Converter.tramoAETramo(t);
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
