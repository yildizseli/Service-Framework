using ServiceFramework.Exception;
using ServiceFramework.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Common;

namespace UserManagement.Business.User
{
    public class UserAggregate
    {
        private UserRepository userRepository;
        private IValidator<Data.Entity.User> userValidation;

        public UserAggregate()
        {
            userRepository = new UserRepository();
            userValidation = new Validation.UserValidator();

            AutoMapper.Mapper.Reset();
            AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<Data.Entity.User, UserDTO>());
        }

        public UserDTO AddUser(string firstName, string lastName, int age)
        {

            Data.Entity.User user = new Data.Entity.User()
            {
                FirstName = firstName,
                Age = age,
                Id = new Random().Next(1, 100),
                LastName = lastName
            };

            var validationResult = userValidation.Validate(user);
            if (validationResult.Count() > 0)
                throw new ValidationException(validationResult);

            Data.Entity.User savedUser = userRepository.Add(user);
            return AutoMapper.Mapper.Map<UserDTO>(savedUser);

        }

        public List<UserDTO> GetAll()
        {
            List<Data.Entity.User> users = userRepository.GetAll().ToList();
            return AutoMapper.Mapper.Map<List<UserDTO>>(users);
        }

        public UserDTO GetUser(int Id)
        {
            Data.Entity.User user = userRepository.FindBy(i => i.Id == Id).FirstOrDefault();
            return AutoMapper.Mapper.Map<UserDTO>(user);
        }

        public bool Delete(int Id)
        {
            Data.Entity.User user = userRepository.FindBy(i => i.Id == Id).FirstOrDefault();
            if (user == null)
            {
                throw new Exception(String.Format(CommonMessages.ErrorMessages.NoFoundUserIdFormat, Id));
            }
            return true;
        }


    }
}
