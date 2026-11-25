using TaskMaster.Domain.Entities;

namespace TaskMaster.Application.BaseInfo.Persons
{
    public interface IPersonDataAccess
    {
        void Update(Person person);
        void Delete(int id);
        void Add(Person person);
        void RemoveById(int id);
        Person GetById(int id);
    }
}
