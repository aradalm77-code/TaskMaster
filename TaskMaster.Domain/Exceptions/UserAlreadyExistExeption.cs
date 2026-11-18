using System;

namespace TaskMasterEntity.src.Core.Domain.Exceptions
{
    public class UserAlreadyExistExeption : Exception
    {
        public UserAlreadyExistExeption(string username) : base($"User with username '{username}' already exists.")
        {
        }
    }
}
