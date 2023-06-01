using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Diagnostics;

namespace ServiceFramework.Service
{
    public sealed class ServiceHelper
    {
        /// <summary>
        /// Returns the name of requested service operation's name
        /// </summary>
        /// <param name="operationContext"></param>
        /// <returns>Name of operation</returns>
        internal static string GetServiceOperationName(OperationContext operationContext)
        {
            string operationName = String.Empty;
            if (IsRest(operationContext))
            {
                operationName = operationContext.IncomingMessageProperties["HttpOperationName"] as string;
            }
            else
            {
                MessageHeaders soapHeader = operationContext.RequestContext.RequestMessage.Headers;
                operationName = soapHeader.Action.Substring(soapHeader.Action.LastIndexOf('/') + 1);
            }
            return operationName;
        }

        /// <summary>
        /// Returns if service is a REST service
        /// </summary>
        /// <param name="operationContext"></param>
        /// <returns>true if service is a REST service, false if service is a SOAP service </returns>
        internal static bool IsRest(OperationContext operationContext)
        {
            string bindingName = operationContext.EndpointDispatcher.ChannelDispatcher.BindingName;
            return bindingName.Contains("WebHttpBinding");

        }

        /// <summary>
        /// Get service Consumer's IP Address
        /// </summary>
        /// <param name="operationContext"></param>
        /// <returns></returns>
        internal static string GetServiceConsumerIPAddress(OperationContext operationContext)
        {
            string ipAddress = String.Empty;
            try
            {
                ipAddress = (operationContext.IncomingMessageProperties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty).Address;
            }
            catch
            {
                ipAddress = "NOT_RESOLVED";
            }
            return ipAddress;
        }

        /// <summary>
        /// Log detail of service is executed
        /// </summary>
        /// <param name="operationName">Operation name of service</param>
        /// <param name="requestIdentifier">Request Identifier of service</param>
        /// <param name="IPAddress">IP Address of service consumer</param>
        /// <param name="serviceResult">Service result json data</param>
        internal static void LogServiceIsExecuted(string operationName, int duration, Guid requestIdentifier, string IPAddress, string serviceResult)
        {
            string logMessage = String.Format(Common.CommonMessages.LogMessages.ServiceIsExecutedLogFormat, operationName, duration, requestIdentifier, IPAddress, serviceResult);
            Debug.WriteLine(logMessage);
        }

        /// <summary>
        /// Log detail of service is called
        /// </summary>
        /// <param name="operationName">Operation name of service</param>
        /// <param name="requestIdentifier">Request Identifier of service</param>
        /// <param name="IPAddress">IP Address of service consumer</param>
        /// <param name="input">Service input json data</param>
        internal static void LogServiceIsCalled(string operationName, Guid requestIdentifier, string IPAddress, string input)
        {
            string logMessage = String.Format(Common.CommonMessages.LogMessages.ServiceIsCalledLogFormat, operationName, requestIdentifier, IPAddress, input);
            Debug.WriteLine(logMessage);
        }
    }
}
