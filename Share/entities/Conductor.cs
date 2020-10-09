using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.entities
{
    class Conductor
    {
        public int Id { get; set; }
        public System.DateTime VencimientoLicencia { get; set; }
        public Persona Persona { get; set; }
        public ICollection<Salida> Salida { get; set; } = null;
    }
}
