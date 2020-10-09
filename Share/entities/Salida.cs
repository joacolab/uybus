using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.entities
{
    class Salida
    {
        public int IdSalida { get; set; }
        public System.TimeSpan HoraInicio { get; set; }
        public int IdConductor { get; set; }
        public string IdVehiculo { get; set; }
        public int IdLinea { get; set; }

        public Conductor Conductor { get; set; }
        public Linea Linea { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public ICollection<Viaje> Viaje { get; set; } = null;
    }
}
