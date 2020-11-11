using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.DTOs
{
    public class DTOTramoParada
    {
        public int IdParada { get; set; }
        public string Nombre { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }

        public int IdLinea { get; set; }
        public int Orden { get; set; }
        public int TiempoEstimado { get; set; }
        public int Precio { get; set; }
        public string FechaEntradaVigencia { get; set; }
        public bool isOrigen { get; set; }
        public bool isFinal { get; set; }
    }
}
