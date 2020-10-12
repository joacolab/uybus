using DataAccessLayer.conversores;
using DataAccessLayer.interfaces;
using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.implementation
{
    public class DAL_Viaje : IDAL_Viaje
    {
        public EViaje addViaje(bool finalizdo, DateTime Fecha, TimeSpan HoraInicioReal, int IdSalida)
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    Viaje v = new Viaje();
                    if (finalizdo) v.Finalizado = 1;
                    if (!finalizdo) v.Finalizado = 0;
                    v.Fecha = Fecha;
                    v.HoraInicioReal = HoraInicioReal;
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
    }
}
