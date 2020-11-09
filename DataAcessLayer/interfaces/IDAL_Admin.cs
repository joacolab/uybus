using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.interfaces
{
    public interface IDAL_Admin
    {
        EAdmin addAdmin(int idPersona);

        EAdmin getAdmin(int id);
        List<EPersona> getAllAdmin();

    }
}
