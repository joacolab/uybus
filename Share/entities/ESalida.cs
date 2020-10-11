using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.entities
{
    public class ESalida
    {
        public int IdSalida { get; set; }
        public System.TimeSpan HoraInicio { get; set; }
        public int IdConductor { get; set; }
        public string IdVehiculo { get; set; }
        public int IdLinea { get; set; }

        public EConductor Conductor { get; set; }
        public ELinea Linea { get; set; }
        public EVehiculo Vehiculo { get; set; }
        public ICollection<EViaje> Viaje { get; set; } = new List<EViaje>();
    }
}
