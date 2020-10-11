using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.entities
{
    public class EPrecio
    {
        public int IdPrecio { get; set; }
        public int Precio1 { get; set; }
        public System.DateTime FechaEntradaVigencia { get; set; }
        public int IdLinea { get; set; }
        public int IdParada { get; set; }

        public ETramo Tramo { get; set; }
    }
}
