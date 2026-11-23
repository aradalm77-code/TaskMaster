using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMaster.Application.BaseInfo.Persons;
using TaskMaster.Application.Interfaces;
using TaskMaster.Domain.Entities;

namespace TaskMaster.Persistence.DataAccess
{
    internal class PersonDataAccess(IDb db, ISearchPersons searchPersons) : IPersonDataAccess
    {
        public void Add(IPersonDataAccess.Request request)
        {
            db.Add<Person>(request.person);
        }

        public void Delete(IPersonDataAccess.Request request)
        {
            db.Remove<Person>(request.person);
        }

        public void RemoveById(IPersonDataAccess.Request request)
        {
            db.DeleteById<Person>(request.Id);
        }

        public void Update(IPersonDataAccess.Request request)
        {
            var person = searchPersons.Respond(new ISearchPersons.Request { Id = request.Id });

            var UpdatedPerson = ChangeValue((Person)person, request.person);

            db.Update<Person>(UpdatedPerson);
        }
        private Person ChangeValue(Person ExistingPerson, Person person)
        {
            ExistingPerson.FirstName = person.FirstName;
            ExistingPerson.LastName = person.LastName;
            ExistingPerson.Age = person.Age;
            ExistingPerson.Gender = person.Gender;

            return ExistingPerson;
        }
    }
}
