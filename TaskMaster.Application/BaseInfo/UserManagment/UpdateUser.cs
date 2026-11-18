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
            IUserDataAccess.ResponseDTO item = userDataAccess.GetUserByUsername(new IUserDataAccess.Request { Username = request.Username });

            if(item == null)
            {
                throw new Exception("User not found.");
            }

            // ---------- cheking if password is updated ----------

            if (string.IsNullOrEmpty(request.User.Password))
            {
                request.User.Password = item.User.Password;
            }

            userDataAccess.EditUser(new IUserDataAccess.Request
            {
                Username = request.Username,
                item = new IUserDataAccess.ResponseDTO
                {
                    User = request.User,
                    Person = request.Person
                }
            });


            db.SaveChanges();
        }
    }
}
