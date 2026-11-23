using TaskMaster.Domain.Enums;
using TaskMaster.Domain.Interfaces;

namespace TaskMaster.Domain.Entities
{
    public class Person : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public PersonGender.Gender Gender { get; set; }

        public Person(string firstName, string lastName, int age, PersonGender.Gender gender)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Gender = gender;
        }
        public Person()
        {
        }
    }
}
