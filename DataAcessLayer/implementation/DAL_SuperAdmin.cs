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
    public class DAL_SuperAdmin : IDAL_SuperAdmin
    {
        public ESuperAdmin addSuperAdmin(int idPersona)
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    ESuperAdmin Esupa = new ESuperAdmin();
                    SuperAdmin supa = new SuperAdmin();
                    supa.Id = idPersona;
                    db.SuperAdmin.Add(supa);
                    db.SaveChanges();
                    Esupa.Id = idPersona;
                    return Esupa;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error en DAL_SuperAdmin, en addSuperAdmin" + ex.Message);
                throw ex;
            }
        }

        public List<ESuperAdmin> getAllSuperAdmin()
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    List<ESuperAdmin> lstEp = null;

                    var superAdmins = db.SuperAdmin;

                    foreach (var p in superAdmins)
                    {

                        SuperAdmin supa = db.SuperAdmin.Find(p.Id);
                        if (supa != null) 
                        {
                            ESuperAdmin Esupa = new ESuperAdmin();
                            Esupa.Id = supa.Id; 
                            lstEp.Add(Esupa);
                        }
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

        public ESuperAdmin getSuperAdmin(int idSuperAdmin)
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    SuperAdmin supa = db.SuperAdmin.Find(idSuperAdmin);
                    if (supa == null)
                    {
                        return null;
                    }
                    ESuperAdmin Esupa = new ESuperAdmin();
                    Esupa.Id = supa.Id;
                    return Esupa;

                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error en DAL_SuperAdmin, en getSuperAdmin " + ex.Message);
                throw ex;
            }
        }
    }
}