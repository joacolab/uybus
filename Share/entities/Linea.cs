using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.entities
{
    public class Linea
    {
        public int IdLinea { get; set; }
        public string Nombre { get; set; }

        public ICollection<Salida> Salida { get; set; } = new List<Salida>();
        public ICollection<Tramo> Tramo { get; set; } = new List<Tramo>();
    }
}
