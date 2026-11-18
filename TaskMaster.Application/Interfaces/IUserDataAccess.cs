using System.Collections.Generic;
using System.Linq;
using TaskMasterEntity.src.Core.Domain.Entities;

namespace TaskMasterEntity.src.Core.Application.Interfaces
{
    public interface IUserDataAccess
    {
        void AddUser(Request request);
        void RemoveUser(Request request);
        void RemoveUserById(Request request);
        void EditUser(Request request);
        IQueryable<IUserDataAccess.ResponseDTO> GetAllUsers();
        IUserDataAccess.ResponseDTO GetUserByUsername(Request request);
        public class Request
        {
            public string SearchItem { get; set; }
            public string Username { get; set; }
            public IUserDataAccess.ResponseDTO item { get; set; }
            public int Id { get; set; }
        }
        public class ResponseDTO
        {
            public User User { get; set; }
            public Person Person { get; set; }
        }
    }
}
