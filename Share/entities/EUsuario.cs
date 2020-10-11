using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.entities
{
    public class EUsuario
    {
        public int Id { get; set; }
        public ICollection<EPasaje> Pasaje { get; set; } = new List<EPasaje>();
        public EPersona Persona { get; set; } 
    }
}
