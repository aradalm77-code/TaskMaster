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
    public class PersonDataAccess(IDb db, ISearchPersons searchPersons) : IPersonDataAccess
    {
        public void Add(Person person)
        {
            db.Add<Person>(person);
        }

        public void Delete(int id)
        {
            Person person = GetById(id);
            db.Remove<Person>(person);
        }

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
