namespace TaskMaster.Application.BaseInfo.Users
{
    public interface IHashPassword
    {
        public string Hash(string password);
    }
}
