using ServiceFramework.Exception;
using ServiceFramework.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using UserManagement.Common;

namespace ServiceRepository
{
    [BaseServiceBehavior]
    public class UserManagementService : IUserService
    {
        UserManagement.Business.User.UserAggregate userBusiness;
        public UserManagementService()
        {
            userBusiness = new UserManagement.Business.User.UserAggregate();
        }


        public ServiceResult<UserDTO> AddUser(string firstName, string lastName, int age)
        {
            try
            {
                return new ServiceResult<UserDTO>()
                {
                    Result = userBusiness.AddUser(firstName, lastName, age),
                    ResultStatus = ServiceResultStatus.Successfull
                };
            }
            catch(ValidationException ex)
            {
                return new ServiceResult<UserDTO>()
                {
                    ResultStatus = ServiceResultStatus.ValidationFailed,
                    ResultMessage = ex.ValidationMessages
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult<UserDTO>()
                {
                    ResultStatus = ServiceResultStatus.Failed,
                    ResultMessage = ex.Message
                };
            }
        }

        public ServiceResult<List<UserDTO>> GetUsers()
        {
            try
            {
                List<UserDTO> users = userBusiness.GetAll();
                return new ServiceResult<List<UserDTO>>()
                {
                    Result = users,
                    ResultStatus = ServiceResultStatus.Successfull
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult<List<UserDTO>>()
                {
                    ResultStatus = ServiceResultStatus.Failed,
                    ResultMessage = ex.Message
                };
            }

        }

        public ServiceResult<UserDTO> GetUser(int Id)
        {
            try
            {
                UserDTO user = userBusiness.GetUser(Id);
                return new ServiceResult<UserDTO>()
                {
                    Result = user,
                    ResultStatus = ServiceResultStatus.Successfull
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult<UserDTO>()
                {
                    ResultStatus = ServiceResultStatus.Failed,
                    ResultMessage = ex.Message
                };
            }
        }

        public ServiceResult<bool> DeleteUser(int Id)
        {
            try
            {
                bool deleteResult = userBusiness.Delete(Id);
                return new ServiceResult<bool>()
                {
                    Result = deleteResult,
                    ResultStatus = ServiceResultStatus.Successfull
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult<bool>()
                {
                    ResultStatus = ServiceResultStatus.Failed,
                    ResultMessage = ex.Message
                };
            }
        }
    }
}
