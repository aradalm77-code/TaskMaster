namespace TaskMasterEntity.src.Core.Application.Interfaces
{
    public interface IDeleteUser
    {
        void Delete(Request request);
        public class Request
        {
            public int Id { get; set; }
        }
    }
}
