using System.Linq;
using TaskMaster.Application.BaseInfo.Persons;
using TaskMaster.Domain.Entities;

namespace TaskMaster.Application.BaseInfo.Users
{
    public interface ISearchUsers
    {
        IQueryable<User> Respond(Request request = null);

        public class Request
        {
            public string Username { get; set; }
            public string SearchItem { get; set; }
            public int Id { get; set; }
            public ISearchPersons.Request PersonRequest { get; set; }
        }
    }
}
