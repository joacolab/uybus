using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.DTOs
{
    public class DTOSalida
    {
        public int IdSalida { get; set; }
        public string HoraInicio { get; set; }
        public int IdConductor { get; set; }
        public string IdVehiculo { get; set; }
        public int IdLinea { get; set; }
    }
}
