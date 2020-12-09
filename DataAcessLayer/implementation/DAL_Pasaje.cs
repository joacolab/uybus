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
    public class DAL_Pasaje : IDAL_Pasaje
    {
        public EPasaje addPasaje(int asiento, string documento, string tipoDocumento, int viaje, int paradaDestino, int paradaOrigen, int idUsuario)
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    Pasaje pasaje = new Pasaje();
                   
                    if(idUsuario != -1) pasaje.IdUsuario =idUsuario;
                    pasaje.Asientos = asiento;
                    pasaje.Documento = documento;
                    pasaje.TipoDocuemtno = tipoDocumento;
                    pasaje.IdViaje = viaje;
                    pasaje.IdParadaDestino = paradaDestino;
                    pasaje.IdParadaOrigen = paradaOrigen;
                    db.Pasaje.Add(pasaje);
                    db.SaveChanges();
                    return Converter.pasajeAEPasaje(pasaje);


                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error en DAL_Pasaje, en addPasajes" + ex.Message);
                throw ex;

            }
        }

        public List<EPasaje> getAllPasajes()
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    List<EPasaje> lstEp = new List<EPasaje>();

                    var Pasajes = db.Pasaje;

                    foreach (var p in Pasajes)
                    {
                        EPasaje pas = Converter.pasajeAEPasaje(p);
                        lstEp.Add(pas);
                    }
                    return lstEp;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error en DAL_Pasaje,  en getAllPasaje" + ex.Message);
                throw ex;
            }
        }

        public EPasaje getPasajes(int idPasaje)
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    Pasaje pas = db.Pasaje.Find(idPasaje);
                    if (pas == null)
                    {
                        EPasaje p = new EPasaje();
                        p.IdParadaOrigen = -1;
                        return p;
                    }
                    return Converter.pasajeAEPasaje(pas);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error en DAL_Pasaje, en getPasajes " + ex.Message);
                throw ex;
            }



        }
    }
}