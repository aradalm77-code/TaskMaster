using System.Linq;
using TaskMaster.Domain.Enums;

namespace TaskMaster.Application.BaseInfo.Users
{
    public interface IGetUsers
    {
        IQueryable<TaskMaster.Domain.Entities.User> GetUserList();
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
