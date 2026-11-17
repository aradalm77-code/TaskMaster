using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMasterEntity.src.Core.Domain.Entities;

namespace TaskMasterEntity.src.Core.Application.Interfaces
{
    public interface ISearchPersons
    {
        public class Request
        {
            public string SearchItem { get; set; }
            public int Id { get; set; }
        }
        IQueryable<Person> SearchPeople(Request request = null);
    }
}
