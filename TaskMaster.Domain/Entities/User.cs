using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using TaskMasterEntity.src.Core.Domain.Enums;
using TaskMasterEntity.src.Core.Domain.Interfaces;

namespace TaskMasterEntity.src.Core.Domain.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }
        [ForeignKey(nameof(PersonId))]
        public int PersonId { get; set; }
        [Index("IX_Username", IsUnique = true)]
        public string Username { get; private set; }
        public Person Person { get; set; }
        public string Password { get; private set; }
        public int Score { get; private set; }
        public UserRole.Role Role { get; private set; }
        public UserLevel.Level Level { get; private set; }
        public User()
        {
        }
        public User(string firstName, string lastName, string username, string password, int score, int id, UserRole.Role role, UserLevel.Level level, int age, PersonGender.Gender gender)
        {
            Person = new Person(firstName, lastName, age, gender);
            Username = username;
            Password = password;
            Score = score;
            Id = id;
            Role = role;
            Level = level;
        }
        public User(string firstName, string lastName, string username, string password, UserRole.Role role, UserLevel.Level level, int age, PersonGender.Gender gender )
        {
            Person = new Person(firstName, lastName, age, gender);
            Username = username;
            Password = password;
            Score = 0; // Default score
            Id = 0; // Default ID
            Role = role;
            Level = level;
        }
    }
}