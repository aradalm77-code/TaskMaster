using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMasterEntity.src.Core.Application.Interfaces;
using TaskMasterEntity.src.Core.Domain.Entities;

namespace TaskMasterEntity.src.Core.Application.BaseInfo.UserManagment
{
    public class UpdateUser(IDb db, IUserDataAccess userDataAccess) : IUpdateUser
    {
        void IUpdateUser.EditUser(IUpdateUser.Request request)
        {
            User user = userDataAccess.GetUserByUsername(new IUserDataAccess.Request { Username = request.Username });

            if(user == null)
            {
                throw new Exception("User not found.");
            }

            // ---------- cheking if password is updated ----------

            if (string.IsNullOrEmpty(request.User.Password))
            {
                request.User.Password = user.Password;
            }

            userDataAccess.EditUser(new IUserDataAccess.Request
            {
                Username = request.Username,
                User = request.User
            });


            db.SaveChanges();
        }
    }
}
