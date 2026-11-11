using TaskMasterEntity.src.Core.Domain.Enums;
using TaskMasterEntity.src.Core.Domain.Interfaces;

namespace TaskMasterEntity.src.Core.Domain.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public Person Person { get; set; }
        public int PersonId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Score { get; set; }
        public UserRole.Role Role { get; set; }
        public UserLevel.Level Level { get; set; }
        public User()
        {
        }
        public User(string firstName, string lastName, string username, string password, int score, int id,int personId, UserRole.Role role, UserLevel.Level level, int age, PersonGender.Gender gender)
        {
            Person = new Person(firstName, lastName, age, gender);
            Username = username;
            Password = password;
            Score = score;
            Id = id;
            Role = role;
            Level = level;
            Person.Id = PersonId;
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
            Person.Id = 0;
        }
    }
}