using System.Linq;
using TaskMaster.Domain.Entities;

namespace TaskMaster.Application.BaseInfo.Users
{
    public interface IUserDataAccess
    {
        void Add(User User);
        void Remove(User User);
        void RemoveById(int id);
        void Edit(User User);
        IQueryable<User> GetAllUsers();
        User GetById(int id);
        User GetByUsername(string username);
        public class Request
        {
            public int Id { get; set; }
            public User User { get; set; }
            public string SearchItem { get; set; }
            public string Username { get; set; }
        }
    }
}
