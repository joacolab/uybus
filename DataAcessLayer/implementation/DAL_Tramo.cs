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
    public class DAL_Tramo : IDAL_Tramo
    {
        public ETramo addTramo(int tiempoEstimado, int idLinea, int idParada)
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    Tramo t = new Tramo();
                    t.TiempoEstimado = tiempoEstimado;
                    t.IdParada = idParada;
                    t.IdLinea = idLinea;
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
    }
}
