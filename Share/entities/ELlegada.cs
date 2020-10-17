using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.entities
{
    public class ELlegada
    {
        public int idParada { get; set; }
        public int idViaje { get; set; }
        public TimeSpan hora { get; set; }
        public System.DateTime fecha { get; set; }
        public EParada Parada { get; set; }
        public EViaje Viaje { get; set; }
    }
}
