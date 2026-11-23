using System;

namespace TaskMaster.Domain.Exceptions
{
    public class UserAlreadyExistException : Exception
    {
        public UserAlreadyExistException(string username) : base($"User with username '{username}' already exists.")
        {
        }
    }
}
