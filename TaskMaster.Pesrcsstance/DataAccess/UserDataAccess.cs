using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TaskMasterEntity.src.Core.Application.BaseInfo.UserManagment;
using TaskMasterEntity.src.Core.Application.Interfaces;
using TaskMasterEntity.src.Core.Domain.Entities;

namespace TaskMasterEntity.src.Core.Infrastructure.Pesrcsstance.DataAccess
{
    public class UserDataAccess(ISearchUsers searchUser, IDb _context, ISearchPersons searchPersons) : IUserDataAccess
    {
        public void AddUser(IUserDataAccess.Request request)
        {
            _context.Add<User>(request.User);
        }

        public void EditUser(IUserDataAccess.Request request)
        {
            User existingUser = GetUserByUsername(new IUserDataAccess.Request { Username = request.Username });

            if (existingUser == null)
                throw new Exception("User does not exist");

            existingUser = request.User;
            Person person = existingUser.Person;
            _context.Update<User>(existingUser);
            _context.Update<Person>(person);
        }

        public void RemoveUser(IUserDataAccess.Request request)
        {
            Person person = request.User.Person;
            _context.Remove<User>(request.User);
            _context.Remove<Person>(person);
        } 

        public void RemoveUserById(IUserDataAccess.Request request)
        {
            if (!searchUser.Search(new ISearchUsers.Request { Id = request.Id }).Any(u => u.Id == request.Id ))
                return;
            _context.DeleteById<User>(request.Id);
        }
        public User GetUserByUsername(IUserDataAccess.Request request)
        {
            User user = searchUser.Search().FirstOrDefault(u => u.Username == request.Username);
            user.Person = searchPersons.SearchPeople(new ISearchPersons.Request { Id = user.PersonId }).FirstOrDefault();
            return user;
        }

        public IQueryable<User> GetAllUsers()
        {
            return searchUser.Search();
        }
    }
}