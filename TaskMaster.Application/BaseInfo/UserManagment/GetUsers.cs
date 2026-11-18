using System.Collections.Generic;
using System.Linq;
using TaskMasterEntity.src.Core.Application.Interfaces;
using TaskMasterEntity.src.Core.Domain.Entities;

namespace TaskMasterEntity.src.Core.Application.Features.Users.Services.UserService
{
    public class GetUsers : IGetUsers
    {
        private readonly IUserDataAccess _userDataAccess;
        public GetUsers(IUserDataAccess userDataAccess)
        {
            _userDataAccess = userDataAccess;
        }
        public IQueryable<IUserDataAccess.ResponseDTO> GetUserList()
        {
            return _userDataAccess.GetAllUsers();

        }
    }
}
