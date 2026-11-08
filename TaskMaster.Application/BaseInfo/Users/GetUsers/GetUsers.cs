using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMasterEntity.src.Core.Application.BaseInfo.Users.Dtos;
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
        public List<UserDto> GetUserList(string searchTerm)
        {
            List<UserDto> users = new List<UserDto>();
            List<User> _users = _userDataAccess.GetUsers(searchTerm);
            foreach (User _user in _users) 
            { 
                UserDto user = new UserDto
                {
                    Id = _user.Id,
                    FirstName = _user.Person.FirstName,
                    LastName = _user.Person.LastName,
                    Username = _user.Username,
                    Role = _user.Role,
                    Level = _user.Level,
                    Score = _user.Score
                };
                users.Add(user);
            }

            return users;
        }
    }
}
