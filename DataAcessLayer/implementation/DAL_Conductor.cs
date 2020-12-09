using DataAcessLayer.conversores;
using DataAcessLayer.interfaces;
using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataAcessLayer.implementation
{
    public class DAL_Conductor : IDAL_Conductor
    {
        /// <summary>
        /// Agrega un nuevo conductor a la BD
        /// </summary>
        /// <param name="idPersona">Id del conductor</param>
        /// <param name="FechaVenc">Fecha de vencimiento de la libreta de conducir.</param>
        /// <returns>Una instancia del nuevo conductor.</returns>
        public EConductor addConductor(int idPersona, DateTime FechaVenc)
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    Conductor conductor = new Conductor();
                    conductor.Id = idPersona;
                    conductor.VencimientoLicencia = FechaVenc;
                    db.Conductor.Add(conductor);
                    db.SaveChanges();
                    return Converter.conductorAEConductor(conductor);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en DAL_Conductor. Método: addConductor " + e.Message);
                throw e;
            }
        }

        /// <summary>
        /// Actualiza la feha de vencimiento de la libreta de conducir de un conductor
        /// </summary>
        /// <param name="idConductor">Id conductor</param>
        /// <param name="FechaVenc">Fecha de vencimiento de la libreta de conducir</param>
        public void updateFechaVencLib(int idConductor, DateTime FechaVenc)
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    Conductor conductor = db.Conductor.Find(idConductor);
                    if (conductor != null)
                    { 
                        conductor.VencimientoLicencia = FechaVenc;
                        db.Entry(conductor).State = EntityState.Modified;
                        db.SaveChanges();           
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en DAL_Conductor. Método: addFechaVenLib " + e.Message);
                throw e;
            }
        }

      

        /// <summary>
        /// Obtiene todos los conductores de la BD
        /// </summary>
        /// <returns>Lista de conductores de tipo EConductor</returns>
        public List<EConductor> getAllConductores()
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    List<EConductor> lstEcon = new List<EConductor>();
                    var Conductores = db.Conductor;
                    foreach (var c in Conductores)
                    {
                        EConductor ec = Converter.conductorAEConductor(c);
                        lstEcon.Add(ec);
                    }
                    return lstEcon;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en DAL_Conductor. Método: getAllConductores " + e.Message);
                throw e;
            }
        }

        /// <summary>
        /// Busca un conductor por su Id
        /// </summary>
        /// <param name="idConductor">Id del conductor</param>
        /// <returns>Una instancia de tipo EConductor</returns>
        public EConductor getConductor(int idConductor)
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    Conductor conductor = db.Conductor.Find(idConductor);
                    if (conductor == null)
                    {
                        return null;
                    }
                    return Converter.conductorAEConductor(conductor);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en DAL_Conductor. Método: getConductor " + e.Message);
                throw e;
            }
        }

        public EConductor editConductor(int idConductor, DateTime FechaVenc)
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    Conductor conductor = db.Conductor.Find(idConductor);
                    if (conductor != null)
                    { 
                        conductor.VencimientoLicencia = FechaVenc;
                        db.Entry(conductor).State = EntityState.Modified;
                        db.SaveChanges();
                        return Converter.conductorAEConductor(conductor);
                    }
                    return null;

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en DAL_Conductor. Método: addFechaVenLib " + e.Message);
                throw e;
            }
        }
    }
}