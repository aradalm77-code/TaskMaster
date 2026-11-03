using TaskMasterEntity.src.Core.Domain.Enums;

namespace TaskMasterEntity.src.Core.Application.Features.Users.Dtos
{
    public class RegisteredUserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public UserEnums.UserRole Role { get; set; }
        public UserEnums.UserLevel Level { get; set; }
        public int Score { get; set; }
    }
}
