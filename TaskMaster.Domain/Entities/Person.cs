using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMasterEntity.src.Core.Domain.Enums;

namespace TaskMasterEntity.src.Core.Domain.Entities
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public PersonGender.Gender Gender { get; set; }
        public Person(string firstName, string lastNAme, int age, PersonGender.Gender gender)
        {
            FirstName = firstName;
            LastName = lastNAme;
            Age = age;
            Gender = gender;
        }
    }
}
