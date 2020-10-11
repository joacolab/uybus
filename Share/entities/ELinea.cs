using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.entities
{
    public class ELinea
    {
        public int IdLinea { get; set; }
        public string Nombre { get; set; }

        public ICollection<ESalida> Salida { get; set; } = new List<ESalida>();
        public ICollection<ETramo> Tramo { get; set; } = new List<ETramo>();
    }
}
