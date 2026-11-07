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
        string FirstName { get; set; }
        string LastName { get; set; }
        int Age { get; set; }
        PersonGender.Gender Gender { get; set; }
        public Person(string firstName, string lastNAme, int age, PersonGender.Gender gender)
        {
            FirstName = firstName;
            LastName = lastNAme;
            Age = age;
            Gender = gender;
        }
    }
}
