using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.entities
{
    class Usuario
    {
        public int Id { get; set; }
        public ICollection<Pasaje> Pasaje { get; set; } = null;
        public Persona Persona { get; set; } = null;
    }
}
