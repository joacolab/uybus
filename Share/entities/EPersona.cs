using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.entities
{
    public class EPersona
    {
        public int id { get; set; }
        public string Documento { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public int TipoDocumento { get; set; }
        public string pNombre { get; set; }
        public string sNombre { get; set; }
        public string pApellido { get; set; }
        public string sApellido { get; set; }

        public EAdmin Admin { get; set; }
        public EConductor Conductor { get; set; }
        public ESuperAdmin SuperAdmin { get; set; }
        public EUsuario Usuario { get; set; }

    }
}
