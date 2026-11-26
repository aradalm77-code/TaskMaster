namespace TaskMaster.Application.BaseInfo.Users
{
    public interface ILoginUser
    {
        string Login(Request request);
        public class Request
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}
