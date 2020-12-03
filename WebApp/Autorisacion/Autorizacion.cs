using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Autorisacion
{
    public class Autorizacion: AuthorizeAttribute
    {
        private readonly string[] allowedroles;
        public bool admin { get; set; } = false;
        public bool superadmin { get; set; } = false;
        public bool usuario { get; set; } = false;
        public bool conductor { get; set; } = false;

        public bool logeado { get; set; } = true;

        public Autorizacion(params string[] roles)
        {
            this.allowedroles = roles;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (!logeado)
            {
                return true;
            }

            if (httpContext.Session["idPersona"] == null)
            {
                httpContext.Session.Clear();
                return false;
            }

            if (admin)
            {
                if (httpContext.Session["Rol"].ToString() == "Admin")
                {
                    return true;
                }
                else
                {
                    httpContext.Session.Clear();
                    return false;
                }
            }
            if (superadmin)
            {
                if (httpContext.Session["Rol"].ToString() == "SuperAdmin")
                {
                    return true;
                }
                else
                {
                    httpContext.Session.Clear();
                    return false;
                }
            }
            if (usuario)
            {
                if (httpContext.Session["Rol"].ToString() == "Usuario")
                {
                    return true;
                }
                else
                {
                    httpContext.Session.Clear();
                    return false;
                }
            }
            if (conductor)
            {
                if (httpContext.Session["Rol"].ToString() == "Conductor")
                {
                    return true;
                }
                else
                {
                    httpContext.Session.Clear();
                    return false;
                }
            }
            httpContext.Session.Clear();
            return false;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpUnauthorizedResult();
        }
    }
}