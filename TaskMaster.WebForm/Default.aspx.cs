using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskMasterEntity.src.Core.Application.Interfaces;
using System.Web.Services;
using TaskMasterEntity.src.Core.Domain.Enums;
using TaskMasterEntity.src.Core.Domain.Entities;
using TaskMasterEntity.src.Core.Application.BaseInfo.Users.Dtos;
using TaskMasterEntity.src.Core.Application.Features.Users.Services.UserService;
using TaskMasterEntity.src.Core.Infrastructure.Pesrcsstance.DataAccess;

namespace TaskMasterEntity.src.WebForms
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private static readonly IDb _db = new 
        private static ICreateUser createUser;
        [WebMethod]
        public static UserDto Register(string FirstName, string LastName, string Username, string password ,UserRole.Role role)
        {
            IUserDataAccess userDataAccess = new UserDataAccess();
            createUser = new CreateUser(userDataAccess);

            User user = new User(FirstName, LastName, Username, password ,role, UserLevel.Level.Beginner);
            createUser.UserRegister(user);

            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Role = user.Role,
                Level = user.Level,
                Score = user.Score
            };
        }
    }
}