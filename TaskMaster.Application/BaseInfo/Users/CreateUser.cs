using System;
using TaskMaster.Application.Interfaces;
using TaskMaster.Domain.Entities;
using TaskMaster.Domain.Enums;
using static TaskMaster.Domain.Enums.PersonGender;
using static TaskMaster.Domain.Enums.UserRole;


namespace TaskMaster.Application.BaseInfo.Users
{
    public class CreateUser(IUserDataAccess userDataAccess, IDb db) : ICreateUser
    {
        public User UserRegister(ICreateUser.Req req)
        {
            var (role, gender) = CastEnums(req.Role, req.Gender);

            if (UserExists(req.UserName))
                throw new Exception("User with this Username already exists");

            Person person = new Person(req.FirstName, req.LastName, req.Age, gender);
            User user = new User(person, req.FirstName, req.LastName, req.UserName, req.Password, role, req.Age, gender);

            userDataAccess.Add(new IUserDataAccess.Request { item = new IUserDataAccess.ResponseDTO { User = user } });
            db.SaveChanges();

            return user;
        }

        private bool UserExists(string username)
        {
            var response= userDataAccess.GetByUsername(new IUserDataAccess.Request { Username = username });
            if (response != null)
                return true;
            else
                return false;
        }

        private (UserRole.Role, Gender) CastEnums(string role, string gender)
        {
            PersonGender.Gender _gender = Gender.male;
            UserRole.Role _role = Role.Designer;

            switch (gender)
            {
                case "male":
                    _gender = Gender.male;
                    break;
                case "female":
                    _gender = Gender.female;
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

            return (_role, _gender);
        }
    }
}
