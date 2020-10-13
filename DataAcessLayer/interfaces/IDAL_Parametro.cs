using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.interfaces
{
    public interface IDAL_Parametro
    {
        EParametro addParametro(int valor);
        List<EParametro> getAllParametros();
        EParametro getParametros(int idParametro);
    }
}