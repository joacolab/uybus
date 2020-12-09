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
    public class DAL_Linea : IDAL_Linea
    {
        /// <summary>
        /// Agrega una nueva Línea en la BD
        /// </summary>
        /// <param name="nombre">Nombre de la Línea</param>
        /// <returns>Retorna una instancia de la linea creada, de tipo ELinea</returns>
        public ELinea addLinea(string nombre)
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    Linea linea = new Linea();

                    var l = db.Linea;
                    foreach (var p in l)
                    {
                        if (p.Nombre == nombre)
                        {
                            return null;
                        }
                    }

                    linea.Nombre = nombre;
                    db.Linea.Add(linea);
                    db.SaveChanges();
                    return Converter.lineaAElinea(linea);
                   
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en DAL_Linea. Método: addLinea " + e.Message);
                throw e;
            }

        }

        public ELinea editLinea(int IdLinea, string nombre)
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    Linea el = db.Linea.Find(IdLinea);
                    el.Nombre = nombre;
                    db.Entry(el).State = EntityState.Modified;
                    db.SaveChanges();

                    return Converter.lineaAElinea(el);
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene todas las Líneas de la BD
        /// </summary>
        /// <returns>Una lista de tipo ELinea</returns>
        public List<ELinea> getAllLineas()
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    List<ELinea> lstELinea = new List<ELinea>();
                    var Lineas = db.Linea;
                    foreach (var li in Lineas)
                    {
                        ELinea eli = Converter.lineaAElinea(li);
                        lstELinea.Add(eli);
                    }
                    return lstELinea;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en DAL_Linea. Método: getAllLineas " + e.Message);
                throw e;
            }
        }

        /// <summary>
        /// Busca una línea por su Id
        /// </summary>
        /// <param name="idLinea">Id de la linea</param>
        /// <returns>Objeto de tipo ELinea</returns>
        public ELinea getLinea(int idLinea)
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    Linea linea = db.Linea.Find(idLinea);
                    if (linea == null)
                    {
                        return null;
                    }
                    return Converter.lineaAElinea(linea);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en DAL_Linea. Método: getLinea " + e.Message);
                throw e;
            }
        }
    }
}

