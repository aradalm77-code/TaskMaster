using TaskMaster.Domain.Entities;

namespace TaskMaster.Application.BaseInfo.Users
{
    public interface IUpdateUser
    {
        void EditUser(Request request);
        public class Request
        {
            public Person Person { get; set; }
            public User User { get; set; }
        }
    }
}
