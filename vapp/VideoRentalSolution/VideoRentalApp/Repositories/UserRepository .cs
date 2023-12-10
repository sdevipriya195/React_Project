using VideoRentalApp.Interfaces;
using VideoRentalApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using VideoRentalApp.Contexts;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace VideoRentalApp.Repositories
{
    /// <summary>
    /// CRUD operations related to user
    /// </summary>
    public class UserRepository : IRepository<string, User>
    {
        private readonly MovieContext _context;

        public UserRepository(MovieContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Adding user details
        /// </summary>
        /// <param name="entity">we take user details </param>
        /// <returns>return those details</returns>
        public User Add(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
            return entity;
        }
        /// <summary>
        /// Deleting the user details
        /// </summary>
        /// <param name="key">we take the userid</param>
        /// <returns>remove it from the data</returns>
        public User Delete(string key)
        {
            var user = GetById(key);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                return user;
            }
            return null;
        }
        /// <summary>
        /// List of users existed
        /// </summary>
        /// <returns>returns the current list of users</returns>

        public IList<User> GetAll()
        {
            if (_context.Users.Count() == 0)
                return null;
            return _context.Users.ToList();
        }
        /// <summary>
        /// We can get the user details by id
        /// </summary>
        /// <param name="key">Take the user id</param>
        /// <returns>returns the user details</returns>

        public User GetById(string key)
        {
            var user = _context.Users.SingleOrDefault(u => u.Username == key);
            return user;
        }
       
        /// <summary>
        /// We can update the user details
        /// </summary>
        /// <param name="entity">We get the user id</param>
        /// <returns>returns the update of user</returns>

        public User Update(User entity)
        {
            var user = GetById(entity.Username);
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