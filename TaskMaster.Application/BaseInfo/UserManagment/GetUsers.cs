using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public List<IGetUsers.UserDto> GetUserList(string searchTerm)
        {
            return _userDataAccess.GetUsers(searchTerm).Select(i => new IGetUsers.UserDto
            {
                Id = i.Id,
                FirstName = i.Person.FirstName,
                LastName = i.Person.LastName,
                Username = i.Username,
                Role = i.Role,
                Level = i.Level,
                Score = i.Score
            }).ToList();


        }
    }
}
