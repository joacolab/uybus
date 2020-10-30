using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.DTOs
{
    public class DTOTramoPrecio
    {
        public int IdParada { get; set; }
        public int IdLinea { get; set;  }
        public int Orden { get; set; }
        public int TiempoEstimado { get; set; } 
        public int Precio { get; set; }
        public string FechaEntradaVigencia { get; set; }
    }
}
