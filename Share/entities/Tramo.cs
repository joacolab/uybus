using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.entities
{
    public class Tramo
    {
        public int IdLinea { get; set; }
        public int IdParada { get; set; }
        public int TiempoEstimado { get; set; }

        public Linea Linea { get; set; }
        public Parada Parada { get; set; } 
        public ICollection<Precio> Precio { get; set; } = new List<Precio>();
    }
}
