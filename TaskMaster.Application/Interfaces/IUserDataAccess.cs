using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMasterEntity.src.Core.Domain.Entities;

namespace TaskMasterEntity.src.Core.Application.Interfaces
{
    public interface IUserDataAccess
    {
        void AddUser(User user);
        void RemoveUser(User user);
        void RemoveUserById(int id);
        void EditUser(User user, string Username);
        List<User> GetUsers(string searchTerm);
        User GetUserByUsername(string username);
    }
}
