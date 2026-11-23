using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TaskMaster.Application.BaseInfo.Users;
using TaskMaster.Application.Interfaces;
using TaskMaster.Domain.Entities;
using static TaskMaster.Application.BaseInfo.Users.IUserDataAccess;

namespace TaskMaster.Persistence.DataAccess
{
    public class UserDataAccess(ISearchUsers searchUser, IDb _context) : IUserDataAccess
    {
        public void Add(IUserDataAccess.Request request)
        {
            _context.Add<User>(request.item.User);
        }

        public void Edit(IUserDataAccess.Request request)
        {


            var existingUser = searchUser.Respond(new ISearchUsers.Request { Id = request.Id }).SingleOrDefault(u => u.Id == request.Id);

            if (existingUser == null)
                throw new Exception("User does not exist");

            var updatedUser = UpdateFields(existingUser, request.User);

            _context.Update<User>(updatedUser);
        }

        public void Remove(IUserDataAccess.Request request)
        {
            Person person = request.item.User.Person;
            _context.Remove<Person>(person);
        }

        public void RemoveById(IUserDataAccess.Request request)
        {
            var hasUser = searchUser.Respond(new ISearchUsers.Request { Id = request.Id }).Any();

            if (!hasUser)
                return;

            _context.DeleteById<User>(request.Id);
        }
        public User GetById(IUserDataAccess.Request request)
        {
            return searchUser.Respond(new ISearchUsers.Request { Id = request.Id }).SingleOrDefault();
        }
        public IQueryable<User> GetAllUsers()
        {
            return searchUser.Respond();
        }
        private User UpdateFields(User ExistingUser, User user)
        {
            ExistingUser.Role = user.Role;
            ExistingUser.Password = user.Password;
            ExistingUser.Username = user.Username;

            return ExistingUser;
        }

        public User GetByUsername(Request request)
        {
            return searchUser.Respond(new ISearchUsers.Request { Username = request.Username }).SingleOrDefault();
        }
    }
}