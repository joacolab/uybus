using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.interfaces
{
    public interface IDAL_Admin
    {
        EAdmin addAdmin(int idPersona);
        List<EAdmin> getAllAdmin();

        EAdmin getAdmin(int idAdmin);
    }
}
