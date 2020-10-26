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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<ELinea> GetLineas();

        [OperationContract]
        List<ESalida> GetSalidas(int lineaSelected);

        [OperationContract]
        List<EParada> GetParadasD(int IdLinea, int IdParada);

        //[OperationContract]
        // List<EViaje> GetViajes(int IdSalida);

        [OperationContract]
        bool canSelectSeat(int IdLinea, int idParadaOrigen, int idParadaDestino);

        [OperationContract]
        int precioDelPasaje(int IdLinea, int idParadaOrigen, int idParadaDestino);

        [OperationContract]
        List<int> GetAsientos(int fechaSelected);
        // List<ESalida> GetFechasViajes()
        [OperationContract]
        List<EViaje> GetFechasViajes(int IdSalida);


        [OperationContract]
        List<EParada> GetParadas(int IdLinea);

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        void comprarPasaje(int IdViaje, int UserId, int paradaOId, int paradaDId, int TipoDocumento, string Documento, int Asiento);


        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: agregue aquí sus operaciones de servicio
    }


    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
