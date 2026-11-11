using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMasterEntity.src.Core.Domain.Entities;
using TaskMasterEntity.src.Core.Domain.Enums;

namespace TaskMasterEntity.src.Core.Application.Interfaces
{
    public interface IGetUsers
    {
        List<UserDto> GetUserList(string searchTerm);
        public class UserDto
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Username { get; set; }
            public UserRole.Role Role { get; set; }
            public UserLevel.Level Level { get; set; }
            public int Score { get; set; }
        }
    }
}
