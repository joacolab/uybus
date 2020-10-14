using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.entities
{
    public class EViaje
    {
        public int IdViaje { get; set; }
        public Nullable<byte> Finalizado { get; set; }
        public System.DateTime Fecha { get; set; }
        public Nullable<System.TimeSpan> HoraInicioReal { get; set; }
        public int IdSalida { get; set; }
        public ICollection<EPasaje> Pasaje { get; set; } = new List<EPasaje>();
        public ESalida Salida { get; set; }
        public ICollection<ELlegada> Llegada { get; set; } = new List<ELlegada>();
    }
}
