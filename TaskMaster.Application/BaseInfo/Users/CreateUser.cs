using System;
using System.Text.RegularExpressions;
using TaskMaster.Application.Interfaces;
using TaskMaster.Domain.Entities;
using TaskMaster.Domain.Enums;
using TaskMaster.Domain.Exceptions;
using static TaskMaster.Domain.Enums.PersonGender;
using static TaskMaster.Domain.Enums.UserRole;


namespace TaskMaster.Application.BaseInfo.Users
{
    public class CreateUser(IUserDataAccess userDataAccess, IDb db, IHashPassword hashPassword) : ICreateUser
    {
        public User UserRegister(ICreateUser.Req req)
        {

            // ---------- input validations ----------

            if (string.IsNullOrWhiteSpace(req.UserName))
                throw new AppException("Please enter your Username name");

            if (string.IsNullOrWhiteSpace(req.FirstName))
                throw new AppException("Please enter your Firstname");

            if (string.IsNullOrWhiteSpace(req.LastName))
                throw new AppException("Please enter your Lastname");

            if (
                req.Password.Length < 8 ||
                !Regex.IsMatch(req.Password, @"[A-Z]") ||
                !Regex.IsMatch(req.Password, @"[a-z]") ||
                !Regex.IsMatch(req.Password, @"[^a-zA-Z0-9]"))
                throw new AppException("Password must contain at least 8 characters," +
                " one uppercase letter, one lowercase letter, and one special character.");



            if (Convert.ToInt32(req.Age) > 80 || Convert.ToInt32(req.Age) < 9)
                throw new AppException("Your age must be between 9 and 80");

            if (string.IsNullOrWhiteSpace(req.Gender))
            {
                throw new AppException("Please select your gender.");
            }

            if (string.IsNullOrWhiteSpace(req.Role))
            {
                throw new AppException("Please select your role.");
            }

            var (role, gender) = CastEnums(req.Role, req.Gender);

            if (UserExists(req.UserName))
                throw new AppException("User with this Username already exists");

            string password = hashPassword.Hash(req.Password);

            Person person = new Person(req.FirstName, req.LastName, req.Age, gender);
            User user = new User(person, req.UserName, password, role);

            userDataAccess.Add(user);
            db.SaveChanges();

            return user;
        }

        private bool UserExists(string username)
        {
            var response = userDataAccess.GetByUsername(username);
            if (response != null) return true;
            return false;
        }

        private (Role, Gender) CastEnums(string role, string gender)
        {
            Gender castedGender = Gender.Male;
            Role castedRole = Role.Designer;

            switch (gender)
            {
                case "male":
                    castedGender = Gender.Male;
                    break;
                case "female":
                    castedGender = Gender.Female;
                    break;
            }

            switch (role)
            {
                case "Designer":
                    castedRole = Role.Designer;
                    break;
                case "Intern":
                    castedRole = Role.Intern;
                    break;
            }

            return (castedRole, castedGender);
        }
    }
}
