using ServiceFramework.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Data.Entity;

namespace UserManagement.Business.Validation
{
    internal class UserValidator : IValidator<Data.Entity.User>
    {
        public IEnumerable<ValidationResult> Validate(Data.Entity.User entity)
        {
            if (entity == null)
                yield return new ValidationResult(Common.CommonMessages.ValidationMessages.UserValidationMessages.UserEntityCanNotBeNull);

            if (String.IsNullOrEmpty(entity.FirstName))
                yield return new ValidationResult(Common.CommonMessages.ValidationMessages.UserValidationMessages.FirstNameCanNotBeBlank);

            if (String.IsNullOrEmpty(entity.LastName))
                yield return new ValidationResult(Common.CommonMessages.ValidationMessages.UserValidationMessages.LastNameCanNotBeBlank);

            if (entity.Age <= 0)
                yield return new ValidationResult(Common.CommonMessages.ValidationMessages.UserValidationMessages.AgeIsNotValid);
        }
    }
}
