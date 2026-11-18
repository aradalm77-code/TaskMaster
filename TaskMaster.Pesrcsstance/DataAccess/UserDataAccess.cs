using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TaskMasterEntity.src.Core.Application.BaseInfo.UserManagment;
using TaskMasterEntity.src.Core.Application.Interfaces;
using TaskMasterEntity.src.Core.Domain.Entities;

namespace TaskMasterEntity.src.Core.Infrastructure.Pesrcsstance.DataAccess
{
    public class UserDataAccess(ISearchUsers searchUser, IDb _context) : IUserDataAccess
    {
        public void AddUser(IUserDataAccess.Request request)
        {
            _context.Add<User>(request.item.User);
            _context.Add<Person>(request.item.Person);
        }

        public void EditUser(IUserDataAccess.Request request)
        {
            IUserDataAccess.ResponseDTO existingUser =
                GetUserByUsername(new IUserDataAccess.Request
                {
                    Username = request.Username
                });

            if (existingUser == null)
                throw new Exception("User does not exist");

            // Update User properties
            existingUser.User.Username = request.item.User.Username;
            existingUser.User.Password = request.item.User.Password;
            existingUser.User.Score = request.item.User.Score;

            // Update Person properties
            existingUser.Person.FirstName = request.item.Person.FirstName;
            existingUser.Person.LastName = request.item.Person.LastName;
            existingUser.Person.Age = request.item.Person.Age;
            existingUser.Person.Gender = request.item.Person.Gender;

            _context.Update<User>(existingUser.User);
            _context.Update<Person>(existingUser.Person);
        }

        public void RemoveUser(IUserDataAccess.Request request)
        {
            Person person = request.item.User.Person;
            _context.Remove<User>(request.item.User);
            _context.Remove<Person>(person);
        } 

        public void RemoveUserById(IUserDataAccess.Request request)
        {
            if (!searchUser.Search(new ISearchUsers.Request { Id = request.Id }).Any(u => u.User.Id == request.Id ))
                return;
            _context.DeleteById<User>(request.Id);
        }
        public IUserDataAccess.ResponseDTO GetUserByUsername(IUserDataAccess.Request request)
        {
            IUserDataAccess.ResponseDTO result = searchUser.Search(new ISearchUsers.Request { PersonRequest = new ISearchPersons.Request() }).FirstOrDefault();
            return result;
        }

        public IQueryable<IUserDataAccess.ResponseDTO> GetAllUsers()
        {
            return searchUser.Search(new ISearchUsers.Request { PersonRequest = new ISearchPersons.Request() });
        }
    }
}