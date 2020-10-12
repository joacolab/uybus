﻿using DataAccessLayer.conversores;
using DataAccessLayer.interfaces;
using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.implementation
{
    public class DAL_Salida : IDAL_Salida
    {
        public ESalida addSalida(string matricula, int linea, TimeSpan horaInicio, int idConductor)
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    Salida sal = new Salida();
                    sal.IdVehiculo = matricula;
                    sal.IdLinea = linea;
                    sal.HoraInicio = horaInicio;
                    sal.IdConductor = idConductor;
                    db.Salida.Add(sal);
                    db.SaveChanges();
                    return Converter.salidaAESalida(sal);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error en DAL_Salida, en addSalida" + ex.Message);
                throw ex;

            }
        }

        public List<ESalida> getAllSalidas()
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    List<ESalida> lstEp = null;

                    var salidas = db.Salida;

                    foreach (var p in salidas)
                    {
                        ESalida sal = Converter.salidaAESalida(p);
                        lstEp.Add(sal);
                    }
                    return lstEp;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error en DAL_Salida,  en getAllSalidas" + ex.Message);
                throw ex;
            }
        }

        public ESalida getSalidas(int idSalida)
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    Salida sal = db.Salida.Find(idSalida);
                    return Converter.salidaAESalida(sal);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error en DAL_Salida, en getSalida " + ex.Message);
                throw ex;
            }


        }
    }
}
