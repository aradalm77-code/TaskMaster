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
using Autofac;
namespace TaskMasterEntity.src.WebForms
{
    public partial class Users : System.Web.UI.Page
    {
        private static IDeleteUser deleteUser { get; set; }
        public static IGetUsers getUsers { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static List<UserDto> LoadUser()
        {
            using (var scope = Global.Container.BeginLifetimeScope())
            {
                getUsers = scope.Resolve<IGetUsers>();
                List<UserDto> users = getUsers.GetUserList("");
                return users;
            }
        }
        [WebMethod]
        public static void DeleteUser(int id)
        {
            using (var scope = Global.Container.BeginLifetimeScope())
            {
                deleteUser = scope.Resolve<IDeleteUser>();
                deleteUser.Delete(id);
            }
        }
        [WebMethod]
        public static List<UserDto> SearchUser<T>(string searchTerm)
        {
            List<UserDto> users = getUsers.GetUserList(searchTerm);
            return users;
        }
    }
}