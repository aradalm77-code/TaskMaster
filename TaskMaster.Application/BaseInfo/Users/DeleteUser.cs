using TaskMaster.Application.BaseInfo.Persons;
using TaskMaster.Application.Interfaces;

namespace TaskMaster.Application.BaseInfo.Users
{
    public class DeleteUser(IUserDataAccess userDataAccess, IDb db, IPersonDataAccess personDataAccess) : IDeleteUser
    {

        public void Delete(IDeleteUser.Request request)
        {

            userDataAccess.RemoveById(new IUserDataAccess.Request
            {
                Id = request.UserId
            });
            personDataAccess.RemoveById(new IPersonDataAccess.Request
            {
                Id = request.PersonId
            });

            db.SaveChanges();
        }
    }
}
