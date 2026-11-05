using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using TaskMasterEntity.src.Core.Domain.Entities;
using TaskMasterEntity.src.Core.Infrastructure.Pesrcsstance.Services;
using TaskMasterEntity.src.Core.Application.Interfaces;
namespace TaskMasterEntity.src.WebForms
{
    public partial class Users : System.Web.UI.Page
    {
        private static readonly IUserDataAccess userService = new UserDataAcces();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static List<User> LoadUser()
        {
            List<User> users = userService.GetUsers();
            return users;
        }
        [WebMethod]
        public static void DeleteUser(string username)
        {
            User user = userService.GetUserByUsername(username);
            if (user == null) throw new Exception("User does not Exist");
            userService.RemoveUser(user);
        }
        [WebMethod]
        public static List<User> SearchUser(string searchTerm)
        {
            List<User> users = userService.SearchUser(searchTerm);
            return users;
        }
    }
}