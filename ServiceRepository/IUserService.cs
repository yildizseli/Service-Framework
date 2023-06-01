using ServiceFramework.Service;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ServiceRepository
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        ServiceResult<UserManagement.Common.UserDTO> AddUser(string firstName, string lastName, int age);

        [OperationContract]
        ServiceResult<List<UserManagement.Common.UserDTO>> GetUsers();

        [OperationContract]
        ServiceResult<UserManagement.Common.UserDTO> GetUser(int Id);

        [OperationContract]
        ServiceResult<bool> DeleteUser(int Id);
    }
}
