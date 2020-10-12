using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Consola
{
    class Program
    {
        /*
        static void datosDePrueba(uybusEntities db)
        {

            // --------------------------PERSONAS-------------------------------
            Persona per = new Persona();
            per.Documento = "45435876";
            per.TipoDocumento = "CI";
            per.Nombre = "Joaquin Suares";
            per.Password = "1234";
            per.Correo = "joaq@gmail.com";
            db.Persona.Add(per);
            db.SaveChanges();

            Console.WriteLine("Datos de prueva cargados exitosamente");
        }
        */
        static void Main(string[] args)
        {
            using (uybusEntities db = new uybusEntities())
            {

                //datosDePrueba(db); //Descomentar para cargar datos a la base de datos uytube
                var lst = db.Persona;
                foreach (var l in lst)
                {
                    //Console.WriteLine(l.Nombre);
                }
                Console.WriteLine("Si no Obtubiste ningun resultado, descomenta la linea 461. ");
                /*
                //---------------Select all---------
                var lst = db.persona;
                Console.WriteLine("-----Selet All:-----");
                foreach (var l in lst)
                {
                    Console.WriteLine(l.nombre);
                }
                Console.WriteLine("-------------");

                //---------------Update---------
                try
                {
                    persona per = db.persona.Where(d => d.nombre == "Carlos").First();
                    per.nombre = "Carlitos";
                    db.Entry(per).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    var lst2 = db.persona;
                    Console.WriteLine("-----After Update:-----");
                    foreach (var l in lst2)
                    {
                        Console.WriteLine(l.nombre);
                    }
                    Console.WriteLine("-------------");
                }
                catch (Exception e)
                {
                    Console.WriteLine("No se encontro una persona con el nombre Carlos.");
                    Console.WriteLine("Catch: '" + e.Message + "'");
                }


                //------------DELETE----------------
                int id_per = 7;
                try
                {
                    persona pers = db.persona.Find(id_per); //se usa find en vez de where si consoes el id
                    db.persona.Remove(pers);
                    db.SaveChanges();
                    Console.WriteLine("\nSe ha borrado a: " + pers.nombre);
                }
                catch (Exception e)
                {
                    Console.WriteLine("No se encontro una persona con el id " + id_per + ".");
                    Console.WriteLine("Catch: '" + e.Message + "'");
                }
                */
            }
            Console.WriteLine("\nPrecione Enter  para finalizar.");
            Console.Read();
        }
    }
}



