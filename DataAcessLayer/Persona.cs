//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAcessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Persona
    {
        public int id { get; set; }
        public string Documento { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public int TipoDocumento { get; set; }
        public string pNombre { get; set; }
        public string sNombre { get; set; }
        public string pApellido { get; set; }
        public string sApellido { get; set; }
    
        public virtual Admin Admin { get; set; }
        public virtual Conductor Conductor { get; set; }
        public virtual SuperAdmin SuperAdmin { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
