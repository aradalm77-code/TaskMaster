using System.Linq;
using TaskMaster.Application.BaseInfo.Persons;
using TaskMaster.Application.Interfaces;
using TaskMaster.Domain.Entities;

namespace TaskMaster.Persistence.DataAccess
{
    public class PersonDataAccess(IDb db, ISearchPersons searchPersons) : IPersonDataAccess
    {
        public void RemoveById(int id)
        {
            db.DeleteById<Person>(id);
        }

        public void Update(Person person)
        {
            db.Update<Person>(person);
        }
        public Person GetById(int id)
        {
            return searchPersons.Respond(new ISearchPersons.Request { Id = id }).SingleOrDefault();
        }
    }
}
