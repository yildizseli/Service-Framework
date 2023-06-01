using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceFramework.Common
{
    internal static class CommonMessages
    {
        internal static class LogMessages
        {
            public const string ServiceIsExecutedLogFormat = "{0} operation is executed in {1} ms. Identifier: {2}, IP: {3}. Result:{4}";
            public const string ServiceIsCalledLogFormat = "{0} operation is called. Identifier: {1}, IP: {2}. Input :{3}";
        }

        public static class ServiceResultMessage
        {
            public const string Unkown = "UNKOWN";
            public const string Successfull = "SUCCESSFULL";
            public const string Failed = "FAILED";
            public const string ValidationFailed = "VALIDATIONFAILED";

        }
    }
}

