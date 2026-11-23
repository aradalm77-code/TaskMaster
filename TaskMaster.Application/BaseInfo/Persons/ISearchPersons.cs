using System.Linq;
using TaskMaster.Domain.Entities;

namespace TaskMaster.Application.BaseInfo.Persons
{
    public interface ISearchPersons
    {
        IQueryable<Person> Respond(Request request = null);

        public class Request
        {
            public int Id { get; set; }
            public string SearchItem { get; set; }
        }
    }
}
