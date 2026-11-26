using System.Linq;
using TaskMaster.Application.BaseInfo.Users;
using TaskMaster.Application.Interfaces;
using TaskMaster.Domain.Entities;

namespace TaskMaster.Persistence.DataAccess
{
    public class UserDataAccess(ISearchUsers searchUser, IDb _context) : IUserDataAccess
    {
        public void Add(User user)
        {
            _context.Add<User>(user);
        }

        public void Edit(User user)
        {
            _context.Update<User>(user);
        }

        public void Remove(User user)
        {
            _context.Remove<User>(user);
        }

        public void RemoveById(int id)
        {
            //var hasUser = searchUser.Respond(new ISearchUsers.Request { Id = id }).Any();

            //if (!hasUser)throw new AppException("user does not Exist");

            var user = GetById(id);


            Remove(user);
        }
        public User GetById(int id)
        {
            return searchUser.Respond(out int _, new ISearchUsers.Request { Id = id }).SingleOrDefault();
        }
        public IQueryable<User> GetAllUsers()
        {
            return searchUser.Respond(out int _);
        }

        public User GetByUsername(string username)
        {
            return searchUser.Respond(out int _, new ISearchUsers.Request { Username = username }).SingleOrDefault();
        }
    }
}