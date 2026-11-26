using System.Linq;
using TaskMaster.Application.BaseInfo.Persons;
using TaskMaster.Application.Interfaces;
using TaskMaster.Domain.Entities;

namespace TaskMaster.Persistence.DataAccess
{
    public class SearchPersons(IDb db) : ISearchPersons
    {
        public IQueryable<Person> Respond(ISearchPersons.Request request = null)
        {
            var items = db.Query<Person>();

            if (request is null)
                return items;

            if (request.Id != 0)
            {
                items = items.Where(p => p.Id == request.Id);
            }
            if (!string.IsNullOrWhiteSpace(request.SearchItem))
            {
                items = items.Where(p => p.FirstName.Contains(request.SearchItem) || p.LastName.Contains(request.SearchItem));
            }

            return items;
        }

    }
}
