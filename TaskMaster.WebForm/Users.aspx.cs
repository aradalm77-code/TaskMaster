using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using TaskMasterEntity.src.Core.Domain.Entities;
using TaskMasterEntity.src.Core.Application.Interfaces;
using TaskMasterEntity.src.Core.Infrastructure.Pesrcsstance.DataAccess;
using TaskMasterEntity.src.Core.Application.Features.Users.Services.UserService;
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
        public static List<User> LoadUser()
        {
            List<User> users = getUsers.GetUserList();
            return users;
        }
        [WebMethod]
        public static void DeleteUser(int id)
        {
            deleteUser.Delete(id);
        }
        [WebMethod]
        public static List<User> SearchUser(string searchTerm)
        {
            List<User> users = getUsers.SearchUser(searchTerm);
            return users;
        }
    }
}