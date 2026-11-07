using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMasterEntity.src.Core.Application.Interfaces;

namespace TaskMasterEntity.src.Core.Application.Features.Users.Services.UserService
{
    public class DeleteUser : IDeleteUser
    {
        private readonly IUserDataAccess _userDataAccess;
        public DeleteUser(IUserDataAccess userDataAccess)
        {
            _userDataAccess = userDataAccess;
        }
        public void Delete(int id)
        {
            _userDataAccess.RemoveUserById(id);
        }
    }
}
