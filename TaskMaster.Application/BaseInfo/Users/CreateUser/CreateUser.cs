using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMasterEntity.src.Core.Application.BaseInfo.Users.Dtos;
using TaskMasterEntity.src.Core.Application.Interfaces;
using TaskMasterEntity.src.Core.Domain.Entities;
using TaskMasterEntity.src.Core.Domain.Enums;


namespace TaskMasterEntity.src.Core.Application.Features.Users.Services.UserService
{
    public class CreateUser : ICreateUser
    {
        private IUserDataAccess _userDataAccess;
        public CreateUser(IUserDataAccess userDataAccess)
        {
            _userDataAccess = userDataAccess;
        }
        public UserDto UserRegister(string firstName, string lastName, string username, string password, int age, string gender, string role)
        {
            PersonGender.Gender _gender = PersonGender.Gender.male;
            UserLevel.Level level = UserLevel.Level.Beginner;
            UserRole.Role _role = UserRole.Role.Intern;
            switch (gender)
            {
                case "male":
                    _gender = PersonGender.Gender.male;
                    break;
                case "female":
                    _gender = PersonGender.Gender.female;
                    break;
            }
            switch (role)
            {
                case "Designer":
                    _role = UserRole.Role.Designer;
                    break;
                case "Intern":
                    _role = UserRole.Role.Intern;
                    break;
            }
            User user = new User(firstName, lastName, username, password, _role, level, age, _gender);
            if (UserExists(user.Username)) throw new Exception("User with this username alreade exist");
            _userDataAccess.AddUser(user);
            return new UserDto
            {
                Id = user.Id,
                FirstName = user.Person.FirstName,
                LastName = user.Person.LastName,
                Username = user.Username,
                Role = user.Role,
                Level = user.Level,
                Score = user.Score
            };
        }
        public bool UserExists(string username)
        {
            User user = _userDataAccess.GetUsers(username, true)[0];
            if (user != null) return true;
            return false;
        }
    }
}
