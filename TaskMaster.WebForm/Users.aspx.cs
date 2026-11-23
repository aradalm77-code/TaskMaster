using System;
using System.Linq;
using System.Web.UI.WebControls;
using TaskMaster.Application.BaseInfo.Persons;
using TaskMaster.Application.BaseInfo.Users;

namespace TaskMaster.WebForm
{
    public partial class Users : System.Web.UI.Page
    {
        public ISearchUsers searchUser { get; set; }
        public ISearchPersons searchPersons { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            UsersRepeater.ItemDataBound += UsersRepeater_ItemDataBound;

            if (IsPostBack)
                return;

            LoadUsers();

        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }
        private void LoadUsers()
        {

            var items = searchUser.Respond(new ISearchUsers.Request
            {
                SearchItem = txtSearch.Text,
                PersonRequest = new ISearchPersons.Request
                {
                    SearchItem = txtSearch.Text
                }
            }).Select(i => new IUserDataAccess.ResponseDTO
            {
                User = i,
                Person = i.Person
            }).ToList();

            UsersRepeater.DataSource = items;
            UsersRepeater.DataBind();
        }

        protected void UsersRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item &&
                e.Item.ItemType != ListItemType.AlternatingItem)
                return;

            var user = (IUserDataAccess.ResponseDTO)e.Item.DataItem;

            var component = (Components.UserItem)e.Item.FindControl("UserItem");

            if (component == null || user == null)
                return;

            component.SetUser(user.User, user.Person);
        }
    }
}