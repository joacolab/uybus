using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.DTOs
{
    public class DTOubicacion
    {
        public double lat { get; set; }
        public double lon { get; set; }
        public TimeSpan hora { get; set; }
        public DateTime fecha { get; set; }
        public string matricula { get; set; }
    }
}
