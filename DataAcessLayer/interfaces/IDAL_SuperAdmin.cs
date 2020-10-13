using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.interfaces
{
    public interface IDAL_SuperAdmin
    {
        ESuperAdmin addSuperAdmin(int idPersona);
        List<ESuperAdmin> getAllSuperAdmin();
        ESuperAdmin getSuperAdmin(int idSuperAdmin);
    }
}