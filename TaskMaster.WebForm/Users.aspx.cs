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
                List<User> users = getUsers.GetUserList().ToList();
                foreach (var user in users)
                {
                    user.Person = searchPersons.SearchPeople(new ISearchPersons.Request { Id = user.PersonId }).FirstOrDefault();
                }
                LoadUsers(users);
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text;
            
            ISearchUsers.Request request = new ISearchUsers.Request
            {
                SearchItem = searchTerm
            };
            List<User> users = searchUser.Search(request).ToList();

            UsersRepeater.DataSource = users;
            UsersRepeater.DataBind();
        }
        private void LoadUsers(List<User> users)
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

            var user = (User)e.Item.DataItem;

            var component =
                (Components.UserItem)e.Item.FindControl("UserItem");

            if (component == null || user == null)
                return;

            component.SetUser(user);
        }
    }
}