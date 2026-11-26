using System;
using System.Web;
using TaskMaster.Application.BaseInfo.Users;
using TaskMaster.Domain.Exceptions;

namespace TaskMaster.WebForm
{
    public partial class Login : System.Web.UI.Page
    {
        public IHashPassword HashPassword { get; set; }
        public ILoginUser LoginUser { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            HttpCookie username = Request.Cookies["Username"];

            if (username != null) Response.Redirect("./Users.aspx");
        }
        public void Signin(object sender, EventArgs e)
        {
            try
            {
                string username = LoginUser.Login(new ILoginUser.Request
                {
                    Username = txtUsername.Text,
                    Password = txtPassword.Text
                });
                HttpCookie cookie = new HttpCookie("Username");

                cookie.Value = username;

                Response.Cookies.Add(cookie);
                Response.Redirect("./Users.aspx");
            }
            catch (AppException ex)
            {
                MessageBox.ShowMessage(
                    ex.Message,
                    Components.MessageControl.MessageType.Error
                    );
            }

        }
    }
}