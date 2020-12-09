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
    public class DAL_Llegada : IDAL_Llegada
    {
        public ELlegada addLlegada(int idParada, int idViaje, TimeSpan hora, DateTime fecha)
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    Llegada ll = new Llegada();
                    ll.idParada = idParada;
                    ll.idViaje = idViaje;
                    ll.hora = hora;
                    ll.fecha = fecha;
                    db.Llegada.Add(ll);
                    db.SaveChanges();

                    ELlegada el = new ELlegada();
                    el = Converter.llegadaAEllegada(ll);
                    return el;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public List<ELlegada> getAllLlegadas()
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    List<ELlegada> lstEl = new List<ELlegada>();
                    var llegadas = db.Llegada;
                    foreach (var l in llegadas)
                    {
                        ELlegada el = new ELlegada();
                        el = Converter.llegadaAEllegada(l);
                        lstEl.Add(el);
                    }
                    return lstEl;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public ELlegada getLlegada(int idParada, int idViaje)
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    Llegada l = db.Llegada.Find(idParada, idViaje);
                    if (l == null) return null;
                    ELlegada el = new ELlegada();
                    el = Converter.llegadaAEllegada(l);
                    return el;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
