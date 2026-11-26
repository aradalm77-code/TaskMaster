using TaskMaster.Domain.Enums;
using TaskMaster.Domain.Interfaces;

namespace TaskMaster.Domain.Entities
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
        public User(Person person, string username, string password, UserRole.Role role)
        {
            Person = person;
            Username = username;
            Password = password;
            Score = 0;
            Id = 0;
            Role = role;
            Level = UserLevel.Level.Beginner;
            Person.Id = 0;
        }
    }
}