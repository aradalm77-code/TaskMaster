<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TaskMaster.WebForm.Login" %>
<%@ Register
    Src="~/Components/MessageControl.ascx"
    TagPrefix="uc"
    TagName="Message" %>
<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <title>Sign In | TaskMaster</title>

    <link href="https://fonts.googleapis.com/css2?family=Inter:wght@400;500;600;700;800&display=swap"
        rel="stylesheet" />

    <link href="./Css/Login.css" rel="stylesheet" />
    <link href="./Css/Message.css" rel="stylesheet" />
</head>

<body>

    <form id="form1" runat="server">
        <uc:message
            id="MessageBox"
            runat="server" />
        <main class="page">

            <div class="ambient ambient-one"></div>
            <div class="ambient ambient-two"></div>

            <section class="login-card">

                <!-- Brand -->
                <a href="Default.aspx" class="brand">
                    <span class="brand-icon">T</span>
                    <span>TaskMaster</span>
                </a>

                <!-- Heading -->
                <header class="heading">
                    <span class="eyebrow">WELCOME BACK</span>

                    <h1>Sign in to your account</h1>

                    <p>
                        Enter your credentials to access your workspace
                        and continue where you left off.
                   
                    </p>
                </header>

                <!-- Login Form -->
                <div class="login-form">

                    <div class="field">
                        <label for="txtUsername">Username</label>

                        <div class="input-wrap">
                            <span class="input-icon">@</span>

                            <asp:TextBox
                                ID="txtUsername"
                                runat="server"
                                CssClass="input"
                                placeholder="Enter your username"
                                MaxLength="50"
                                autocomplete="username" />
                        </div>
                    </div>

                    <div class="field">
                        <div class="password-heading">
                            <label for="txtPassword">Password</label>

                            <a href="#" class="forgot-link">Forgot password?
                            </a>
                        </div>

                        <div class="input-wrap">
                            <span class="input-icon lock-icon">⌑</span>

                            <asp:TextBox
                                ID="txtPassword"
                                runat="server"
                                CssClass="input password-input"
                                TextMode="Password"
                                placeholder="Enter your password"
                                MaxLength="100"
                                autocomplete="current-password" />

                            <button
                                type="button"
                                class="password-toggle"
                                id="togglePassword"
                                aria-label="Show password">
                                <svg viewBox="0 0 24 24" fill="none"
                                    aria-hidden="true">
                                    <path d="M2.5 12S6 5.5 12 5.5
                                        21.5 12 21.5 12
                                        18 18.5 12 18.5
                                        2.5 12 2.5 12Z"
                                        stroke="currentColor"
                                        stroke-width="1.7"
                                        stroke-linejoin="round" />
                                    <circle cx="12" cy="12" r="3"
                                        stroke="currentColor"
                                        stroke-width="1.7" />
                                </svg>
                            </button>
                        </div>
                    </div>

                    <div class="form-options">

                        <asp:CheckBox
                            ID="chkRememberMe"
                            runat="server"
                            CssClass="remember-checkbox"
                            Text="Remember me" />

                    </div>

                    <asp:Button
                        ID="btnLogin"
                        runat="server"
                        Text="Sign In  →"
                        CssClass="submit-button" 
                        OnClick="Signin" />
                        

                </div>

                <!-- Footer -->
                <div class="footer">
                    <span>Don't have an account?</span>
                    <a href="Default.aspx">Create an account</a>
                </div>

            </section>

            <footer class="page-caption">
                <span class="caption-dot"></span>
                YOUR WORKSPACE. YOUR PROGRESS.
           
            </footer>

        </main>

    </form>

    <script src="Scrypts/Login.js"></script>

</body>
