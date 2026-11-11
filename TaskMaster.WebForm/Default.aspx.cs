using System;
using TaskMasterEntity.src.Core.Application.Interfaces;

namespace TaskMasterEntity.src.WebForms
{
    public partial class Default : System.Web.UI.Page
    {
        public ICreateUser createUser { get; set; }
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
                _Gender = string.Empty;
                _Role = "Intern";

                UpdateGenderSelection();
                UpdateRoleSelection();
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

        // -------------------------
        // User Registration
        // -------------------------

        private ICreateUser.Req CreateUserAccount()
        {
            int age;

            if (!int.TryParse(tboxAge.Text, out age))
            {
                throw new ArgumentException("Age must be a valid number.");
            }

            if (string.IsNullOrWhiteSpace(_Gender))
            {
                throw new ArgumentException("Please select your gender.");
            }

            if (string.IsNullOrWhiteSpace(_Role))
            {
                throw new ArgumentException("Please select your role.");
            }

            ICreateUser.Req req = new ICreateUser.Req
            {
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                UserName = txtUsername.Text.Trim(),
                Password = txtPassword.Text,
                Age = age,
                Gender = _Gender,
                Role = _Role
            };

            // Create a Lifetime Scope for this operation.

            return req;
            
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {

            var req = CreateUserAccount();

            createUser.UserRegister(req);
            // Handle the registration result here.
        }
    }
}