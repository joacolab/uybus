using Share.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.DTOs
{
    public class DTOCompPasaje
    {
        public int idViaje { get; set; }
        public int idUsuario { get; set; }
        public int idParadaOrigen { get; set; }
        public int idParadaDestino { get; set; }
        public TipoDoc tipoDoc { get; set; }
        public string documento { get; set; }
        public int asiento { get; set; }
    }
}
