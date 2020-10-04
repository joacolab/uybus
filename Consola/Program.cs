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

            Persona per2 = new Persona();
            per2.Documento = "43235432";
            per2.TipoDocumento = "CI";
            per2.Nombre = "Julio Arrieta";
            per2.Password = "1234";
            per2.Correo = "jarrieta@gmail.com";
            db.Persona.Add(per2);
            db.SaveChanges();

            Persona per3 = new Persona();
            per3.Documento = "65435456";
            per3.TipoDocumento = "CI";
            per3.Nombre = "Juan Alvarez";
            per3.Password = "1234";
            per3.Correo = "juanalav@gmail.com";
            db.Persona.Add(per3);
            db.SaveChanges();

            Persona per4 = new Persona();
            per4.Documento = "87635865";
            per4.TipoDocumento = "CI";
            per4.Nombre = "Carlos Balbiani";
            per4.Password = "1234";
            per4.Correo = "cbml@gmail.com";
            db.Persona.Add(per4);
            db.SaveChanges();

            Persona per5 = new Persona();
            per5.Documento = "42335865";
            per5.TipoDocumento = "CI";
            per5.Nombre = "Elvio Lento";
            per5.Password = "1234";
            per5.Correo = "elvilen@gmail.com";
            db.Persona.Add(per5);
            db.SaveChanges();

            Persona per6 = new Persona();
            per6.Documento = "74535865";
            per6.TipoDocumento = "CI";
            per6.Nombre = "Mauro Acosta";
            per6.Password = "1234";
            per6.Correo = "MAC@gmail.com";
            db.Persona.Add(per6);
            db.SaveChanges();

            // ---------------------------ROLES------------------------------

            SuperAdmin sup = new SuperAdmin();
            sup.IdPersona = "65435456"; // Juan Alvarez, juanalav@gmail.com, 1234
            db.SuperAdmin.Add(sup);
            db.SaveChanges();

            Admin adm = new Admin();
            adm.IdPersona = "87635865"; // Carlos Balbiani, cbml@gmail.com, 1234
            db.Admin.Add(adm);
            db.SaveChanges();

            Usuario user = new Usuario();
            user.IdPersona = "45435876"; // Joaquin Suares, joaq@gmail.com, 1234
            db.Usuario.Add(user);
            db.SaveChanges();

            Conductor con = new Conductor();
            con.IdPersona = "43235432"; //Julio Arrieta, jarrieta@gmail.com, 1234
            db.Conductor.Add(con);
            db.SaveChanges();

            Conductor con2 = new Conductor();
            con2.IdPersona = "42335865"; //Elvio Lento, elvilen@gmail.com, 1234
            db.Conductor.Add(con2);
            db.SaveChanges();

            Conductor con3 = new Conductor();
            con3.IdPersona = "74535865"; //Mauro Acosta, MAC@gmail.com, 1234
            db.Conductor.Add(con3);
            db.SaveChanges();

            // ---------------------------PARAMETRO----------------------------------
            Parametro p = new Parametro();
            p.Valor = 30;
            db.Parametro.Add(p);
            db.SaveChanges();

            Parametro p2 = new Parametro();
            p2.Valor = 40;
            db.Parametro.Add(p2);
            db.SaveChanges();

            Parametro p3 = new Parametro();
            p3.Valor = 50;
            db.Parametro.Add(p3);
            db.SaveChanges();

            // ---------------------------VEHICULOS----------------------------------
            Vehiculo v = new Vehiculo();
            v.Matricula = "MAU1234";
            v.Marca = "Mercedes-Benz";
            v.Modelo = "O321";
            v.CantAsientos = 40;
            db.Vehiculo.Add(v);
            db.SaveChanges();

            Vehiculo v2 = new Vehiculo();
            v2.Matricula = "MAE6534";
            v2.Marca = "Mercedes-Benz";
            v2.Modelo = "O321";
            v2.CantAsientos = 40;
            db.Vehiculo.Add(v2);
            db.SaveChanges();

            Vehiculo v3 = new Vehiculo();
            v3.Matricula = "MAU7634";
            v3.Marca = "Mercedes-Benz";
            v3.Modelo = "O343";
            v3.CantAsientos = 32;
            db.Vehiculo.Add(v3);
            db.SaveChanges();

            Vehiculo v4 = new Vehiculo();
            v4.Matricula = "MA04321";
            v4.Marca = "Mercedes-Benz";
            v4.Modelo = "W243";
            v4.CantAsientos = 30;
            db.Vehiculo.Add(v4);
            db.SaveChanges();

            // ---------------------------LINEAS----------------------------------
            Linea a = new Linea();
            a.Nombre = "ROJA";
            db.Linea.Add(a);
            db.SaveChanges();

            Linea b = new Linea();
            b.Nombre = "VERDE";
            db.Linea.Add(b);
            db.SaveChanges();

            Linea c = new Linea();
            c.Nombre = "AZUL";
            db.Linea.Add(c);
            db.SaveChanges();
            // ---------------------------Parada----------------------------------
            Parada pa = new Parada();
            pa.Nombre = "Terminal Norte";
            pa.Lat = -34.900132;
            pa.Long = -56.171441;
            db.Parada.Add(pa);
            db.SaveChanges();

            Parada pa2 = new Parada();
            pa2.Nombre = "Colonia y martinez";
            pa2.Lat = -34.900169;
            pa2.Long = -56.171424;
            db.Parada.Add(pa2);
            db.SaveChanges();

            Parada pa3 = new Parada();
            pa3.Nombre = "18 de julio y Martinez";
            pa3.Lat = -34.900163;
            pa3.Long = -56.171434;
            db.Parada.Add(pa3);
            db.SaveChanges();

            Parada pa4 = new Parada();
            pa4.Nombre = "18 de julio y Arenal";
            pa4.Lat = -34.900187;
            pa4.Long = -56.171434;
            db.Parada.Add(pa4);
            db.SaveChanges();

            Parada pa5 = new Parada();
            pa5.Nombre = "18 de julio y Requena";
            pa5.Lat = -34.900187;
            pa5.Long = -56.171454;
            db.Parada.Add(pa5);
            db.SaveChanges();

            Parada pa6 = new Parada();
            pa6.Nombre = "Martinez y Laballeja";
            pa6.Lat = -34.900134;
            pa6.Long = -56.171465;
            db.Parada.Add(pa6);
            db.SaveChanges();

            Parada pa7 = new Parada();
            pa7.Nombre = "Terminal Sur";
            pa7.Lat = -34.900132;
            pa7.Long = -56.171443;
            db.Parada.Add(pa7);
            db.SaveChanges();
            // ---------------------------TRAMO----------------------------------

            Tramo t = new Tramo();
            t.IdLinea = db.Linea.Where(d => d.Nombre == "ROJA").First().IdLinea;
            t.IdParada = db.Parada.Where(d => d.Nombre == "Colonia y martinez").First().IdParada;
            t.TiempoEstimado = 50;
            db.Tramo.Add(t);
            db.SaveChanges();

            Tramo t1 = new Tramo();
            t1.IdLinea = db.Linea.Where(d => d.Nombre == "ROJA").First().IdLinea;
            t1.IdParada = db.Parada.Where(d => d.Nombre == "18 de julio y Martinez").First().IdParada;
            t1.TiempoEstimado = 60;
            db.Tramo.Add(t1);
            db.SaveChanges();

            Tramo t2 = new Tramo();
            t2.IdLinea = db.Linea.Where(d => d.Nombre == "ROJA").First().IdLinea;
            t2.IdParada = db.Parada.Where(d => d.Nombre == "18 de julio y Arenal").First().IdParada;
            t2.TiempoEstimado = 60;
            db.Tramo.Add(t2);
            db.SaveChanges();

            Tramo t3 = new Tramo();
            t3.IdLinea = db.Linea.Where(d => d.Nombre == "ROJA").First().IdLinea;
            t3.IdParada = db.Parada.Where(d => d.Nombre == "Terminal Sur").First().IdParada;
            t3.TiempoEstimado = 50;
            db.Tramo.Add(t3);
            db.SaveChanges();

            Tramo t4 = new Tramo();
            t4.IdLinea = db.Linea.Where(d => d.Nombre == "VERDE").First().IdLinea;
            t4.IdParada = db.Parada.Where(d => d.Nombre == "18 de julio y Requena").First().IdParada;
            t4.TiempoEstimado = 90;
            db.Tramo.Add(t4);
            db.SaveChanges();

            Tramo t5 = new Tramo();
            t5.IdLinea = db.Linea.Where(d => d.Nombre == "VERDE").First().IdLinea;
            t5.IdParada = db.Parada.Where(d => d.Nombre == "18 de julio y Martinez").First().IdParada;
            t5.TiempoEstimado = 60;
            db.Tramo.Add(t5);
            db.SaveChanges();

            Tramo t6 = new Tramo();
            t6.IdLinea = db.Linea.Where(d => d.Nombre == "VERDE").First().IdLinea;
            t6.IdParada = db.Parada.Where(d => d.Nombre == "18 de julio y Arenal").First().IdParada;
            t6.TiempoEstimado = 60;
            db.Tramo.Add(t6);
            db.SaveChanges();

            Tramo t7 = new Tramo();
            t7.IdLinea = db.Linea.Where(d => d.Nombre == "VERDE").First().IdLinea;
            t7.IdParada = db.Parada.Where(d => d.Nombre == "Terminal Sur").First().IdParada;
            t7.TiempoEstimado = 50;
            db.Tramo.Add(t7);
            db.SaveChanges();

            Tramo t8 = new Tramo();
            t8.IdLinea = db.Linea.Where(d => d.Nombre == "AZUL").First().IdLinea;
            t8.IdParada = db.Parada.Where(d => d.Nombre == "18 de julio y Requena").First().IdParada;
            t8.TiempoEstimado = 90;
            db.Tramo.Add(t8);
            db.SaveChanges();

            Tramo t9 = new Tramo();
            t9.IdLinea = db.Linea.Where(d => d.Nombre == "AZUL").First().IdLinea;
            t9.IdParada = db.Parada.Where(d => d.Nombre == "Martinez y Laballeja").First().IdParada;
            t9.TiempoEstimado = 120;
            db.Tramo.Add(t9);
            db.SaveChanges();

            Tramo t10 = new Tramo();
            t10.IdLinea = db.Linea.Where(d => d.Nombre == "AZUL").First().IdLinea;
            t10.IdParada = db.Parada.Where(d => d.Nombre == "Terminal Sur").First().IdParada;
            t10.TiempoEstimado = 90;
            db.Tramo.Add(t10);
            db.SaveChanges();

            // ---------------------------TRAMO----------------------------------

            Precio k = new Precio();
            k.IdLinea = db.Linea.Where(d => d.Nombre == "ROJA").First().IdLinea;
            k.IdParada = db.Parada.Where(d => d.Nombre == "Colonia y martinez").First().IdParada;
            k.Precio1 = 20;
            k.FechaEntradaVigencia = new DateTime(2020, 5, 1, 8, 30, 52);
            db.Precio.Add(k);
            db.SaveChanges();

            Precio k2 = new Precio();
            k2.IdLinea = db.Linea.Where(d => d.Nombre == "ROJA").First().IdLinea;
            k2.IdParada = db.Parada.Where(d => d.Nombre == "18 de julio y Martinez").First().IdParada;
            k2.Precio1 = 25;
            k2.FechaEntradaVigencia = new DateTime(2020, 5, 1, 8, 30, 52);
            db.Precio.Add(k2);
            db.SaveChanges();

            Precio k3 = new Precio();
            k3.IdLinea = db.Linea.Where(d => d.Nombre == "ROJA").First().IdLinea;
            k3.IdParada = db.Parada.Where(d => d.Nombre == "18 de julio y Arenal").First().IdParada;
            k3.Precio1 = 25;
            k3.FechaEntradaVigencia = new DateTime(2020, 5, 1, 8, 30, 52);
            db.Precio.Add(k3);
            db.SaveChanges();

            Precio k4 = new Precio();
            k4.IdLinea = db.Linea.Where(d => d.Nombre == "ROJA").First().IdLinea;
            k4.IdParada = db.Parada.Where(d => d.Nombre == "Terminal Sur").First().IdParada;
            k4.Precio1 = 20;
            k4.FechaEntradaVigencia = new DateTime(2020, 5, 1, 8, 30, 52);
            db.Precio.Add(k4);
            db.SaveChanges();

            Precio k5 = new Precio();
            k5.IdLinea = db.Linea.Where(d => d.Nombre == "VERDE").First().IdLinea;
            k5.IdParada = db.Parada.Where(d => d.Nombre == "18 de julio y Requena").First().IdParada;
            k5.Precio1 = 40;
            k5.FechaEntradaVigencia = new DateTime(2020, 5, 1, 8, 30, 52);
            db.Precio.Add(k5);
            db.SaveChanges();

            Precio k6 = new Precio();
            k6.IdLinea = db.Linea.Where(d => d.Nombre == "VERDE").First().IdLinea;
            k6.IdParada = db.Parada.Where(d => d.Nombre == "18 de julio y Martinez").First().IdParada;
            k6.Precio1 = 25;
            k6.FechaEntradaVigencia = new DateTime(2020, 5, 1, 8, 30, 52);
            db.Precio.Add(k6);
            db.SaveChanges();

            Precio k7 = new Precio();
            k7.IdLinea = db.Linea.Where(d => d.Nombre == "VERDE").First().IdLinea;
            k7.IdParada = db.Parada.Where(d => d.Nombre == "18 de julio y Arenal").First().IdParada;
            k7.Precio1 = 25;
            k7.FechaEntradaVigencia = new DateTime(2020, 5, 1, 8, 30, 52);
            db.Precio.Add(k7);
            db.SaveChanges();

            Precio k8 = new Precio();
            k8.IdLinea = db.Linea.Where(d => d.Nombre == "VERDE").First().IdLinea;
            k8.IdParada = db.Parada.Where(d => d.Nombre == "Terminal Sur").First().IdParada;
            k8.Precio1 = 20;
            k8.FechaEntradaVigencia = new DateTime(2020, 5, 1, 8, 30, 52);
            db.Precio.Add(k8);
            db.SaveChanges();

            Precio k9 = new Precio();
            k9.IdLinea = db.Linea.Where(d => d.Nombre == "AZUL").First().IdLinea;
            k9.IdParada = db.Parada.Where(d => d.Nombre == "18 de julio y Requena").First().IdParada;
            k9.Precio1 = 40;
            k9.FechaEntradaVigencia = new DateTime(2020, 5, 1, 8, 30, 52);
            db.Precio.Add(k9);
            db.SaveChanges();

            Precio k10 = new Precio();
            k10.IdLinea = db.Linea.Where(d => d.Nombre == "AZUL").First().IdLinea;
            k10.IdParada = db.Parada.Where(d => d.Nombre == "Martinez y Laballeja").First().IdParada;
            k10.Precio1 = 55;
            k10.FechaEntradaVigencia = new DateTime(2020, 5, 1, 8, 30, 52);
            db.Precio.Add(k10);
            db.SaveChanges();

            Precio k11 = new Precio();
            k11.IdLinea = db.Linea.Where(d => d.Nombre == "AZUL").First().IdLinea;
            k11.IdParada = db.Parada.Where(d => d.Nombre == "Terminal Sur").First().IdParada;
            k11.Precio1 = 40;
            k11.FechaEntradaVigencia = new DateTime(2020, 5, 1, 8, 30, 52);
            db.Precio.Add(k11);
            db.SaveChanges();
            // ---------------------------SALIDA----------------------------------
            Salida s = new Salida();
            s.IdConductor = db.Conductor.Where(d => d.IdPersona == "43235432").First().IdConductor;
            s.IdVehiculo = "MAU1234";
            s.IdLinea = db.Linea.Where(d => d.Nombre == "ROJA").First().IdLinea;
            s.HoraInicio = new TimeSpan(9, 00, 00);
            db.Salida.Add(s);
            db.SaveChanges();

            Salida s2 = new Salida();
            s2.IdConductor = db.Conductor.Where(d => d.IdPersona == "42335865").First().IdConductor;
            s2.IdVehiculo = "MAE6534";
            s2.IdLinea = db.Linea.Where(d => d.Nombre == "VERDE").First().IdLinea;
            s2.HoraInicio = new TimeSpan(9, 00, 00);
            db.Salida.Add(s2);
            db.SaveChanges();

            Salida s3 = new Salida();
            s3.IdConductor = db.Conductor.Where(d => d.IdPersona == "74535865").First().IdConductor;
            s3.IdVehiculo = "MA04321";
            s3.IdLinea = db.Linea.Where(d => d.Nombre == "AZUL").First().IdLinea;
            s3.HoraInicio = new TimeSpan(9, 00, 00);
            db.Salida.Add(s3);
            db.SaveChanges();

            // ---------------------------VIAJES----------------------------------

            Viaje vi = new Viaje();
            vi.Fecha = new DateTime(2020, 10, 1, 9, 00, 00);
            int idC = db.Conductor.Where(e => e.IdPersona == "43235432").First().IdConductor;
            vi.IdSalida = db.Salida.Where(d => d.IdConductor == idC).First().IdConductor;
            db.Viaje.Add(vi);
            db.SaveChanges();

            Viaje vi2 = new Viaje();
            vi2.Fecha = new DateTime(2020, 10, 1, 9, 00, 00);
            int idC2 = db.Conductor.Where(e => e.IdPersona == "42335865").First().IdConductor;
            vi2.IdSalida = db.Salida.Where(d => d.IdConductor == idC2).First().IdConductor;
            db.Viaje.Add(vi2);
            db.SaveChanges();

            Viaje vi3 = new Viaje();
            vi3.Fecha = new DateTime(2020, 10, 1, 9, 00, 00);
            int idC3 = db.Conductor.Where(e => e.IdPersona == "74535865").First().IdConductor;
            vi3.IdSalida = db.Salida.Where(d => d.IdConductor == idC3).First().IdConductor;
            db.Viaje.Add(vi3);
            db.SaveChanges();

            // ---------------------------PASAJE----------------------------------

            Pasaje pas = new Pasaje();
            pas.TipoDocuemtno = "CI";
            pas.Documento = "45435876";
            pas.IdViaje = 1;
            pas.IdUsuario = 1;
            pas.IdParadaOrigen = 1;
            pas.IdParadaDestino = 2;
            db.Pasaje.Add(pas);
            db.SaveChanges();

            Pasaje pas2 = new Pasaje();
            pas2.TipoDocuemtno = "CI";
            pas2.Documento = "45435876";
            pas2.IdViaje = 2;
            pas2.IdUsuario = 1;
            pas2.IdParadaOrigen = 2;
            pas2.IdParadaDestino = 3;
            db.Pasaje.Add(pas2);
            db.SaveChanges();


            Console.WriteLine("Datos de prueva cargados exitosamente");
        }
        static void Main(string[] args)
        {
            using (uybusEntities db = new uybusEntities())
            {
                //datosDePrueba(db); //Descomentar para cargar datos a la base de datos uytube
                var lst = db.Persona;
                foreach (var l in lst)
                {
                    Console.WriteLine(l.Nombre);
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



