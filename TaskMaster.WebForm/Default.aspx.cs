using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskMasterEntity.src.Core.Application.Interfaces;
using TaskMasterEntity.src.Core.Infrastructure.Pesrcsstance.Services;
using System.Web.Services;
using TaskMasterEntity.src.Core.Domain.Enums;
using TaskMasterEntity.src.Core.Domain.Entities;
using TaskMasterEntity.src.Core.Application.Features.Users.Dtos;
using TaskMasterEntity.src.Core.Application.Features.Users.Services.UserService;

namespace TaskMasterEntity.src.WebForms
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private static readonly ICreateUser createUser;
        [WebMethod]
        public static RegisteredUserDto Register(string FirstName, string LastName, string Username, string password ,UserEnums.UserRole role)
        {
            User user = new User(FirstName, LastName, Username, password ,role, UserEnums.UserLevel.Beginner);
            createUser.UserRegister(user);

            return new RegisteredUserDto
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