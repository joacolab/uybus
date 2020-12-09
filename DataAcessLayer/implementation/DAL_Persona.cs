using DataAcessLayer.conversores;
using DataAcessLayer.interfaces;
using Share.entities;
using Share.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.implementation
{
    public class DAL_Persona : IDAL_Persona
    {
        public EPersona addPersona(string Documento, string Correo, string Password, int TipoDocumento, string pNombre, string sNombre, string pApellido, string sApellido)
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    var personas = db.Persona;
                    foreach (var per in personas)
                    {
                        if (per.Documento == Documento || per.Correo == Correo)
                        {
                            return null;
                        }
                    }
                    Persona p = new Persona();
                    p.Documento = Documento;
                    p.Correo = Correo;
                    p.Password = Password;
                    p.TipoDocumento = TipoDocumento;
                    p.pNombre = pNombre;
                    p.sNombre = sNombre;
                    p.pApellido = pApellido;
                    p.sApellido = sApellido;
                    db.Persona.Add(p);
                    db.SaveChanges();

                    EPersona ep = new EPersona();
                    ep = Converter.personaAEpersona(p);
                    return ep;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        
        public List<EPersona> getAllPersona()
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    List<EPersona> sltPer = new List<EPersona>();

                    foreach (var p in db.Persona)
                    {
                        sltPer.Add(Converter.personaAEpersona(p));
                    }
                    return sltPer;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        public EPersona getPersona(int id)
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    Persona p = db.Persona.Find(id);
                    if (p == null) return null;
                    EPersona ep = new EPersona();
                    ep = Converter.personaAEpersona(p);
                    return ep;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public EPersona getPerByEmail(string correo)
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    foreach (var p in db.Persona)
                    {
                        if (p.Correo == correo)
                        {
                            return Converter.personaAEpersona(p);
                        }
                    }
                    return new EPersona();
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public List<Rol> getRol(int id)
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    List < Rol > roles = new List<Rol>();
                    if (db.Admin.Find(id) != null) roles.Add(Rol.Admin);
                    if (db.SuperAdmin.Find(id) != null) roles.Add(Rol.SuperAdmin);
                    if (db.Conductor.Find(id) != null) roles.Add(Rol.Conductor);
                    if (db.Usuario.Find(id) != null) roles.Add(Rol.Usuario);
                    return roles;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
