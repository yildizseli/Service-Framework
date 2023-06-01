using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceFramework.Validation
{
    public interface IValidator<T>
    {
        IEnumerable<ValidationResult> Validate(T entity);
    }
}
