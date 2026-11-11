using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TaskMasterEntity.src.Core.Application.Interfaces;
using TaskMasterEntity.src.Core.Domain.Entities;

namespace TaskMasterEntity.src.Core.Infrastructure.Pesrcsstance.DataAccess
{
    public class UserDataAccess : IUserDataAccess
    {
        private IDb _context;
        public UserDataAccess(IDb context)
        {
            _context = context;
        }
        public void AddUser(User user)
        {
            _context.Add<User>(user);
        }

        public void EditUser(User user, string Username)
        {
            User _user = GetUserByUsername(Username);
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
        public User GetUserByUsername(string username)
        {
            User user = _context.Query<User>().FirstOrDefault(u => u.Username == username);
            return user;
        }

        public List<User> GetUsers(string searchTerm = null)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                List<User> users = _context.Query<User>().Include(u => u.Person).ToList<User>();
                return users;
            }
            else
            {
                List<User> users = _context.Query<User>().Where(
                e => e.Username.Equals(searchTerm, StringComparison.OrdinalIgnoreCase)
                || e.Person.FirstName.Equals(searchTerm, StringComparison.OrdinalIgnoreCase)
                || e.Person.LastName.Equals(searchTerm, StringComparison.OrdinalIgnoreCase)
                ).Distinct().ToList();
                return users;
            }
        }
    }
}