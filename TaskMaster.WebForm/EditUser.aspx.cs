using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskMasterEntity.src.Core.Application.BaseInfo.UserManagment;
using TaskMasterEntity.src.Core.Application.Interfaces;
using TaskMasterEntity.src.Core.Domain.Entities;
using TaskMasterEntity.src.Core.Domain.Enums;
using static TaskMasterEntity.src.Core.Domain.Enums.PersonGender;
using static TaskMasterEntity.src.Core.Domain.Enums.UserRole;

namespace TaskMasterEntity.src.WebForms
{
    public partial class EditUser : System.Web.UI.Page
    {
        public IUpdateUser editUser { get; set; }
        public IUserDataAccess userDataAccess { get; set; }
        public ISearchPersons searchPersons { get; set; }
        public ISearchUsers searchUsers { get; set; }
        // Selected Gender
        private string _Gender
        {
            get { return hfGender.Value; }
            set { hfGender.Value = value; }
        }

        // Selected Role
        private string _Role
        {
            get { return hfRole.Value; }
            set { hfRole.Value = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string username = Request.QueryString["username"];
                User user = userDataAccess.GetUserByUsername(username);
                if (user != null)
                {
                    txtFirstName.Text = user.Person.FirstName;
                    txtLastName.Text = user.Person.LastName;
                    txtUsername.Text = user.Username;
                    txtPassword.Text = user.Password;
                    txtConfirmPassword.Text = user.Password;
                    tboxAge.Text = user.Person.Age.ToString();
                    _Gender = user.Person.Gender == PersonGender.Gender.male ? "male" : "female";
                    _Role = user.Role == UserRole.Role.Intern ? "Intern" : "Designer";
                    UpdateGenderSelection();
                    UpdateRoleSelection();
                }
            }
        }

        // -------------------------
        // Gender Selection
        // -------------------------

        protected void SelectMaleGender(object sender, EventArgs e)
        {
            _Gender = "male";

            UpdateGenderSelection();
        }

        protected void SelectFemaleGender(object sender, EventArgs e)
        {
            _Gender = "female";

            UpdateGenderSelection();
        }

        private void UpdateGenderSelection()
        {
            genderoptionMale.CssClass = "gender-option";
            genderoptionFemale.CssClass = "gender-option";

            if (_Gender == "male")
            {
                genderoptionMale.CssClass += " active";
            }
            else if (_Gender == "female")
            {
                genderoptionFemale.CssClass += " active";
            }
        }

        // -------------------------
        // Role Selection
        // -------------------------

        protected void SelectRoleIntern(object sender, EventArgs e)
        {
            _Role = "Intern";

            UpdateRoleSelection();
        }

        protected void SelectRoleDesigner(object sender, EventArgs e)
        {
            _Role = "Designer";

            UpdateRoleSelection();
        }

        private void UpdateRoleSelection()
        {
            RoleSelectIntern.CssClass = "role-option";
            RoleSelectDesigner.CssClass = "role-option";

            if (_Role == "Intern")
            {
                RoleSelectIntern.CssClass += " active";
            }
            else if (_Role == "Designer")
            {
                RoleSelectDesigner.CssClass += " active";
            }

            lblRoleBadge.Text = _Role.ToUpperInvariant();
        }
        public void btnSave_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string gender = _Gender;
            string role = _Role;
            string ageText = tboxAge.Text.Trim();


            Person person = new Person
            {
                FirstName = firstName,
                LastName = lastName,
                Gender = gender == "male" ? PersonGender.Gender.male : PersonGender.Gender.female,
                Age = int.TryParse(ageText, out int age) ? age : 0
            };
            User user = new User
            {
                Username = username,
                Password = password,
                Role = role == "Intern" ? UserRole.Role.Intern : UserRole.Role.Designer,
                Person = person
            };
            string _username = Request.QueryString["username"];

            IUpdateUser.Request request = new IUpdateUser.Request
            {
                User = user,
                Username = _username
            };

            editUser.EditUser(request);

            Response.Redirect("Users.aspx");
        }

    }
}
