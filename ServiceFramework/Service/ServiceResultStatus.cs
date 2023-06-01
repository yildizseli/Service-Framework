using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServiceFramework.Service
{
    [DataContract]
    public enum ServiceResultStatus
    {
        /// <summary>
        /// Unknown
        /// </summary>
        [EnumMember(Value = "Unknown")]
        Unknown = 0,

        /// <summary>
        /// Successfull
        /// </summary>
        [EnumMember(Value = "Successfull")]
        Successfull = 1,

        /// <summary>
        /// Failed
        /// </summary>
        [EnumMember(Value = "Failed")]
        Failed = 2,

        /// <summary>
        /// Validation failed
        /// </summary>
        [EnumMember(Value = "ValidationFailed")]
        ValidationFailed = 3,

    }
}
