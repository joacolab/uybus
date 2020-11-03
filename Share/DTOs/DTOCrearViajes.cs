using Share.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.DTOs
{
    public class DTOCrearViajes
    {
        public string fechaInicio { get; set; }

        public string fechaFinal { get; set; }

        public bool lunes { get; set; }

        public bool martes { get; set; }

        public bool miercoles { get; set; }

        public bool jueves { get; set; }

        public bool viernes { get; set; }

        public bool sabado { get; set; }

        public bool domingo { get; set; }


        public int idSalida { get; set; }

    }
}
