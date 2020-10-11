using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.interfaces
{
    public interface IDAL_Vehiculo
    {
        EVehiculo addVehiculo(string matricula, string marca, string modelo, int cantAsientos, List<ESalida> salidas);
        List<EVehiculo> getAllVehiculos();

        void addSalidas(string matricula, List<ESalida> salidas);
        EVehiculo getVehiculos(string matricula);
        List<ESalida> getSalidas(string matricula);
    }
}
