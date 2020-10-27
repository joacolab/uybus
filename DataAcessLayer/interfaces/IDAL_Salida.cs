using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.interfaces
{
    public interface IDAL_Salida
    {
        ESalida addSalida(string matricula, int linea, TimeSpan horaInicio, int idConductor);
        List<ESalida> getAllSalidas();
        ESalida getSalidas(int idSalida);

        ESalida editSalida(int IdSalida, TimeSpan HoraInicio, int IdConductor, string IdVehiculo, int IdLinea);

    }
}