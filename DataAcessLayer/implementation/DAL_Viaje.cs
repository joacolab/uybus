using DataAcessLayer.conversores;
using DataAcessLayer.interfaces;
using Share.entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.implementation
{
    public class DAL_Viaje : IDAL_Viaje
    {
        public EViaje addViaje(bool finalizdo, DateTime Fecha, int IdSalida)
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    Viaje v = new Viaje();
                    if (finalizdo) v.Finalizado = 1;
                    if (!finalizdo) v.Finalizado = 0;
                    v.Fecha = Fecha;
                    v.IdSalida = IdSalida;
                    db.Viaje.Add(v);
                    db.SaveChanges();

                    EViaje ev = new EViaje();
                    ev = Converter.viajeAEViaje(v);
                    return ev;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public List<EViaje> getAllViajes()
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    List<EViaje> lstEv = new List<EViaje>();

                    var viajes = db.Viaje;

                    foreach (var v in viajes)
                    {
                        EViaje ev = new EViaje();
                        ev = Converter.viajeAEViaje(v);
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

        public EViaje getViaje(int idViaje)
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    Viaje v = db.Viaje.Find(idViaje);
                    if (v == null) return null;
                    EViaje ev = new EViaje();
                    ev = Converter.viajeAEViaje(v);
                    return ev;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public EViaje iniciarViaje(int idViaje, TimeSpan HoraInicioReal)
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    Viaje v = db.Viaje.Find(idViaje);
                    if (v == null) return null;
                    EViaje ev = new EViaje();
                    v.HoraInicioReal = HoraInicioReal;
                    db.Entry(v).State = EntityState.Modified;
                    db.SaveChanges();
                    ev = Converter.viajeAEViaje(v);
                    return ev;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void finalizarViaje(int idViaje)
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    Viaje v = db.Viaje.Find(idViaje);
                    if (v != null)
                    {
                        EViaje ev = new EViaje();
                        v.Finalizado = 1;
                        db.Entry(v).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public EViaje editViaje(int idViaje, bool finalizdo, DateTime Fecha, TimeSpan? HoraInicioReal, int IdSalida)
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    Viaje v = db.Viaje.Find(idViaje);
                    if (finalizdo) v.Finalizado = 1;
                    else v.Finalizado = 0;
                    v.Fecha = Fecha;
                    v.IdSalida = IdSalida;
                    v.HoraInicioReal = HoraInicioReal;
                    db.Entry(v).State = EntityState.Modified;
                    db.SaveChanges();

                    return Converter.viajeAEViaje(v);
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
