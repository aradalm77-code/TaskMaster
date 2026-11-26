using System.Linq;
using TaskMaster.Application.BaseInfo.Persons;
using TaskMaster.Domain.Entities;

namespace TaskMaster.Application.BaseInfo.Users
{
    public interface ISearchUsers
    {
        IQueryable<User> Respond(out int totalPages, Request request = null);

        public class Request
        {
            public string Username { get; set; }
            public string SearchItem { get; set; }
            public int Id { get; set; }
            public int PgeSize { get; set; }
            public int? PageNumber { get; set; }
        }
    }
}
