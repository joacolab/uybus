using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.interfaces
{
    public interface IDAL_Usuario
    {
        EUsuario addUsuario(int idPersona);
        List<EUsuario> getAllUsuarios();
        EUsuario getUsuario(int idUsuario);

    }
}
