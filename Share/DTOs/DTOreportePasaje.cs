using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.DTOs
{
    public class DTOreportePasaje
    {
        public string fechaDesde { get; set; }
        public string fechaHasta { get; set; }
        public int linea { get; set; }
        public int salida { get; set; }
        public int viaje { get; set; }
    }
}
