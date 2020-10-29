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

        public List<int> diasSemana { get; set; } = new List<int>();

        public int idSalida { get; set; }

    }
}
