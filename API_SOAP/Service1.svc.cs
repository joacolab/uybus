using BuisnessLayer.implementation;
using BuisnessLayer.interfaces;
using DataAcessLayer.implementation;
using Share.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace API_SOAP
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        IBL_Usuario blu = new BL_Usuario(new DAL_Persona(), new DAL_Usuario(), new DAL_Linea(), new DAL_Salida(), new DAL_Tramo(), new DAL_Viaje(), new DAL_Pasaje(), new DAL_Parametro(), new DAL_Parada(), new DAL_Llegada(), new DAL_Vehiculo());
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public List<ELinea> GetLineas()
        {
            throw new NotImplementedException();
        }
    }
}
