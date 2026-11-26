using System;
using System.Linq;
using TaskMaster.Application.BaseInfo.Users;
using TaskMaster.Domain.Entities;
using TaskMaster.Domain.Enums;

namespace TaskMaster.WebForm
{
    public partial class EditUser : System.Web.UI.Page
    {
        public IUpdateUser editUser { get; set; }
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
                string id = Request.QueryString["id"];
                var item = searchUsers.Respond(out int _, new ISearchUsers.Request { Id = Convert.ToInt32(id) }).Select(i => new
                {
                    i.Person.FirstName,
                    i.Person.LastName,
                    i.Username,
                    i.Person.Age,
                    i.Person.Gender,
                    i.Role
                }
                ).SingleOrDefault();

                if (item != null)
                {
                    txtFirstName.Text = item.FirstName;
                    txtLastName.Text = item.LastName;
                    txtUsername.Text = item.Username;
                    tboxAge.Text = item.Age.ToString();
                    _Gender = item.Gender == PersonGender.Gender.Male ? "male" : "female";
                    _Role = item.Role == UserRole.Role.Intern ? "Intern" : "Designer";
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
                Gender = gender == "male" ? PersonGender.Gender.Male : PersonGender.Gender.Female,
                Age = int.TryParse(ageText, out int age) ? age : 0
            };
            User user = new User
            {
                Id = Convert.ToInt32(Request.QueryString["id"]),
                Username = username,
                Password = password,
                Role = role == "Intern" ? UserRole.Role.Intern : UserRole.Role.Designer,
                Person = person
            };

            editUser.EditUser(new IUpdateUser.Request { User = user, Person = person });

            Response.Redirect("Users.aspx");
        }

    }
}
