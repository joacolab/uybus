using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (uybusEntities db = new uybusEntities()) {
                Parametro p = new Parametro();
                p.Valor = 5;
                db.Parametro.Add(p);
                db.SaveChanges();
            }
            Console.Read();
        }
    }
}



