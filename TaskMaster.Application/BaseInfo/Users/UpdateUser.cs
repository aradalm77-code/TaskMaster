using System;
using System.Linq;
using TaskMaster.Application.BaseInfo.Persons;
using TaskMaster.Application.Interfaces;
using TaskMaster.Domain.Entities;

namespace TaskMaster.Application.BaseInfo.Users
{
    public class UpdateUser(IDb db, IUserDataAccess userDataAccess, IPersonDataAccess personDataAccess, ISearchUsers searchUsers) : IUpdateUser
    {
        void IUpdateUser.EditUser(IUpdateUser.Request request)
        {
            var item = searchUsers.Respond(new ISearchUsers.Request { Id = request.Id }).SingleOrDefault();
            if (item == null)
            {
                throw new Exception("User not found.");
            }

            // ---------- checking if password is updated ----------

            if (string.IsNullOrEmpty(request.User.Password))
            {
                request.User.Password = item.Password;
            }

            userDataAccess.Edit(new IUserDataAccess.Request
            {
                User = request.User,
                Id = request.Id
            });

            personDataAccess.Update(new IPersonDataAccess.Request
            {
                Id = request.Id,
                person = request.User.Person
            });

            db.SaveChanges();
        }
    }
}
