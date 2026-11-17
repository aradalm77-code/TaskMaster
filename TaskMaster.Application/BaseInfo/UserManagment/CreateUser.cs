using System;
using TaskMasterEntity.src.Core.Application.Interfaces;
using TaskMasterEntity.src.Core.Domain.Entities;
using TaskMasterEntity.src.Core.Domain.Enums;
using static TaskMasterEntity.src.Core.Domain.Enums.PersonGender;
using static TaskMasterEntity.src.Core.Domain.Enums.UserRole;


namespace TaskMasterEntity.src.Core.Application.Features.Users.Services.UserService
{
    public class CreateUser(IUserDataAccess userDataAccess, IDb db) : ICreateUser
    {
        public User UserRegister(ICreateUser.Req req)
        {

            var (role, gender) = CastEnums(req.Role, req.Gender);


            if (UserExists(req.UserName))
                throw new Exception("User with this username alreade exist");
            Person person = new Person(req.FirstName, req.LastName, req.Age, gender);

            User user = new User(person, req.FirstName, req.LastName, req.UserName, req.Password, role, req.Age, gender);

            userDataAccess.AddUser(new IUserDataAccess.Request { User = user });
            db.SaveChanges();

            return user;
        }
        // ---------- checking if username is taken ----------
        public bool UserExists(string username) =>
            userDataAccess.GetUserByUsername(
                new IUserDataAccess.Request { Username = username }
            ) != null;
        // ---------- casting Role and Gender ----------
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
