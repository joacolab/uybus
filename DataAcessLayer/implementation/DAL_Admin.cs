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
    public class DAL_Admin : IDAL_Admin
    {
        public EAdmin addAdmin(int idPersona)
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    EAdmin EA = new EAdmin();

                    Admin ad = new Admin();
                    ad.Id = idPersona;
                    db.Admin.Add(ad);
                    db.SaveChanges();

                    EA.Id = idPersona;
                    return EA;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public EAdmin getAdmin(int id)
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    Admin adm = db.Admin.Find(id);
                    if (adm==null)
                    {
                        return null;
                    }
                    EAdmin ed = new EAdmin();
                    ed.Id = adm.Id;

                    return ed;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error en DAL_Conductor. Método: getConductor " + e.Message);
                throw e;
            }
        }

        public List<EPersona> getAllAdmin()
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    List<EPersona> lstEp = new List<EPersona>();

                    var Admins = db.Admin;

                    foreach (var a in Admins)
                    {
                        Persona per = db.Persona.Find(a.Id);
                        if (per != null) 
                        {
                            EPersona Eper = new EPersona();
                            Eper = Converter.personaAEpersona(per);
                            lstEp.Add(Eper);                   
                        }
                    }
                    return lstEp;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

    }
}