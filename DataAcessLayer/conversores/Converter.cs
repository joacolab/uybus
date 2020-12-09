using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.conversores
{
    public class Converter
    {
        static public EPersona personaAEpersona(Persona per)
        {
            EPersona Eper = new EPersona();
            Eper.id = per.id;
            Eper.Documento = per.Documento;
            Eper.Correo = per.Correo;
            Eper.Password = per.Password;
            Eper.TipoDocumento = per.TipoDocumento;
            Eper.pNombre = per.pNombre;
            Eper.sNombre = per.sNombre;
            Eper.pApellido = per.pApellido;
            Eper.sApellido = per.sApellido;
            return Eper;
        }
        static public Persona epersonaAPersona(EPersona ep)
        {
            Persona p = new Persona();
            p.id = ep.id;
            p.Documento = ep.Documento;
            p.Correo = ep.Correo;
            p.TipoDocumento = ep.TipoDocumento;
            p.pNombre = ep.pNombre;
            p.sNombre = ep.sNombre;
            p.pApellido = ep.pApellido;
            p.Password = ep.Password;
            return p;
        }
        static public Conductor econductorAConductor(EConductor ec)
        {
            Conductor c = new Conductor();
            c.Id = ec.Id;
            c.VencimientoLicencia = ec.VencimientoLicencia;

            List<Salida> lst = new List<Salida>();
            foreach (var s in ec.Salida)
            {
                lst.Add(esalidaASalida(s));
            }
            c.Salida = lst;
            return c;
        }
        static public EConductor conductorAEConductor(Conductor c)
        {
            EConductor ec = new EConductor();
            ec.Id = c.Id;
            ec.VencimientoLicencia = c.VencimientoLicencia;

            List<ESalida> lst = new List<ESalida>();
            foreach (var s in c.Salida)
            {
                lst.Add(salidaAESalida(s));
            }
            ec.Salida = lst;
            return ec;
        }
        static public Tramo etramoATramo(ETramo et)
        {
            Tramo t = new Tramo();
            t.IdLinea = et.IdLinea;
            t.IdParada = et.IdParada;
            t.TiempoEstimado = et.TiempoEstimado;
            t.Orden = et.Orden;
            List<Precio> lst = new List<Precio>();
            foreach (var s in et.Precio)
            {
                lst.Add(eprecioAPrecio(s));
            }
            t.Precio = lst;
            return t;
        }
        static public ETramo tramoAETramo(Tramo t)
        {
            ETramo et = new ETramo();
            et.IdLinea = t.IdLinea;
            et.IdParada = t.IdParada;
            et.TiempoEstimado = t.TiempoEstimado;
            et.Orden = t.Orden;
            List <EPrecio> lst = new List<EPrecio>();
            foreach (var s in t.Precio)
            {
                lst.Add(precioAEPrecio(s));
            }
            et.Precio = lst;
            return et;
        }
        static public ELinea lineaAElinea(Linea l)
        {
            ELinea el = new ELinea();
            el.IdLinea = l.IdLinea;
            el.Nombre = l.Nombre;

            List<ESalida> lst = new List<ESalida>();
            foreach (var s in l.Salida)
            {
                lst.Add(salidaAESalida(s));
            }
            el.Salida = lst;

            List<ETramo> lst2 = new List<ETramo>();
            foreach (var s in l.Tramo)
            {
                lst2.Add(tramoAETramo(s));
            }
            el.Tramo = lst2;
            return el;
        }
        static public Linea elineaALinea(ELinea el)
        {
            Linea l = new Linea();
            l.IdLinea = el.IdLinea;
            l.Nombre = el.Nombre;

            List<Salida> lst = new List<Salida>();
            foreach (var s in el.Salida)
            {
                lst.Add(esalidaASalida(s));
            }
            l.Salida = lst;

            List<Tramo> lst2 = new List<Tramo>();
            foreach (var s in el.Tramo)
            {
                lst2.Add(etramoATramo(s));
            }
            l.Tramo = lst2;
            return l;
        }
        static public EParametro parametroAEParametro(Parametro p)
        {
            EParametro ep = new EParametro();
            ep.IdParametro = p.IdParametro;
            ep.Valor = p.Valor;
            return ep;
        }
        static public Parametro eparametroAParametro(EParametro ep)
        {
            Parametro p = new Parametro();
            p.IdParametro = ep.IdParametro;
            p.Valor = ep.Valor;
            return p;
        }
        static public Precio eprecioAPrecio(EPrecio ep)
        {
            Precio p = new Precio();
            p.IdPrecio = ep.IdPrecio;
            p.Precio1 = ep.Precio1;
            p.FechaEntradaVigencia = ep.FechaEntradaVigencia;
            p.IdLinea = ep.IdLinea;
            p.IdParada = ep.IdParada;
            return p;
        }
        static public EPrecio precioAEPrecio(Precio p)
        {
            EPrecio ep = new EPrecio();
            ep.IdPrecio = p.IdPrecio;
            ep.Precio1 = p.Precio1;
            ep.FechaEntradaVigencia = p.FechaEntradaVigencia;
            ep.IdLinea = p.IdLinea;
            ep.IdParada = p.IdParada;
            return ep;
        }
        static public Vehiculo evehiculoAVehiculo(EVehiculo ev)
        {
            Vehiculo v = new Vehiculo();
            v.Matricula = ev.Matricula;
            v.Modelo = ev.Modelo;
            v.Marca = ev.Marca;
            v.CantAsientos = ev.CantAsientos;
            List<Salida> lst = new List<Salida>();
            foreach (var s in ev.Salida)
            {
                lst.Add(esalidaASalida(s));
            }
            v.Salida = lst;
            return v;
        }
        static public EVehiculo vehiculoAEVehiculo(Vehiculo v)
        {
            EVehiculo ev = new EVehiculo();
            ev.Matricula = v.Matricula;
            ev.Modelo = v.Modelo;
            ev.Marca = v.Marca;
            ev.CantAsientos = v.CantAsientos;
            List<ESalida> lst = new List<ESalida>();
            foreach (var s in v.Salida)
            {
                lst.Add(salidaAESalida(s));
            }
            ev.Salida = lst;
            return ev;
        }
        static public Usuario eusuarioAUsuario(EUsuario eu)
        {
            Usuario u = new Usuario();
            u.Id = eu.Id;
            List<Pasaje> lst = new List<Pasaje>();
            foreach (var s in eu.Pasaje)
            {
                lst.Add(epasajeAPasaje(s));
            }
            u.Pasaje = lst;
            return u;
        }
        static public EUsuario usuarioAEUsuario(Usuario u)
        {
            EUsuario eu = new EUsuario();
            if (u == null) return null; //Si viene un null retorna un null
            eu.Id = u.Id;
            List<EPasaje> lst = new List<EPasaje>();
            foreach (var s in u.Pasaje)
            {
                lst.Add(pasajeAEPasaje(s));
            }
            eu.Pasaje = lst;
            return eu;
        }
        static public EParada paradaAEParada(Parada par)
        {
            EParada Epar = new EParada();
            Epar.IdParada = par.IdParada;
            Epar.Nombre = par.Nombre;
            Epar.Lat = par.Lat;
            Epar.Long = par.Long;

            List<EPasaje> lst = new List<EPasaje>();
            foreach (var s in par.Pasaje)
            {
                lst.Add(pasajeAEPasaje(s));
            }
            Epar.Pasaje = lst;

            List<EPasaje> lst2 = new List<EPasaje>();
            foreach (var s in par.Pasaje1)
            {
                lst2.Add(pasajeAEPasaje(s));
            }
            Epar.Pasaje1 = lst2;

            List<ETramo> lst3 = new List<ETramo>();
            foreach (var s in par.Tramo)
            {
                lst3.Add(tramoAETramo(s));
            }
            Epar.Tramo = lst3;

            List<ELlegada> lst4 = new List<ELlegada>();
            foreach (var s in par.Llegada)
            {
                lst4.Add(llegadaAEllegada(s));
            }
            Epar.Llegada = lst4;
            return Epar;
        }
        static public Parada eparadaAParada(EParada Epar)
        {
            Parada par = new Parada();
            par.IdParada = Epar.IdParada;
            par.Nombre = Epar.Nombre;
            par.Lat = Epar.Lat;
            par.Long = Epar.Long;

            List<Pasaje> lst = new List<Pasaje>();
            foreach (var s in Epar.Pasaje)
            {
                lst.Add(epasajeAPasaje(s));
            }
            par.Pasaje = lst;

            List<Pasaje> lst2 = new List<Pasaje>();
            foreach (var s in Epar.Pasaje1)
            {
                lst2.Add(epasajeAPasaje(s));
            }
            par.Pasaje1 = lst2;

            List<Tramo> lst3 = new List<Tramo>();
            foreach (var s in Epar.Tramo)
            {
                lst3.Add(etramoATramo(s));
            }
            par.Tramo = lst3;

            List<Llegada> lst4 = new List<Llegada>();
            foreach (var s in Epar.Llegada)
            {
                lst4.Add(ellegadaAllegada(s));
            }
            par.Llegada = lst4;
            return par;
        }
        static public EViaje viajeAEViaje(Viaje vi)
        {
            if (vi == null) return null; //Si recibe un null retorna null
            EViaje Evi = new EViaje();
            Evi.IdViaje = vi.IdViaje;
            Evi.Finalizado = vi.Finalizado;
            Evi.Fecha = vi.Fecha;
            Evi.HoraInicioReal = vi.HoraInicioReal;
            Evi.IdSalida = vi.IdSalida;
            List<EPasaje> lst = new List<EPasaje>();
            foreach (var s in vi.Pasaje)
            {
                lst.Add(pasajeAEPasaje(s));
            }
            Evi.Pasaje = lst;

            List<ELlegada> lst2 = new List<ELlegada>();
            foreach (var s in vi.Llegada)
            {
                lst2.Add(llegadaAEllegada(s));
            }
            Evi.Llegada = lst2;
            return Evi;
        }
        static public ELlegada llegadaAEllegada(Llegada ll)
        {
            ELlegada el = new ELlegada();
            el.idParada = ll.idParada;
            el.idViaje = ll.idViaje;
            el.hora = ll.hora;
            el.fecha = ll.fecha;
            return el;
        }
        static public Llegada ellegadaAllegada(ELlegada el)
        {
            Llegada ll = new Llegada();
            ll.idParada = el.idParada;
            ll.idViaje = el.idViaje;
            ll.hora = el.hora;
            ll.fecha = el.fecha;
            return ll;
        }
        static public Viaje eviajeAViaje(EViaje Evi)
        {
            Viaje vi = new Viaje();
            vi.IdViaje = Evi.IdViaje;
            vi.Finalizado = Evi.Finalizado;
            vi.Fecha = Evi.Fecha;
            vi.HoraInicioReal = Evi.HoraInicioReal;
            vi.IdSalida = Evi.IdSalida;
            List<Pasaje> lst = new List<Pasaje>();
            foreach (var s in Evi.Pasaje)
            {
                lst.Add(epasajeAPasaje(s));
            }
            vi.Pasaje = lst;

            List<Llegada> lst2 = new List<Llegada>();
            foreach (var s in Evi.Llegada)
            {
                lst2.Add(ellegadaAllegada(s));
            }
            vi.Llegada = lst2;
            return vi;
        }
        static public ESalida salidaAESalida(Salida sal)
        {
            ESalida Esal = new ESalida();
            Esal.IdSalida = sal.IdSalida;
            Esal.HoraInicio = sal.HoraInicio;
            Esal.IdConductor = sal.IdConductor;
            Esal.IdVehiculo = sal.IdVehiculo;
            Esal.IdLinea = sal.IdLinea;

            List<EViaje> lst = new List<EViaje>();
            foreach (var s in sal.Viaje)
            {
                lst.Add(viajeAEViaje(s));
            }
            Esal.Viaje = lst;
            return Esal;
        }
        static public Salida esalidaASalida(ESalida Esal)
        {
            Salida sal = new Salida();
            sal.IdSalida = Esal.IdSalida;
            sal.HoraInicio = Esal.HoraInicio;
            sal.IdConductor = Esal.IdConductor;
            sal.IdVehiculo = Esal.IdVehiculo;
            sal.IdLinea = Esal.IdLinea;
            List<Viaje> lst = new List<Viaje>();
            foreach (var s in Esal.Viaje)
            {
                lst.Add(eviajeAViaje(s));
            }
            sal.Viaje = lst;
            return sal;
        }
        static public EPasaje pasajeAEPasaje(Pasaje pas)
        {

            EPasaje Epas = new EPasaje();
            Epas.IdPasaje = pas.IdPasaje;
            Epas.Asientos = pas.Asientos;
            Epas.Documento = pas.Documento;
            Epas.TipoDocuemtno = pas.TipoDocuemtno;
            Epas.IdUsuario = pas.IdUsuario;
            Epas.IdViaje = pas.IdViaje;
            Epas.IdParadaDestino = pas.IdParadaDestino;
            Epas.IdParadaOrigen = pas.IdParadaOrigen;
            return Epas;
        }
        static public Pasaje epasajeAPasaje(EPasaje Epas)
        {
            Pasaje pas = new Pasaje();
            pas.IdPasaje = Epas.IdPasaje;
            pas.Asientos = Epas.Asientos;
            pas.Documento = Epas.Documento;
            pas.TipoDocuemtno = Epas.TipoDocuemtno;
            pas.IdUsuario = Epas.IdUsuario;
            pas.IdViaje = Epas.IdViaje;
            pas.IdParadaDestino = Epas.IdParadaDestino;
            pas.IdParadaOrigen = Epas.IdParadaOrigen;
            return pas;
        }
    }
}
