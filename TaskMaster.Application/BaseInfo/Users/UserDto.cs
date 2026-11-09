using System.Security.Permissions;
using TaskMasterEntity.src.Core.Domain.Entities;
using TaskMasterEntity.src.Core.Domain.Enums;

namespace TaskMasterEntity.src.Core.Application.BaseInfo.Users.Dtos
{
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
