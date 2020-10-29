using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.DTOs
{
    public class DTOViaje
    {
        public int IdViaje { get; set; }
        public bool Finalizado { get; set; }
        public string Fecha { get; set; }
        public string HoraInicioReal { get; set; }
        public int IdSalida { get; set; }

    }
}
