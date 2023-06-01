using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace ServiceFramework.Service
{
    /// <summary>
    /// This class responsible to inspect service request and response
    /// Service operations is also logged within this class
    /// </summary>
    internal class BaseServiceInspector : IClientMessageInspector, IDispatchMessageInspector, IParameterInspector
    {
        private Guid requestIdentifier;
        private DateTime requestDate;
        private string serviceResult = String.Empty;
        private string consumerIPAddress = String.Empty;
        private string operationName = String.Empty;
        
        public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
        {
            try
            {
                serviceResult = JsonConvert.SerializeObject(returnValue, Formatting.Indented);
            }
            catch
            {
                serviceResult = String.Empty;
            }
        }

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
           
        }

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            try
            {
                requestIdentifier = Guid.NewGuid();
                requestDate = DateTime.Now;
                operationName = ServiceHelper.GetServiceOperationName(OperationContext.Current);
                consumerIPAddress = ServiceHelper.GetServiceConsumerIPAddress(OperationContext.Current);

                return null;
            }
            catch
            {
                throw;
            }
        }

        public object BeforeCall(string operationName, object[] inputs)
        {
            try
            {
                ServiceHelper.LogServiceIsCalled(operationName, requestIdentifier, consumerIPAddress, JsonConvert.SerializeObject(inputs, Formatting.Indented));
            }
            catch
            {
                //Dont break the flow for log exception
            }

            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            TimeSpan executeDuration = DateTime.Now - requestDate;
            ServiceHelper.LogServiceIsExecuted(operationName, executeDuration.Milliseconds,requestIdentifier, consumerIPAddress, serviceResult);
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            return null;
           
        }
    }
}
