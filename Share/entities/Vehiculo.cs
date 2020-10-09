using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.entities
{
    class Vehiculo
    {
        public string Matricula { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public int CantAsientos { get; set; }
        public ICollection<Salida> Salida { get; set; } = null;
    }
}
