using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.entities
{
    public class EVehiculo
    {
        public string Matricula { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public int CantAsientos { get; set; }
        public ICollection<ESalida> Salida { get; set; } = new List<ESalida>();
    }
}
