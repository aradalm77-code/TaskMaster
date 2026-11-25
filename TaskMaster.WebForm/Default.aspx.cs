using System;
using System.Text.RegularExpressions;
using System.Web.UI;
using TaskMaster.Application.BaseInfo.Users;
using TaskMaster.Domain.Exceptions;
using TaskMaster.WebForm.Components;

namespace TaskMaster.WebForm
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
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPassword.Text != txtConfirmPassword.Text)
                    throw new AppException("Please confirm your password correctly");

                if (!int.TryParse(tboxAge.Text, out int age))
                    throw new AppException("Age must be a valid number.");

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

                createUser.UserRegister(req);
            }
            catch (AppException ex)
            {
                MessageBox.ShowMessage(
                    ex.Message,
                    MessageControl.MessageType.Error
                );
            }
        }
    }
}