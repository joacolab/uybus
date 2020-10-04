using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

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

                //---------------Select all---------
                var lst = db.Parametro;
                Console.WriteLine("-----Selet All:-----");
                foreach (var l in lst)
                {
                    Console.WriteLine(l.Valor);
                }
                Console.WriteLine("-------------");

                //---------------Update---------
                try
                {
                    Parametro per = db.Parametro.Where(d => d.Valor == 5).First();
                    per.Valor = 6;
                    db.Entry(per).State = EntityState.Modified; //al objeto parametro.Valor se le añade la flag modificado
                    db.SaveChanges();

                    var lst2 = db.Parametro;
                    Console.WriteLine("-----After Update:-----");
                    foreach (var l in lst2)
                    {
                        Console.WriteLine(l.Valor);
                    }
                    Console.WriteLine("-------------");
                }
                catch (Exception e)
                {
                    Console.WriteLine("No se encontro un parametro con el valor 5 .");
                    Console.WriteLine("Catch: '" + e.Message + "'");
                }

                //------------DELETE----------------
                int id_per = 1;
                try
                {
                    Parametro pers = db.Parametro.Find(id_per); //se usa find en vez de where si consoes el id
                    db.Parametro.Remove(pers);
                    db.SaveChanges();
                    Console.WriteLine("\nSe ha borrado a: " + pers.Valor);
                }
                catch (Exception e)
                {
                    Console.WriteLine("No se encontro un parametro con el valor " + id_per + ".");
                    Console.WriteLine("Catch: '" + e.Message + "'");
                }
                Console.WriteLine("\nPrecione Enter  para finalizar.");
                Console.Read();
            }
           
        }
    }
}



