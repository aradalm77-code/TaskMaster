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
        }

        public void EditUser(User user, string Username)
        {
            User _user = GetUsers(Username, true)[0];
            if (_user is null) throw new Exception("User Does not exist");
            _user = user;
        }

        public void RemoveUser(User user)
        {
            _context.Remove<User>(user);
        }

        public void RemoveUserById(int id)
        {
            _context.DeleteById<User>(id);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public List<User> GetUsers(string searchTerm, bool GetByUsername = false)
        {
            List<User> users = _context.Query<User>().Include(u => u.Person).ToList<User>();
            if (string.IsNullOrWhiteSpace(searchTerm)) return users;
            if (GetByUsername)
            {
                return users.Where(e =>
                    e.Username.Equals(searchTerm)
                ).ToList();
            }
            List<User> _users = users.Where(
                e => e.Username.Equals(searchTerm, StringComparison.OrdinalIgnoreCase)
                || e.Person.FirstName.Equals(searchTerm, StringComparison.OrdinalIgnoreCase)
                || e.Person.LastName.Equals(searchTerm, StringComparison.OrdinalIgnoreCase)
                ).ToList();
            return _users.Distinct().ToList();
        }
    }
}