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
    public class DAL_Parada : IDAL_Parada
    {
        /// <summary>
        /// Agrega una nueva parada en la BD
        /// </summary>
        /// <param name="idParada">Id de la parada</param>
        /// <param name="nombre">Nombre de la parada</param>
        /// <param name="lat">Latutud de la parada</param>
        /// <param name="lon">Longitud</param>
        /// <returns></returns>
        public EParada addParada(string nombre, double lat, double lon)
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    Parada parada = new Parada();
                    parada.Nombre = nombre;
                    parada.Lat = lat;
                    parada.Long = lon;
                    db.Parada.Add(parada);
                    db.SaveChanges();
                    return Converter.paradaAEParada(parada);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en DAL_Parada. Método: addParada " + e.Message);
                throw e;
            }
        }

        /// <summary>
        /// Obtiene todas las paradas de la BD
        /// </summary>
        /// <returns>Lista de EParadas</returns>
        public List<EParada> getAllParadas()
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    List<EParada> lstEParada = new List<EParada>();
                    var Paradas = db.Parada;
                    foreach (var p in Paradas)
                    {
                        EParada ep = Converter.paradaAEParada(p);
                        lstEParada.Add(ep);
                    }
                    return lstEParada;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en DAL_Parada. Método: getAllParadas " + e.Message);
                throw e;
            }
        }

        /*
        public List<EParada> getAllParadasDeUnaLinea(int linea)
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    List<EParada> lstEParada = new List<EParada>();
                    var Paradas = db.Parada;
                    foreach (var p in Paradas)
                    {
                        EParada ep = Converter.paradaAEParada(p);
                        lstEParada.Add(ep);
                    }
                    return lstEParada;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en DAL_Parada. Método: getAllParadas " + e.Message);
                throw e;
            }
        }
        */
        /// <summary>
        /// Busca una Parada en la BD por su id y retorna un EParada
        /// </summary>
        /// <param name="idParada">Id de la parada</param>
        /// <returns>EParada</returns>
        public EParada getParada(int idParada)
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    Parada parada = db.Parada.Find(idParada);
                    return Converter.paradaAEParada(parada);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en DAL_Parada. Método: getParada " + e.Message);
                throw e;
            }
        }
    }
}
