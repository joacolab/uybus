using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.entities
{
    public class ETramo
    {
        public int IdLinea { get; set; }
        public int IdParada { get; set; }
        public int TiempoEstimado { get; set; }
        public int Orden { get; set; }
        public ELinea Linea { get; set; }
        public EParada Parada { get; set; } 
        public ICollection<EPrecio> Precio { get; set; } = new List<EPrecio>();
    }
}
