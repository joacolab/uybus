using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.entities
{
    public class Persona
    {
        public string Documento { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public string TipoDocumento { get; set; }
        public string Nombre { get; set; }

        public Admin Admin { get; set; }
        public Conductor Conductor { get; set; }
        public SuperAdmin SuperAdmin { get; set; }
        public Usuario Usuario { get; set; }

    }
}
