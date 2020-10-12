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
    }
}
