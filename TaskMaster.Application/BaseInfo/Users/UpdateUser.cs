using System;
using System.Text.RegularExpressions;
using TaskMaster.Application.BaseInfo.Persons;
using TaskMaster.Application.Interfaces;
using TaskMaster.Domain.Exceptions;

namespace TaskMaster.Application.BaseInfo.Users
{
    public class UpdateUser(
        IDb db,
        IUserDataAccess userDataAccess,
        IPersonDataAccess personDataAccess
        ) : IUpdateUser
    {
        void IUpdateUser.EditUser(IUpdateUser.Request request)
        {
            if (string.IsNullOrWhiteSpace(request.User.Username))
                throw new Exception("Please enter your Username name");

            if (string.IsNullOrWhiteSpace(request.Person.FirstName))
                throw new Exception("Please enter your Firstname");

            if (string.IsNullOrWhiteSpace(request.Person.LastName))
                throw new Exception("Please enter your Lastname");

            if (
                request.User.Password.Length < 8 ||
                !Regex.IsMatch(request.User.Password, @"[A-Z]") ||
                !Regex.IsMatch(request.User.Password, @"[a-z]") ||
                !Regex.IsMatch(request.User.Password, @"[^a-zA-Z0-9]"))
                throw new Exception("Password must contain at least 8 characters," +
                " one uppercase letter, one lowercase letter, and one special character.");

            if (Convert.ToInt32(request.Person.Age) > 80 || Convert.ToInt32(request.Person.Age) < 9)
                throw new Exception("Your age must be between 9 and 80");

            if (string.IsNullOrEmpty(request.User.Role.ToString()))
            {
                throw new ArgumentException("Please select your role.");
            }

            var user = userDataAccess.GetById(request.User.Id);
            var person = personDataAccess.GetById(user.PersonId);

            if (user == null)
            {
                throw new AppException("User not found.");
            }

            // ---------- checking if password is updated ----------

            if (string.IsNullOrEmpty(request.User.Password))
            {
                request.User.Password = user.Password;
            }

            user.Password = request.User.Password;
            user.Username = request.User.Username;
            user.Role = request.User.Role;
            person.FirstName = request.Person.FirstName;
            person.LastName = request.Person.LastName;
            person.Age = request.Person.Age;
            person.Gender = request.Person.Gender;

            userDataAccess.Edit(user);
            personDataAccess.Update(person);

            db.SaveChanges();
        }
    }
}
