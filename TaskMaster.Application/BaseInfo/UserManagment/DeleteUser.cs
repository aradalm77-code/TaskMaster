using TaskMasterEntity.src.Core.Application.Interfaces;

namespace TaskMasterEntity.src.Core.Application.Features.Users.Services.UserService
{
    public class DeleteUser(IUserDataAccess userDataAccess, IDb db) : IDeleteUser
    {
        
        public void Delete(IDeleteUser.Request request)
        {

            userDataAccess.RemoveUserById(new IUserDataAccess.Request
            {
                Id = request.Id
            });

            db.SaveChanges();
        }
    }
}
