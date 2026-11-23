using System.Linq;
using TaskMaster.Domain.Entities;

namespace TaskMaster.Application.BaseInfo.Users
{
    public interface IUserDataAccess
    {
        void Add(Request request);
        void Remove(Request request);
        void RemoveById(Request request);
        void Edit(Request request);
        IQueryable<User> GetAllUsers();
        User GetById(Request request);
        User GetByUsername(Request request);
        public class Request
        {
            public int Id { get; set; }
            public User User { get; set; }
            public string SearchItem { get; set; }
            public string Username { get; set; }
            public IUserDataAccess.ResponseDTO item { get; set; }
        }
        public class ResponseDTO
        {
            public User User { get; set; }
            public Person Person { get; set; }
        }
    }
}
