namespace TaskMaster.Application.BaseInfo.Users
{
    public interface IDeleteUser
    {
        void Delete(Request request);
        public class Request
        {
            public int UserId { get; set; }
            public int PersonId { get; set; }
        }
    }
}
