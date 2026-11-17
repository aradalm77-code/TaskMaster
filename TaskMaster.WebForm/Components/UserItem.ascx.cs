using System;
using System.ComponentModel;
using System.Web.UI;
using TaskMasterEntity.src.Core.Application.Interfaces;
using TaskMasterEntity.src.Core.Domain.Entities;
using TaskMasterEntity.src.Core.Domain.Enums;
using static TaskMasterEntity.src.Core.Application.Interfaces.IGetUsers;

namespace TaskMasterEntity.src.WebForms.Components
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

        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnDelete_ServerClick(object sender, EventArgs e)
        {
           DeleteUser.Delete(int.Parse(UserId));

           this.Parent.Controls.Remove(this);
        }
 
        public void SetUser(User user)
        {
            if (user == null)
                return;
            User = user;
            Username = user.Username;
            userRow.Attributes["data-user-id"] = user.Id.ToString();
            string fullName = $"{user.Person.FirstName} {user.Person.LastName}";
            litName.Text = Server.HtmlEncode(fullName);
            litInitials.Text = Server.HtmlEncode($"{user.Person.FirstName[0].ToString().ToUpper()}{user.Person.LastName[0].ToString().ToUpper()}");
            litUsername.Text = Server.HtmlEncode(user.Username);
            litRole.Text = Server.HtmlEncode(user.Role.ToString());
            litLevel.Text = Server.HtmlEncode(user.Level.ToString());
            litScore.Text = Server.HtmlEncode(user.Score.ToString());
        }
        public void EditUser(object sender, EventArgs e)
        {
            Response.Redirect($"EditUser.aspx?username={Username}");
        }
    }
}