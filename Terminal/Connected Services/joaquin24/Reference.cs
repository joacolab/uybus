﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Terminal.joaquin24 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="joaquin24.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetLineas", ReplyAction="http://tempuri.org/IService1/GetLineasResponse")]
        Share.entities.ELinea[] GetLineas();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetLineas", ReplyAction="http://tempuri.org/IService1/GetLineasResponse")]
        System.Threading.Tasks.Task<Share.entities.ELinea[]> GetLineasAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetSalidas", ReplyAction="http://tempuri.org/IService1/GetSalidasResponse")]
        Share.entities.ESalida[] GetSalidas(int lineaSelected);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetSalidas", ReplyAction="http://tempuri.org/IService1/GetSalidasResponse")]
        System.Threading.Tasks.Task<Share.entities.ESalida[]> GetSalidasAsync(int lineaSelected);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetParadasD", ReplyAction="http://tempuri.org/IService1/GetParadasDResponse")]
        Share.entities.EParada[] GetParadasD(int IdLinea, int IdParada);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetParadasD", ReplyAction="http://tempuri.org/IService1/GetParadasDResponse")]
        System.Threading.Tasks.Task<Share.entities.EParada[]> GetParadasDAsync(int IdLinea, int IdParada);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetViajes", ReplyAction="http://tempuri.org/IService1/GetViajesResponse")]
        Share.entities.EViaje[] GetViajes(int IdSalida);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetViajes", ReplyAction="http://tempuri.org/IService1/GetViajesResponse")]
        System.Threading.Tasks.Task<Share.entities.EViaje[]> GetViajesAsync(int IdSalida);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetParadas", ReplyAction="http://tempuri.org/IService1/GetParadasResponse")]
        Share.entities.EParada[] GetParadas(int IdLinea);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetParadas", ReplyAction="http://tempuri.org/IService1/GetParadasResponse")]
        System.Threading.Tasks.Task<Share.entities.EParada[]> GetParadasAsync(int IdLinea);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService1/GetDataUsingDataContractResponse")]
        API_SOAP.CompositeType GetDataUsingDataContract(API_SOAP.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService1/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<API_SOAP.CompositeType> GetDataUsingDataContractAsync(API_SOAP.CompositeType composite);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : Terminal.joaquin24.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<Terminal.joaquin24.IService1>, Terminal.joaquin24.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Share.entities.ELinea[] GetLineas() {
            return base.Channel.GetLineas();
        }
        
        public System.Threading.Tasks.Task<Share.entities.ELinea[]> GetLineasAsync() {
            return base.Channel.GetLineasAsync();
        }
        
        public Share.entities.ESalida[] GetSalidas(int lineaSelected) {
            return base.Channel.GetSalidas(lineaSelected);
        }
        
        public System.Threading.Tasks.Task<Share.entities.ESalida[]> GetSalidasAsync(int lineaSelected) {
            return base.Channel.GetSalidasAsync(lineaSelected);
        }
        
        public Share.entities.EParada[] GetParadasD(int IdLinea, int IdParada) {
            return base.Channel.GetParadasD(IdLinea, IdParada);
        }
        
        public System.Threading.Tasks.Task<Share.entities.EParada[]> GetParadasDAsync(int IdLinea, int IdParada) {
            return base.Channel.GetParadasDAsync(IdLinea, IdParada);
        }
        
        public Share.entities.EViaje[] GetViajes(int IdSalida) {
            return base.Channel.GetViajes(IdSalida);
        }
        
        public System.Threading.Tasks.Task<Share.entities.EViaje[]> GetViajesAsync(int IdSalida) {
            return base.Channel.GetViajesAsync(IdSalida);
        }
        
        public Share.entities.EParada[] GetParadas(int IdLinea) {
            return base.Channel.GetParadas(IdLinea);
        }
        
        public System.Threading.Tasks.Task<Share.entities.EParada[]> GetParadasAsync(int IdLinea) {
            return base.Channel.GetParadasAsync(IdLinea);
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public API_SOAP.CompositeType GetDataUsingDataContract(API_SOAP.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<API_SOAP.CompositeType> GetDataUsingDataContractAsync(API_SOAP.CompositeType composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
    }
}
