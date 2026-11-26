using TaskMaster.Domain.Entities;
using TaskMaster.Domain.Exceptions;

namespace TaskMaster.Application.BaseInfo.Users
{
    public class LoginUser(IHashPassword hashPassword, IUserDataAccess userDataAccess) : ILoginUser
    {
        public string Login(ILoginUser.Request request)
        {
            string password = hashPassword.Hash(request.Password);

            User user = userDataAccess.GetByUsername(request.Username);

            if (user is null || user.Password != password)
                throw new AppException("Invalid username or password");

            return user.Username;
        }
    }
}
