using System.Linq;
using TaskMaster.Application.Interfaces;
using TaskMaster.Domain.Entities;

namespace TaskMaster.Application.BaseInfo.Users
{
    public class GetUsers : IGetUsers
    {
        private readonly IUserDataAccess _userDataAccess;
        public GetUsers(IUserDataAccess userDataAccess)
        {
            _userDataAccess = userDataAccess;
        }
        public IQueryable<User> GetUserList()
        {
            return _userDataAccess.GetAllUsers();

        }
    }
}
