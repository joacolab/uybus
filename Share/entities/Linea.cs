using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.entities
{
    class Linea
    {
        public int IdLinea { get; set; }
        public string Nombre { get; set; }

        public ICollection<Salida> Salida { get; set; } = null;
        public ICollection<Tramo> Tramo { get; set; } = null;
    }
}
