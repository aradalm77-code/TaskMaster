using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMasterEntity.src.Core.Application.Interfaces;
using TaskMasterEntity.src.Core.Domain.Entities;

namespace TaskMasterEntity.src.Core.Infrastructure.Pesrcsstance.DataAccess
{
    public class SearchPersons(IDb db) : ISearchPersons
    {
        public IQueryable<Person> SearchPeople(ISearchPersons.Request request = null)
        {
            var people = db.Query<Person>();
            if(request is null)
            {
                return people;
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(request.SearchItem))
                {
                    people = people.Where(p => p.FirstName.Contains(request.SearchItem) || p.LastName.Contains(request.SearchItem));
                }
                if (request.Id != 0)
                {
                    people = people.Where(p => p.Id == request.Id);
                }
                return people;
            }
        }
    }
}
