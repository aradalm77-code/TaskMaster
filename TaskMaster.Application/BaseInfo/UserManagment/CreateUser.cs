using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using TaskMasterEntity.src.Core.Application.Interfaces;
using TaskMasterEntity.src.Core.Domain.Entities;
using TaskMasterEntity.src.Core.Domain.Enums;
using static TaskMasterEntity.src.Core.Domain.Enums.PersonGender;
using static TaskMasterEntity.src.Core.Domain.Enums.UserRole;


namespace TaskMasterEntity.src.Core.Application.Features.Users.Services.UserService
{
    public class CreateUser : ICreateUser
    {
        private IUserDataAccess _userDataAccess;
        private IDb _db;
        public CreateUser(IUserDataAccess userDataAccess, IDb db)
        {
            _userDataAccess = userDataAccess;
            _db = db;
        }
        public User UserRegister(ICreateUser.Req req)
        {
            PersonGender.Gender _gender = PersonGender.Gender.male;
            UserLevel.Level level = UserLevel.Level.Beginner;
            UserRole.Role _role = UserRole.Role.Intern;

            (_role, _gender) = CastEnums(req.Role, req.Gender);

            
            if (UserExists(req.UserName)) 
                throw new Exception("User with this username alreade exist");

            User user = new User(req.FirstName, req.LastName, req.UserName, req.Password, _role, level, req.Age, _gender);

            _userDataAccess.AddUser(user);
            _db.SaveChanges();

            return user;
        }
        public bool UserExists(string username)
        {
            User user = _userDataAccess.GetUserByUsername(username);
            if(user != null) return true;
            return false;
        }
        public (UserRole.Role, PersonGender.Gender) CastEnums(string role, string gender)
        {
            PersonGender.Gender _gender = Gender.male;
            UserRole.Role _role = Role.Designer;

            // ---------- casting gender ----------

            switch (gender)
            {
                case "male":
                    _gender = PersonGender.Gender.male;
                    break;
                case "female":
                    _gender = PersonGender.Gender.female;
                    break;
            }

            // ---------- casting role ----------

            switch (role)
            {
                case "Designer":
                    _role = UserRole.Role.Designer;
                    break;
                case "Intern":
                    _role = UserRole.Role.Intern;
                    break;
            }

            return (_role, _gender);
        }
    }
}
