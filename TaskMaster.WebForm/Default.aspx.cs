using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskMasterEntity.src.Core.Application.Interfaces;
using System.Web.Services;
using TaskMasterEntity.src.Core.Application.BaseInfo.Users.Dtos;
using TaskMasterEntity.src.Core.Application.Features.Users.Services.UserService;

namespace TaskMasterEntity.src.WebForms
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private static ICreateUser createUser;
        [WebMethod]
        public static UserDto Register(string firstName, string lastName, string username, string password, string gender, int age, string role)
        {
            IUserDataAccess userDataAccess = new UserDataAccess();
            createUser = new CreateUser(userDataAccess);
            UserDto userDto = createUser.UserRegister(firstName, lastName, username, password, age, gender, role);
            return userDto;

        }
    }
}