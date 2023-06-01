using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Common
{
    internal static class CommonMessages
    {
        internal static class ErrorMessages
        {
            public const string NoFoundUserIdFormat = "No user is found with ID : {0}";
        }

        internal static class ValidationMessages
        {
            internal static class UserValidationMessages
            {
                public const string UserEntityCanNotBeNull = "User object can not be null";
                public const string FirstNameCanNotBeBlank = "First name can not be blank";
                public const string LastNameCanNotBeBlank = "Last name can not be blank";
                public const string AgeIsNotValid = "Age is not Valid";
            }
           
        }
    }
}
