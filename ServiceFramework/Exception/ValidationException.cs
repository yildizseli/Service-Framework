using ServiceFramework.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceFramework.Exception
{
    public class ValidationException : System.Exception
    {
        public string ValidationMessages { get; set; }

        public ValidationException(IEnumerable<ValidationResult> validationResults)
        {
            ValidationMessages = String.Join(" ,", validationResults.Select(i => i.Message));
        }
    }
}
