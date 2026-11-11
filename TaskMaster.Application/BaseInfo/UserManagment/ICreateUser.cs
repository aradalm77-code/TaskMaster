using TaskMasterEntity.src.Core.Domain.Entities;

namespace TaskMasterEntity.src.Core.Application.Interfaces
{
    public interface ICreateUser
    {
        User UserRegister(Req req);
        class Req
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public int Age { get; set; }
            public string Gender { get; set; }
            public string Role { get; set; }
        }

    }
}
