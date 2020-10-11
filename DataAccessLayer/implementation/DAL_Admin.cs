using DataAccessLayer.interfaces;
using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.implementation
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

        public EAdmin getAdmin(int idAdmin)
        {
            throw new NotImplementedException();
        }

        public List<EAdmin> getAllAdmin()
        {
            throw new NotImplementedException();
        }
    }
}
