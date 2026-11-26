
using System;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

using TaskMaster.Application.BaseInfo.Persons;
using TaskMaster.Application.BaseInfo.Users;
using TaskMaster.Domain.Entities;

namespace TaskMaster.WebForm
{
    public partial class Users : System.Web.UI.Page
    {
        public ISearchUsers SearchUser { get; set; }
        public int CurrentPageNumber
        {
            get
            {
                return ViewState["CurrentPageNumber"] != null
                    ? (int)ViewState["CurrentPageNumber"]
                    : 0;
            }
            set
            {
                ViewState["CurrentPageNumber"] = value;
            }
        }
        
        private int Totalpages
        {
            get
            {
                return ViewState["Totalpages"] != null
                    ? (int)ViewState["Totalpages"]
                    : 0;
            }
            set
            {
                ViewState["Totalpages"] = value;
            }
        }

        // Page size
        private const int PageSize = 6;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            HttpCookie username = Request.Cookies["Username"];

            //if (username is null) Response.Redirect("./Login.aspx");
            CurrentPageNumber = 0;
            LoadUsers();

        }

        // Search
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            CurrentPageNumber = 0;
            LoadUsers();
        }

        // Load users
        private void LoadUsers()
        {
            var request = new ISearchUsers.Request
            {
                SearchItem = txtSearch.Text.Trim(),
                PageNumber = CurrentPageNumber,
                PgeSize = PageSize
            };
            
            var result = SearchUser.Respond(
                out int totalPages,
                request
            );

            Totalpages = totalPages;
            
            if (Totalpages <= 0)
            {
                CurrentPageNumber = 0;
            }
            else
            {
                if (CurrentPageNumber >= Totalpages)
                {
                    CurrentPageNumber = Totalpages - 1;

                    request.PageNumber = CurrentPageNumber;

                    result = SearchUser.Respond(
                        out totalPages,
                        request
                    );

                    Totalpages = totalPages;
                }
            }
            
            var items = result
                .Select(user => new
                {
                    User = user,
                    Person = user.Person
                })
                .ToList();
            
            UsersRepeater.ItemDataBound -= UsersRepeater_ItemDataBound;
            UsersRepeater.ItemDataBound += UsersRepeater_ItemDataBound;
            
            UsersRepeater.DataSource = items;
            UsersRepeater.DataBind();

            // Update pagination information
            CurrentPage.InnerText = Totalpages > 0
                ? $"Page {CurrentPageNumber + 1} of {Totalpages}"
                : "Page 0 of 0";

            // Enable / Disable buttons
            btnPreviousPage.Enabled = CurrentPageNumber > 0;

            btnNextPage.Enabled =
                Totalpages > 0 &&
                CurrentPageNumber < Totalpages - 1;
        }
        
        private void UsersRepeater_ItemDataBound(
            object sender,
            RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item &&
                e.Item.ItemType != ListItemType.AlternatingItem)
            {
                return;
            }

            dynamic data = e.Item.DataItem;

            User user = data.User;
            Person person = data.Person;

            var component = e.Item.FindControl("UserItem")
                as Components.UserItem;

            if (component == null || user == null || person == null)
            {
                return;
            }

            component.SetUser(user, person);
        }

        // Next page
        protected void btnNextPage_Click(object sender, EventArgs e)
        {
            if (CurrentPageNumber >= Totalpages - 1)
            {
                return;
            }

            CurrentPageNumber++;

            LoadUsers();
        }

        // Previous page
        protected void btnPreviousPage_Click(object sender, EventArgs e)
        {
            if (CurrentPageNumber <= 0)
            {
                return;
            }

            CurrentPageNumber--;

            LoadUsers();
        }
    }
}
