using System;
using System.Collections.Generic;
using System.Linq;
using TaskMasterEntity.src.Core.Domain.Enums;
using TaskMasterEntity.src.Core.Domain.Interfaces;
namespace TaskMasterEntity.src.Core.Domain.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public int Score { get; private set; }
        public UserEnums.UserRole Role { get; private set; }
        public UserEnums.UserLevel Level { get; private set; }
        public User()
        {
        }
        public User(string firstName, string lastName, string username, string password, int score, int id, UserEnums.UserRole role, UserEnums.UserLevel level)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Password = password;
            Score = score;
            Id = id;
            Role = role;
            Level = level;
        }
        public User(string firstName, string lastName, string username, string password, UserEnums.UserRole role, UserEnums.UserLevel level)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Password = password;
            Score = 0; // Default score
            Id = 0; // Default ID
            Role = role;
            Level = level;
        }
    }
}