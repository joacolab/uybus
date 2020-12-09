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
    public class DAL_Parametro : IDAL_Parametro
    {
        /// <summary>
        /// Agrega un nuevo parámetro, para el valor de los pasajes
        /// </summary>
        /// <param name="valor">Valor parametrizado</param>
        /// <returns>Instancia del nuevo paramétro</returns>
        public EParametro addParametro(int valor)
        {
            EParametro ep = new EParametro();
            ep.Valor = valor;
            return ep;
        }

        /// <summary>
        /// Obtiene todos los objetos de tipo parametro
        /// </summary>
        /// <returns>Lista de objetos tipo EParametro</returns>
        public List<EParametro> getAllParametros()
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    List<EParametro> lstEParametro = new List<EParametro>();
                    var Parametros = db.Parametro;
                    foreach (var pa in Parametros)
                    {
                        EParametro epa = Converter.parametroAEParametro(pa);
                        lstEParametro.Add(epa);
                    }
                    return lstEParametro;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en DAL_Conductor. Método: getAllConductores " + e.Message);
                throw e;
            }
        }


        /// <summary>
        /// Busca un parámetro por su id
        /// </summary>
        /// <param name="idParametro">Id Parametro</param>
        /// <returns>Objeto de tipo Parámetro</returns>
        public EParametro getParametros(int idParametro)
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    Parametro parametro = db.Parametro.Find(idParametro);
                    if (parametro == null) return null;
                    return Converter.parametroAEParametro(parametro);
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
