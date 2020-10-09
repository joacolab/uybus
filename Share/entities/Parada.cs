using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.entities
{
    class Parada
    {
        public int IdParada { get; set; }
        public string Nombre { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public ICollection<Pasaje> Pasaje { get; set; } = null;
        public ICollection<Pasaje> Pasaje1 { get; set; } = null;
        public ICollection<Tramo> Tramo { get; set; } = null;
    }
}
