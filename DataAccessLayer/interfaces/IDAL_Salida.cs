using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.interfaces
{
    public interface IDAL_Salida
    {
        ESalida addSalida(string matricula, int linea, TimeSpan horaInicio, int idConductor);
        List<ESalida> getAllSalidas();
        ESalida getSalidas(int idSalida);

    }
}