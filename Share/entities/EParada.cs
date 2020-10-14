using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.entities
{
    public class EParada
    {
        public int IdParada { get; set; }
        public string Nombre { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public ICollection<EPasaje> Pasaje { get; set; } = new List<EPasaje>();
        public ICollection<EPasaje> Pasaje1 { get; set; } = new List<EPasaje>();
        public ICollection<ETramo> Tramo { get; set; } = new List<ETramo>();
        public ICollection<ELlegada> Llegada { get; set; } = new List<ELlegada>();
    }
}
