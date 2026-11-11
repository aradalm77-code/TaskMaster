using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using TaskMasterEntity.src.Core.Application.Interfaces;
using TaskMasterEntity.src.Core.Application.Features.Users.Services.UserService;
using Autofac;
namespace TaskMasterEntity.src.WebForms
{
    public partial class Users : System.Web.UI.Page
    {
        private IDeleteUser deleteUser { get; set; }
        public IGetUsers getUsers { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public List<IGetUsers.UserDto> LoadUser()
        {
            List<IGetUsers.UserDto> users = getUsers.GetUserList("");
            return users;
        }
        [WebMethod]
        public void DeleteUser(int id)
        {
            deleteUser.Delete(id);
        }
        [WebMethod]
        public List<IGetUsers.UserDto> SearchUser<T>(string searchTerm)
        {
            List<IGetUsers.UserDto> users = getUsers.GetUserList(searchTerm);
            return users;
        }
    }
}