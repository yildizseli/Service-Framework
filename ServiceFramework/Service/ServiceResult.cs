using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServiceFramework.Service
{
    /// <summary>
    /// Represents service result
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DataContract]
    public class ServiceResult<T>
    {
        private string _message = String.Empty;
        /// <summary>
        /// Generic service result
        /// </summary>
        [DataMember]
        public T Result { get; set; }

        /// <summary>
        /// Message of the result
        /// </summary>
        [DataMember]
        public string ResultMessage
        {
            get
            {
                if (!String.IsNullOrEmpty(_message))
                {
                    return _message;
                }
                else
                {
                    return GetDefaultMessage();

                }
            }
            set
            {
                _message = value;
            }
        }

        /// <summary>
        /// Service result status
        /// </summary>
        [DataMember]
        public ServiceResultStatus ResultStatus { get; set; }

        private string GetDefaultMessage()
        {
            switch (ResultStatus)
            {
                case ServiceResultStatus.Unknown:
                    return Common.CommonMessages.ServiceResultMessage.Unkown;
                case ServiceResultStatus.Successfull:
                    return Common.CommonMessages.ServiceResultMessage.Successfull;
                case ServiceResultStatus.Failed:
                    return Common.CommonMessages.ServiceResultMessage.Failed;
                case ServiceResultStatus.ValidationFailed:
                    return Common.CommonMessages.ServiceResultMessage.ValidationFailed;
                default:
                    return Common.CommonMessages.ServiceResultMessage.Unkown;
            }

        }
    }
}
