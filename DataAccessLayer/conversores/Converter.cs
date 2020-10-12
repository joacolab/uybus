using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.conversores
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
            return c;
        }

        /// <summary>
        /// Convierte un conductor a un Econductor
        /// </summary>
        /// <param name="c">Objeto de tipo Conductor del Modelo</param>
        /// <returns>Econcuctor</returns>
        static public EConductor conductorAEConductor(Conductor c)
        {
            EConductor ec = new EConductor();
            ec.Id = c.Id;
            ec.VencimientoLicencia = c.VencimientoLicencia;
            return ec;
        }

        static public Tramo etramoATramo(ETramo et)
        {
            Tramo t = new Tramo();
            t.IdLinea = et.IdLinea;
            t.IdParada = et.IdParada;
            t.TiempoEstimado = et.TiempoEstimado;
            return t;
        }

        /// <summary>
        /// Convierte un Modelo Tramo a un ETramo 
        /// </summary>
        /// <param name="t"></param>
        /// <returns>ETramo</returns>
        static public ETramo tramoAETramo(Tramo t)
        {
            ETramo et = new ETramo();
            et.IdLinea = t.IdLinea;
            et.IdParada = t.IdParada;
            et.TiempoEstimado = t.TiempoEstimado;
            return et;
        }

        static public ELinea lineaAElinea(Linea l)
        {
            ELinea el = new ELinea();
            el.IdLinea = l.IdLinea;
            el.Nombre = l.Nombre;
            return el;
        }

        static public Linea elineaALinea(ELinea el)
        {
            Linea l = new Linea();
            l.IdLinea = el.IdLinea;
            l.Nombre = el.Nombre;
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
            return v;
        }

        static public EVehiculo vehiculoAEVehiculo(Vehiculo v)
        {
            EVehiculo ev = new EVehiculo();
            ev.Matricula = v.Matricula;
            ev.Modelo = v.Modelo;
            ev.Marca = v.Marca;
            ev.CantAsientos = v.CantAsientos;
            return ev;
        }

        static public EParada paradaAEParada(Parada par)
        {
            EParada Epar = new EParada();
            Epar.IdParada = par.IdParada;
            Epar.Nombre = par.Nombre;
            Epar.Lat = par.Lat;
            Epar.Long = par.Long;
            return Epar;
        }

        static public Parada eparadaAParada(EParada Epar)
        {
            Parada par = new Parada();
            par.IdParada = Epar.IdParada;
            par.Nombre = Epar.Nombre;
            par.Lat = Epar.Lat;
            par.Long = Epar.Long;
            return par;
        }


        static public EViaje viajeAEViaje(Viaje vi)
        {
            EViaje Evi = new EViaje();
            Evi.IdViaje = vi.IdViaje;
            Evi.Finalizado = vi.Finalizado;
            Evi.Fecha = vi.Fecha;
            Evi.HoraInicioReal = vi.HoraInicioReal;
            Evi.IdSalida = vi.IdSalida;
            return Evi;
        }

        static public Viaje eviajeAViaje(EViaje Evi)
        {
            Viaje vi = new Viaje();
            vi.IdViaje = Evi.IdViaje;
            vi.Finalizado = Evi.Finalizado;
            vi.Fecha = Evi.Fecha;
            vi.HoraInicioReal = Evi.HoraInicioReal;
            vi.IdSalida = Evi.IdSalida;
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
