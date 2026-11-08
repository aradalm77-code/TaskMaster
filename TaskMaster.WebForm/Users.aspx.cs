using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using TaskMasterEntity.src.Core.Application.Interfaces;
using TaskMasterEntity.src.Core.Application.Features.Users.Services.UserService;
using TaskMasterEntity.src.Core.Application.BaseInfo.Users.Dtos;
namespace TaskMasterEntity.src.WebForms
{
    public partial class Users : System.Web.UI.Page
    {
        private static readonly IUserDataAccess userDataAccess = new UserDataAccess();
        private static readonly IDeleteUser deleteUser = new DeleteUser(userDataAccess);
        private static readonly IGetUsers getUsers = new GetUsers(userDataAccess);
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static List<UserDto> LoadUser()
        {
            List<UserDto> users = getUsers.GetUserList("");
            return users;
        }
        [WebMethod]
        public static void DeleteUser(int id)
        {
            deleteUser.Delete(id);
        }
        [WebMethod]
        public static List<UserDto> SearchUser<T>(string searchTerm)
        {
            List<UserDto> users = getUsers.GetUserList(searchTerm);
            return users;
        }
    }
}