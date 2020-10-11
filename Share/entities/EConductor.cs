using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.entities
{
    public class EConductor
    {
        public int Id { get; set; }
        public System.DateTime VencimientoLicencia { get; set; }
        public EPersona Persona { get; set; }
        public ICollection<ESalida> Salida { get; set; } = new List<ESalida>();
    }
}
