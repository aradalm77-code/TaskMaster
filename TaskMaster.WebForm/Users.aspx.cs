using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskMasterEntity.src.Core.Application.Interfaces;
using Autofac;
using System.Collections.Generic;
using System.Linq;
using TaskMasterEntity.src.Core.Application.BaseInfo.UserManagment;
using TaskMasterEntity.src.Core.Domain.Entities;

namespace TaskMasterEntity.src.WebForms
{
    public partial class Users : System.Web.UI.Page
    {
        public ISearchUsers searchUser { get; set; }
        public IGetUsers getUsers { get; set; }
        public ISearchPersons searchPersons { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            UsersRepeater.ItemDataBound += UsersRepeater_ItemDataBound;

            if (!IsPostBack)
            {
                List<IUserDataAccess.ResponseDTO> users = getUsers.GetUserList().ToList();
                foreach (var user in users)
                {
                    user.Person = searchPersons.SearchPeople(new ISearchPersons.Request { Id = user.User.PersonId }).FirstOrDefault();
                }
                LoadUsers(users);
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text;
            
            ISearchUsers.Request request = new ISearchUsers.Request
            {
                SearchItem = searchTerm,
                PersonRequest = new ISearchPersons.Request
                {
                    SearchItem = searchTerm
                }
            };
            List<IUserDataAccess.ResponseDTO> users = searchUser.Search(request).ToList();

            LoadUsers(users);
        }
        private void LoadUsers(List<IUserDataAccess.ResponseDTO> users)
        {
            UsersRepeater.DataSource = users;
            UsersRepeater.DataBind();
        }

        protected void UsersRepeater_ItemDataBound(
            object sender,
            RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item &&
                e.Item.ItemType != ListItemType.AlternatingItem)
                return;

            var user = (IUserDataAccess.ResponseDTO)e.Item.DataItem;

            var component =
                (Components.UserItem)e.Item.FindControl("UserItem");

            if (component == null || user == null)
                return;

            component.SetUser(user.User, user.Person);
        }
    }
}