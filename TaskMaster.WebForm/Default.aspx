<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TaskMaster.WebForm.Default" %>

<%@ Register
    Src="~/Components/MessageControl.ascx"
    TagPrefix="uc"
    TagName="Message" %>
<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Create Account | TaskMaster</title>

    <link href="https://fonts.googleapis.com/css2?family=Inter:wght@400;500;600;700;800&display=swap" rel="stylesheet" />
    <link href="./Css/Register.css" rel="stylesheet" />
    <link href="./Css/Message.css" rel="stylesheet" />
</head>

<body>

    <form id="form1" runat="server">

        <asp:ScriptManager
            ID="ScriptManager1"
            runat="server"
            EnablePageMethods="true" />

        <uc:Message
            ID="MessageBox"
            runat="server" />

        <main class="page">

            <div class="ambient ambient-one"></div>
            <div class="ambient ambient-two"></div>

            <section class="register-card">

                <!-- Brand -->
                <div class="brand">
                    <div class="brand-icon">T</div>
                    <span>TaskMaster</span>
                </div>

                <!-- Heading -->
                <header class="heading">
                    <span class="eyebrow">JOIN THE TEAM</span>
                    <h1>Create your account</h1>
                    <p>Enter your details below and become part of our team.</p>
                </header>

                <div class="fields">

                    <!-- First Name -->
                    <div class="field">

                        <label for="txtFirstName">First name</label>

                        <asp:TextBox
                            ID="txtFirstName"
                            runat="server"
                            CssClass="input"
                            placeholder="e.g. Alex"
                            MaxLength="50"
                            autocomplete="given-name" />

                        <asp:RequiredFieldValidator
                            ID="FirstNameValidator"
                            runat="server"
                            ControlToValidate="txtFirstName"
                            ErrorMessage="First name is required."
                            Display="none" />

                    </div>

                    <!-- Last Name -->
                    <div class="field">

                        <label for="txtLastName">Last name</label>

                        <asp:TextBox
                            ID="txtLastName"
                            runat="server"
                            CssClass="input"
                            placeholder="e.g. Morgan"
                            MaxLength="70"
                            autocomplete="family-name" />

                    </div>

                    <!-- Username -->
                    <div class="field full">

                        <label for="txtUsername">Username</label>

                        <div class="input-wrap">

                            <span class="input-icon">@</span>

                            <asp:TextBox
                                ID="txtUsername"
                                runat="server"
                                CssClass="input"
                                placeholder="Choose a username"
                                MaxLength="30"
                                autocomplete="username" />

                        </div>

                        <small class="field-hint">Use letters, numbers, and underscores.
                        </small>

                    </div>

                    <!-- Password -->
                    <div class="field">

                        <label for="txtPassword">Password</label>

                        <asp:TextBox
                            ID="txtPassword"
                            runat="server"
                            CssClass="input"
                            TextMode="Password"
                            placeholder="Create a password"
                            MaxLength="100"
                            autocomplete="new-password" />

                    </div>

                    <!-- Confirm Password -->
                    <div class="field">

                        <label for="txtConfirmPassword">Confirm password</label>

                        <asp:TextBox
                            ID="txtConfirmPassword"
                            runat="server"
                            CssClass="input"
                            TextMode="Password"
                            placeholder="Repeat your password"
                            MaxLength="100"
                            autocomplete="new-password" />

                    </div>

                    <!-- Age -->
                    <div class="field">

                        <label for="tboxAge">Age</label>

                        <asp:TextBox
                            ID="tboxAge"
                            runat="server"
                            CssClass="input age-input"
                            TextMode="Number"
                            placeholder="Enter your age"
                            min="1"
                            max="120"
                            step="1" />

                        <small class="field-hint">Enter your age in years.
                        </small>

                    </div>

                    <!-- Gender -->
                    <div class="field">

                        <label>Gender</label>

                        <asp:UpdatePanel
                            ID="GenderUpdatePanel"
                            runat="server"
                            UpdateMode="Conditional"
                            ChildrenAsTriggers="true">

                            <ContentTemplate>

                                <asp:HiddenField
                                    ID="hfGender"
                                    runat="server"
                                    Value="" />

                                <div class="gender-options"
                                    id="genderOptions"
                                    role="group"
                                    aria-label="Choose your gender">

                                    <asp:LinkButton
                                        ID="genderoptionMale"
                                        runat="server"
                                        CssClass="gender-option"
                                        OnClick="SelectMaleGender"
                                        CausesValidation="false">

                                        <span>Male</span>
                                        <span class="gender-check">✓</span>

                                    </asp:LinkButton>

                                    <asp:LinkButton
                                        ID="genderoptionFemale"
                                        runat="server"
                                        CssClass="gender-option"
                                        OnClick="SelectFemaleGender"
                                        CausesValidation="false">

                                        <span>Female</span>
                                        <span class="gender-check">✓</span>

                                    </asp:LinkButton>

                                </div>

                            </ContentTemplate>

                        </asp:UpdatePanel>

                    </div>

                </div>

                <!-- Role -->
                <asp:UpdatePanel
                    ID="RoleUpdatePanel"
                    runat="server"
                    UpdateMode="Conditional"
                    ChildrenAsTriggers="true">

                    <ContentTemplate>

                        <section class="role-section">

                            <div class="role-heading">

                                <div>
                                    <h2 class="role-title">Choose your role</h2>

                                    <p class="role-description">
                                        How will you contribute to the team?
                                   
                                    </p>
                                </div>

                                <asp:Label
                                    ID="lblRoleBadge"
                                    runat="server"
                                    CssClass="role-badge"
                                    Text="INTERN" />

                            </div>

                            <asp:HiddenField
                                ID="hfRole"
                                runat="server"
                                Value="Intern" />

                            <div class="role-switch" id="roleSwitch">

                                <!-- Intern -->
                                <asp:LinkButton
                                    ID="RoleSelectIntern"
                                    runat="server"
                                    CssClass="role-option active"
                                    OnClick="SelectRoleIntern"
                                    CausesValidation="false">

                                    <span class="role-symbol">✳</span>

                                    <span class="role-text">
                                        <strong>Intern</strong>
                                        <small>Learn &amp; grow</small>
                                    </span>

                                    <span class="role-check">✓</span>

                                </asp:LinkButton>

                                <!-- Designer -->
                                <asp:LinkButton
                                    ID="RoleSelectDesigner"
                                    runat="server"
                                    CssClass="role-option"
                                    OnClick="SelectRoleDesigner"
                                    CausesValidation="false">

                                    <span class="role-symbol">✦</span>

                                    <span class="role-text">
                                        <strong>Designer</strong>
                                        <small>Create &amp; design</small>
                                    </span>

                                    <span class="role-check">✓</span>

                                </asp:LinkButton>

                            </div>

                        </section>

                    </ContentTemplate>

                </asp:UpdatePanel>

                <!-- Register -->
                <asp:Button
                    ID="btnRegister"
                    runat="server"
                    Text="Create Account  →"
                    CssClass="submit-button"
                    OnClick="btnRegister_Click"
                    CausesValidation="false" />

                <!-- Footer -->
                <div class="footer">
                    <span>Already have an account?</span>
                    <a href="Login.aspx">Sign in</a>
                </div>

            </section>

            <div class="page-caption">
                <span class="caption-dot"></span>
                YOUR NEXT CHAPTER STARTS HERE
           
            </div>

        </main>

    </form>

</body>
</html>
