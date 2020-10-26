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
        //  List<EParada> GetEParadas();

        public List<EViaje> GetFechasViajes(int IdSalida)
        {
            return blu.GetFechasViajes(IdSalida);
        }
        
        public List<EParada> GetParadas(int IdLinea)
        {
            return blu.listarParadas(IdLinea);
        }
        public List<ELinea> GetLineas()
        {
            return blu.listarLineas();
        }

        public List<EParada> GetParadasD(int IdLinea, int IdParada)
        {
            return blu.listarParadasD(IdLinea, IdParada);
        }

        public List<ESalida> GetSalidas(int lineaSelected) {
            return blu.GetSalidas(lineaSelected);
        }

        //  public List<EViaje> GetViajes(int IdSalida)
        //{
        //  return blu.GetViajes(IdSalida);
        //}

        public List<int> GetAsientos(int fechaSelected) 
        {
            return blu.GetAsientos(fechaSelected);
        }

        public bool canSelectSeat(int IdLinea, int idParadaOrigen, int idParadaDestino)
        {
            return blu.canSelectSeat(IdLinea, idParadaOrigen, idParadaDestino);
        }

        public int precioDelPasaje(int IdLinea, int idParadaOrigen, int idParadaDestino)
        {
            return blu.precioDelPasaje(IdLinea, idParadaOrigen, idParadaDestino);
        }

        public void comprarPasaje(int IdViaje, int UserId, int paradaOId, int paradaDId, int TipoDocumento, string Documento, int Asiento)
        {
            string tp;
            if (TipoDocumento == 1)
            {
                tp = "CI";
            }
            else 
            {
                tp = "Credencial";
            }
           blu.comprarPasaje(IdViaje,UserId, paradaOId, paradaDId,tp,Documento,Asiento);
        }
    }
}


