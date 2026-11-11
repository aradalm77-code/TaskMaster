using TaskMasterEntity.src.Core.Domain.Enums;
using TaskMasterEntity.src.Core.Domain.Interfaces;

namespace TaskMasterEntity.src.Core.Domain.Entities
{
    public class Person : IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public PersonGender.Gender Gender { get; set; }
        public int Id { get; set; }

        public Person(string firstName, string lastNAme, int age, PersonGender.Gender gender)
        {
            FirstName = firstName;
            LastName = lastNAme;
            Age = age;
            Gender = gender;
        }
        public Person()
        {
        }
    }
}
