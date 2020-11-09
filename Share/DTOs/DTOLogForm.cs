using Share.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.DTOs
{
    public class DTOLogForm
    {
        public string email { get; set; }
        public string password { get; set; }
        public Rol rol { get; set; }
    }
}
