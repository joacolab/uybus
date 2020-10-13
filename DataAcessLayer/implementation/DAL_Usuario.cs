using DataAcessLayer.conversores;
using DataAcessLayer.interfaces;
using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.implementation
{
    public class DAL_Usuario : IDAL_Usuario
    {
        public EUsuario addUsuario(int idPersona)
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    Usuario u = new Usuario();
                    u.Id = idPersona;
                    db.Usuario.Add(u);
                    db.SaveChanges();

                    EUsuario eu = new EUsuario();
                    eu = Converter.usuarioAEUsuario(u);
                    return eu;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public List<EUsuario> getAllUsuarios()
        {
            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    List<EUsuario> lstEu = new List<EUsuario>();

                    var usus = db.Usuario;

                    foreach (var u in usus)
                    {
                        EUsuario eu = new EUsuario();
                        eu = Converter.usuarioAEUsuario(u);
                        lstEu.Add(eu);
                    }
                    return lstEu;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public EUsuario getUsuario(int idUsuario)
        {

            try
            {
                using (uybusEntities db = new uybusEntities())
                {
                    Usuario u = db.Usuario.Find(idUsuario);
                    EUsuario eu = new EUsuario();
                    eu = Converter.usuarioAEUsuario(u);
                    return eu;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
