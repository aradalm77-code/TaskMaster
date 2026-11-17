<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="TaskMasterEntity.src.WebForms.EditUser" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Edit User | TaskMaster</title>
    <link href="./Css/Register.css" rel="stylesheet" />
    <link href="./Css/Message.css" rel="stylesheet" />
</head>

<body>
    <form id="form1" runat="server">

        <asp:ScriptManager
            ID="ScriptManager1"
            runat="server"
            EnablePageMethods="true" />

        <!-- FORM MESSAGE -->
        <div class="form-message success"
            id="formMessage"
            role="status"
            aria-live="polite">

            <span class="message-icon" aria-hidden="true">

                <svg class="icon-success" viewBox="0 0 24 24" fill="none">
                    <path d="M5 12.5L9.5 17L19 7"
                        stroke="currentColor"
                        stroke-width="2"
                        stroke-linecap="round"
                        stroke-linejoin="round" />
                </svg>

                <svg class="icon-error" viewBox="0 0 24 24" fill="none">
                    <path d="M12 8V13"
                        stroke="currentColor"
                        stroke-width="2"
                        stroke-linecap="round" />
                    <circle cx="12" cy="16.5" r="1" fill="currentColor" />
                    <circle cx="12" cy="12" r="9"
                        stroke="currentColor"
                        stroke-width="2" />
                </svg>

                <svg class="icon-warning" viewBox="0 0 24 24" fill="none">
                    <path d="M12 8V13"
                        stroke="currentColor"
                        stroke-width="2"
                        stroke-linecap="round" />
                    <circle cx="12" cy="16.5" r="1" fill="currentColor" />
                    <path d="M10.3 4.8L2.8 18A2 2 0 0 0 4.5 21H19.5A2 2 0 0 0 21.2 18L13.7 4.8A2 2 0 0 0 10.3 4.8Z"
                        stroke="currentColor"
                        stroke-width="2"
                        stroke-linejoin="round" />
                </svg>

            </span>

            <span class="message-content">
                <strong class="message-title">Success</strong>
                <span class="message-text">User information has been updated successfully.
                </span>
            </span>

            <button
                type="button"
                class="message-close"
                aria-label="Dismiss message"
                id="closeMessage">
                &times;
           
            </button>

        </div>

        <!-- PAGE -->
        <main class="page">

            <div class="ambient ambient-one"></div>
            <div class="ambient ambient-two"></div>

            <section class="register-card">

                <!-- BRAND -->
                <div class="brand">
                    <div class="brand-icon">T</div>
                    <span>TaskMaster</span>
                </div>

                <!-- HEADING -->
                <header class="heading">
                    <span class="eyebrow">TEAM MANAGEMENT</span>
                    <h1>Edit User</h1>
                    <p>Update your team member information below.</p>
                </header>

                <!-- USER FIELDS -->
                <div class="fields">

                    <!-- FIRST NAME -->
                    <div class="field">

                        <label for="txtFirstName">First name</label>

                        <asp:TextBox
                            ID="txtFirstName"
                            runat="server"
                            CssClass="input"
                            placeholder="e.g. Alex"
                            MaxLength="50"
                            autocomplete="given-name" />

                    </div>

                    <!-- LAST NAME -->
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

                    <!-- USERNAME -->
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

                    <!-- PASSWORD -->
                    <div class="field">

                        <label for="txtPassword">Password</label>

                        <asp:TextBox
                            ID="txtPassword"
                            runat="server"
                            CssClass="input"
                            TextMode="Password"
                            placeholder="Enter new password"
                            MaxLength="100"
                            autocomplete="new-password" />

                    </div>

                    <!-- CONFIRM PASSWORD -->
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

                    <!-- AGE -->
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

                    <!-- GENDER -->
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

                                <div
                                    class="gender-options"
                                    id="genderOptions"
                                    role="group"
                                    aria-label="Choose your gender">

                                    <!-- MALE -->
                                    <asp:LinkButton
                                        ID="genderoptionMale"
                                        runat="server"
                                        CssClass="gender-option"
                                        OnClick="SelectMaleGender"
                                        CausesValidation="false">

                                        <span>Male</span>
                                        <span class="gender-check">✓</span>

                                    </asp:LinkButton>

                                    <!-- FEMALE -->
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

                <!-- ROLE -->
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

                                <!-- INTERN -->
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

                                <!-- DESIGNER -->
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

                <!-- ACTIONS -->
                <div class="form-actions">



                    <asp:Button
                        ID="btnSave"
                        runat="server"
                        Text="Save Changes  →"
                        CssClass="submit-button"
                        OnClick="btnSave_Click"
                        CausesValidation="false" />

                    <asp:Button
                        ID="btnCancel"
                        runat="server"
                        Text="Cancel"
                        CssClass="cancel-button"
                        CausesValidation="false"
                        UseSubmitBehavior="false"
                        OnClientClick="window.location.href='Users.aspx'; return false;" />

                </div>

                <!-- FOOTER -->
                <div class="footer">
                    <span>TaskMaster Team Management</span>
                </div>

            </section>

        </main>

    </form>

    <script src="./Scrypts/scrypt.js" type="module"></script>

</body>
</html>
