using DataAccessLayer.interfaces;
using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.implementation
{
    public class DAL_Vehiculo : IDAL_Vehiculo
    {
        public void addSalidas(string matricula, List<ESalida> salidas)
        {
            throw new NotImplementedException();
        }

        public EVehiculo addVehiculo(string matricula, string marca, string modelo, int cantAsientos)
        {
            throw new NotImplementedException();
        }

        public EVehiculo addVehiculo(string matricula, string marca, string modelo, int cantAsientos, List<ESalida> salidas)
        {
            throw new NotImplementedException();
        }

        public List<EVehiculo> getAllVehiculos()
        {
            throw new NotImplementedException();
        }

        public List<ESalida> getSalidas(string matricula)
        {
            throw new NotImplementedException();
        }

        public EVehiculo getVehiculos(string matricula)
        {
            throw new NotImplementedException();
        }
    }
}
