using ServiceFramework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Data.Entity;

namespace UserManagement.Common
{
    internal class UserRepository : IGenericRepository<User>
    {
        private static List<User> _context = new List<User>()
        {
            new User(){ Id = 1, Age = 27, FirstName ="Selim", LastName = "YILDIZ"},
            new User(){ Id = 2, Age = 34, FirstName ="Frank", LastName = "Ribery"},
            new User(){ Id = 3, Age = 33, FirstName ="Arjen", LastName = "Roben"},
            new User(){ Id = 4, Age = 34, FirstName ="Wesley", LastName = "Sneijder"},
        };

        public User Add(User entity)
        {
           _context.Add(entity);
            return entity;
        }

        public void Delete(User entity)
        {
            _context.Remove(entity);
        }

        public void Edit(User entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> FindBy(Expression<Func<User, bool>> predicate)
        {
            return _context.AsQueryable().Where(predicate);
        }

        public IQueryable<User> GetAll()
        {
            return _context.AsQueryable();

        }

    }
}
