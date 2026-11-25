using System;
using System.Text.RegularExpressions;
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

            // ---------- input validations ----------

            if (string.IsNullOrWhiteSpace(req.UserName))
                throw new Exception("Please enter your Username name");

            if (string.IsNullOrWhiteSpace(req.FirstName))
                throw new Exception("Please enter your Firstname");

            if (string.IsNullOrWhiteSpace(req.LastName))
                throw new Exception("Please enter your Lastname");

            if (
                req.Password.Length < 8 ||
                !Regex.IsMatch(req.Password, @"[A-Z]") ||
                !Regex.IsMatch(req.Password, @"[a-z]") ||
                !Regex.IsMatch(req.Password, @"[^a-zA-Z0-9]"))
                throw new Exception("Password must contain at least 8 characters," +
                " one uppercase letter, one lowercase letter, and one special character.");



            if (Convert.ToInt32(req.Age) > 80 || Convert.ToInt32(req.Age) < 9)
                throw new Exception("Your age must be between 9 and 80");

            if (string.IsNullOrWhiteSpace(req.Gender))
            {
                throw new ArgumentException("Please select your gender.");
            }

            if (string.IsNullOrWhiteSpace(req.Role))
            {
                throw new ArgumentException("Please select your role.");
            }

            var (role, gender) = CastEnums(req.Role, req.Gender);

            if (UserExists(req.UserName))
                throw new Exception("User with this Username already exists");

            Person person = new Person(req.FirstName, req.LastName, req.Age, gender);
            User user = new User(person, req.FirstName, req.LastName, req.UserName, req.Password, role, req.Age, gender);

            userDataAccess.Add(user);
            db.SaveChanges();

            return user;
        }

        private bool UserExists(string username)
        {
            var response = userDataAccess.GetByUsername(username);
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
