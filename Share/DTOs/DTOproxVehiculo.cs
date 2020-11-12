using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.DTOs
{
    public class DTOproxVehiculo
    {
        public EVehiculo Vehiculo { get; set; }
        public bool reservado { get; set; }
        public string linea { get; set; }

    }
}
