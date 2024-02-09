using Bookstore.Contexts;
using Bookstore.Interfaces;
using Bookstore.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Repositories
{
    public class UserRepository:IRepository<string,User>
    {
        private readonly BookContext _context;
        public UserRepository(BookContext context)
        {
            _context = context;
        }
        public User Add(User entity)
        {
            _context.users.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public User Delete(string Key)
        {
            var user = GetById(Key);
            if (user != null)
            {
                _context.users.Remove(user);
                _context.SaveChanges();
                return user;
            }
            return null;
        }

        public IList<User> GetAll()
        {
            if (_context.users.Count() == 0)
                return null;
            return _context.users.ToList();
        }

        public User GetById(string Key)
        {
            var user = _context.users.SingleOrDefault(u => u.UserName == Key);
            return user;
        }

        public User Update(User entity)
        {
            var user = GetById(entity.UserName);
            if (user != null)
            {
                _context.Entry<User>(user).State = EntityState.Modified;
                _context.SaveChanges();
                return user;
            }
            return null;
        }
    }

}

