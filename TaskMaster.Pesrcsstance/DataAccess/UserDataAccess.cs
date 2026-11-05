using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TaskMasterEntity.src.Core.Application.Interfaces;
using TaskMasterEntity.src.Core.Domain.Entities;
using TaskMasterEntity.src.Core.Infrastructure.Pesrcsstance;

namespace TaskMasterEntity.src.Core.Infrastructure.Pesrcsstance.DataAccess
{
    public class UserDataAccess : IUserDataAccess
    {
        private IDb _context;
        public UserDataAccess()
        {
            _context = new DataBaseContext();
        }
        public void AddUser(User user)
        {
            _context.Add<User>(user);
            _context.SaveChanges();
        }

        public void EditUser(User user, string Username)
        {
            User _user = GetUserByUsername(Username); 
            if (_user is null) throw new Exception("User Does not exist");
            _user = user;
            _context.SaveChanges();
        }

        public User GetUserByUsername(string Username)
        {
            List<User> users = (List<User>)_context.Set<User>();
            User _user = users.FirstOrDefault(e => e.Username == Username);
            return _user;
        }

        public List<User> GetUsers()
        {
            List<User> users = (List<User>)_context.Query<User>();
            return users;
        }

        public void RemoveUser(User user)
        {
            _context.Remove<User>(user);
            _context.SaveChanges();
        }

        public List<User> SearchUser(string searchTerm)
        {
            List<User> users = (List<User>)_context.Query<User>();
            List<User> _users = users.Where(
                e => e.Username.Equals(searchTerm, StringComparison.CurrentCultureIgnoreCase)
                || e.FirstName.Equals(searchTerm, StringComparison.CurrentCultureIgnoreCase)
                || e.LastName.Equals(searchTerm, StringComparison.CurrentCultureIgnoreCase)
                ).ToList();
            return _users.Distinct().ToList();
        }
    }
}