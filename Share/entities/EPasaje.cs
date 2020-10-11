using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.entities
{
    public class EPasaje
    {
        public int IdPasaje { get; set; }
        public Nullable<int> Asientos { get; set; }
        public string Documento { get; set; }
        public string TipoDocuemtno { get; set; }
        public Nullable<int> IdUsuario { get; set; }
        public int IdViaje { get; set; }
        public int IdParadaDestino { get; set; }
        public int IdParadaOrigen { get; set; }

        public EParada Parada { get; set; } 
        public EParada Parada1 { get; set; }
        public EUsuario Usuario { get; set; }
        public EViaje Viaje { get; set; } 
    }
}
