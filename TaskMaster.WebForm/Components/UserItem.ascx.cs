using System;
using System.Web.UI;
using TaskMaster.Application.BaseInfo.Users;
using TaskMaster.Domain.Entities;

namespace TaskMaster.WebForm.Components
{
    public partial class UserItem : UserControl
    {
        public IUserDataAccess userDataAccess { get; set; }
        public string Username
        {
            get { return litUsername.Text; }
            set { litUsername.Text = value; }
        }
        public IDeleteUser DeleteUser { get; set; }
        public User User { get; set; }
        public string UserId
        {
            get
            {
                return userRow.Attributes["data-user-id"];
            }
        }
        public string PersonId
        {
            get
            {
                return userRow.Attributes["data-person-id"];
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnDelete_ServerClick(object sender, EventArgs e)
        {
            DeleteUser.Delete(new IDeleteUser.Request { UserId = int.Parse(UserId), PersonId = int.Parse(PersonId) });

            this.Parent.Controls.Remove(this);
        }

        public void SetUser(User user, Person person)
        {
            if (user == null)
                return;
            User = user;
            Username = user.Username;
            userRow.Attributes["data-user-id"] = user.Id.ToString();
            userRow.Attributes["data-person-id"] = person.Id.ToString();
            string fullName = $"{person.FirstName} {person.LastName}";
            litName.Text = Server.HtmlEncode(fullName);
            litInitials.Text = Server.HtmlEncode($"{person.FirstName[0].ToString().ToUpper()}{person.LastName[0].ToString().ToUpper()}");
            litUsername.Text = Server.HtmlEncode(user.Username);
            litRole.Text = Server.HtmlEncode(user.Role.ToString());
            litLevel.Text = Server.HtmlEncode(user.Level.ToString());
            litScore.Text = Server.HtmlEncode(user.Score.ToString());
        }
        public void EditUser(object sender, EventArgs e)
        {
            Response.Redirect($"EditUser.aspx?id={UserId}");
        }
    }
}