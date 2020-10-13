using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.interfaces
{
    public interface IDAL_Vehiculo
    {
        EVehiculo addVehiculo(string matricula, string marca, string modelo, int cantAsientos);

        EVehiculo editVehiculo(string matricula, string marca, string modelo, int cantAsientos);
        List<EVehiculo> getAllVehiculos();
        EVehiculo getVehiculos(string matricula);
    }
}