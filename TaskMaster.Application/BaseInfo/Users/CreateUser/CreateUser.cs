using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMasterEntity.src.Core.Domain.Entities;
using TaskMasterEntity.src.Core.Application.Interfaces;


namespace TaskMasterEntity.src.Core.Application.Features.Users.Services.UserService
{
    public class CreateUser : ICreateUser
    {
        private IUserDataAccess _userDataAccess;
        public CreateUser(IUserDataAccess userDataAccess)
        {
            _userDataAccess = userDataAccess;
        }
        public void UserRegister(User user)
        {
            if (UserExists(user.Username)) throw new Exception("User with this username alreade exist");
            _userDataAccess.AddUser(user);
        }
        public bool UserExists(string username)
        {
            User user = _userDataAccess.GetUserByUsername(username);
            if (user != null) return true;
            return false;
        }
    }
}
