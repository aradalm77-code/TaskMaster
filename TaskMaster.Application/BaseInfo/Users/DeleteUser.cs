using TaskMaster.Application.BaseInfo.Persons;
using TaskMaster.Application.Interfaces;

namespace TaskMaster.Application.BaseInfo.Users
{
    public class DeleteUser(IUserDataAccess userDataAccess, IDb db, IPersonDataAccess personDataAccess) : IDeleteUser
    {

        public void Delete(IDeleteUser.Request request)
        {
            userDataAccess.RemoveById(request.UserId);
            personDataAccess.RemoveById(request.PersonId);

            db.SaveChanges();
        }
    }
}
