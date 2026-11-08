<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TaskMasterEntity.src.WebForms.Default" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Create Account | TaskMaster</title>

    <link href="https://fonts.googleapis.com/css2?family=Inter:wght@400;500;600;700;800&display=swap" rel="stylesheet" />

    <style>
        :root {
            --bg: #090b13;
            --card: rgba(19, 23, 38, .92);
            --border: rgba(255, 255, 255, .09);
            --text: #f2f4ff;
            --muted: #8d94ad;
            --accent: #8b7cff;
            --cyan: #54e5df;
        }

        * {
            box-sizing: border-box;
        }

        html {
            min-height: 100%;
        }

        body {
            margin: 0;
            min-height: 100vh;
            font-family: 'Inter', sans-serif;
            background: var(--bg);
            color: var(--text);
        }

        button, input {
            font: inherit;
        }

        .page {
            position: relative;
            isolation: isolate;
            min-height: 100vh;
            padding: 45px 18px 25px;
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            overflow: hidden;
        }

        .ambient {
            position: fixed;
            z-index: -1;
            width: 400px;
            height: 400px;
            border-radius: 50%;
            filter: blur(110px);
            opacity: .17;
            pointer-events: none;
        }

        .ambient-one {
            top: -150px;
            right: -100px;
            background: #7257ff;
        }

        .ambient-two {
            bottom: -180px;
            left: -100px;
            background: #00d7d0;
        }

        .register-card {
            width: min(100%, 600px);
            padding: 34px;
            border: 1px solid var(--border);
            border-radius: 26px;
            background: var(--card);
            box-shadow: 0 30px 100px rgba(0, 0, 0, .35);
            backdrop-filter: blur(20px);
            -webkit-backdrop-filter: blur(20px);
            animation: appear .65s ease both;
        }

        .brand {
            display: flex;
            align-items: center;
            gap: 11px;
            width: fit-content;
            font-size: 15px;
            font-weight: 800;
            letter-spacing: -.3px;
        }

        .brand-icon {
            display: grid;
            place-items: center;
            width: 38px;
            height: 38px;
            border-radius: 12px;
            color: #10121d;
            background: linear-gradient(135deg, var(--cyan), #a79aff);
            box-shadow: 0 5px 25px rgba(84, 229, 223, .15);
        }

        .heading {
            margin: 29px 0 27px;
        }

        .eyebrow {
            display: inline-block;
            color: var(--cyan);
            font-size: 10px;
            font-weight: 800;
            letter-spacing: 2.5px;
        }

        .heading h1 {
            margin: 12px 0 9px;
            font-size: clamp(25px, 4vw, 31px);
            font-weight: 800;
            letter-spacing: -1.1px;
        }

        .heading p {
            margin: 0;
            color: var(--muted);
            font-size: 13px;
            line-height: 1.8;
        }

        .fields {
            display: grid;
            grid-template-columns: 1fr 1fr;
            gap: 20px 15px;
        }

        .field {
            min-width: 0;
        }

            .field.full {
                grid-column: 1 / -1;
            }

            .field label {
                display: block;
                margin-bottom: 9px;
                color: #dce0f2;
                font-size: 12px;
                font-weight: 600;
            }

        .input {
            display: block;
            width: 100%;
            height: 49px;
            padding: 0 14px;
            outline: none;
            border: 1px solid rgba(255, 255, 255, .09);
            border-radius: 12px;
            background: rgba(5, 8, 18, .55);
            color: var(--text);
            font-size: 13px;
            transition: border-color .25s, box-shadow .25s, background .25s;
        }

            .input::placeholder {
                color: #626b84;
            }

            .input:focus {
                border-color: rgba(139, 124, 255, .85);
                background: rgba(12, 15, 28, .95);
                box-shadow: 0 0 0 3px rgba(139, 124, 255, .12);
            }

        .input-wrap {
            position: relative;
        }

            .input-wrap .input {
                padding-left: 40px;
            }

        .input-icon {
            position: absolute;
            top: 50%;
            left: 14px;
            transform: translateY(-50%);
            color: var(--cyan);
            font-size: 16px;
            pointer-events: none;
        }

        .field-hint {
            display: block;
            margin-top: 7px;
            color: #737c96;
            font-size: 10px;
            line-height: 1.7;
        }

        /* Gender selection */
        .gender-options {
            display: grid;
            grid-template-columns: 1fr 1fr;
            gap: 10px;
        }

        .gender-option {
            position: relative;
            display: flex;
            align-items: center;
            justify-content: center;
            gap: 9px;
            min-height: 49px;
            padding: 10px 12px;
            color: var(--muted);
            background: rgba(5, 8, 18, .55);
            border: 1px solid rgba(255, 255, 255, .09);
            border-radius: 12px;
            font-size: 12px;
            font-weight: 600;
            cursor: pointer;
            transition: border-color .2s, background .2s, color .2s, transform .2s;
        }

        .gender-option:hover {
            border-color: rgba(139, 124, 255, .55);
            transform: translateY(-1px);
        }

        .gender-option.active {
            color: var(--text);
            border-color: rgba(84, 229, 223, .75);
            background: linear-gradient(120deg, rgba(84, 229, 223, .12), rgba(139, 124, 255, .12));
            box-shadow: 0 0 0 3px rgba(84, 229, 223, .06);
        }

        .gender-option .gender-check {
            display: grid;
            place-items: center;
            width: 17px;
            height: 17px;
            border: 1px solid #4c536b;
            border-radius: 50%;
            color: transparent;
            font-size: 10px;
        }

        .gender-option.active .gender-check {
            color: #0b0d17;
            border-color: var(--cyan);
            background: var(--cyan);
        }

        .age-input {
            direction: ltr;
            text-align: left;
        }

        .age-input::-webkit-inner-spin-button,
        .age-input::-webkit-outer-spin-button {
            opacity: 1;
        }

        .role-section {
            margin-top: 28px;
        }

        .role-heading {
            display: flex;
            align-items: center;
            justify-content: space-between;
            gap: 12px;
            margin-bottom: 14px;
        }

        .role-title {
            margin: 0 0 5px;
            color: #dce0f2;
            font-size: 12px;
            font-weight: 700;
        }

        .role-description {
            margin: 0;
            color: var(--muted);
            font-size: 11px;
        }

        .role-badge {
            padding: 6px 9px;
            border: 1px solid rgba(84, 229, 223, .2);
            border-radius: 7px;
            color: var(--cyan);
            background: rgba(84, 229, 223, .06);
            font-size: 9px;
            font-weight: 800;
            letter-spacing: 1px;
        }

        .role-switch {
            display: grid;
            grid-template-columns: 1fr 1fr;
            gap: 10px;
        }

        .role-option {
            display: flex;
            align-items: center;
            gap: 11px;
            min-width: 0;
            min-height: 76px;
            padding: 12px;
            text-align: left;
            cursor: pointer;
            color: var(--text);
            border: 1px solid var(--border);
            border-radius: 14px;
            background: rgba(5, 8, 18, .4);
            transition: border-color .25s, background .25s, transform .25s;
        }

            .role-option:hover {
                border-color: rgba(139, 124, 255, .5);
                transform: translateY(-2px);
            }

            .role-option.active {
                border-color: rgba(139, 124, 255, .85);
                background: linear-gradient(120deg, rgba(139, 124, 255, .15), rgba(84, 229, 223, .045));
                box-shadow: inset 0 0 20px rgba(139, 124, 255, .04);
            }

        .role-symbol {
            flex: 0 0 38px;
            display: grid;
            place-items: center;
            width: 38px;
            height: 38px;
            border-radius: 11px;
            color: #a89cff;
            background: rgba(139, 124, 255, .12);
            font-size: 19px;
        }

        .role-option[data-role="Designer"] .role-symbol {
            color: var(--cyan);
            background: rgba(84, 229, 223, .1);
        }

        .role-text {
            display: flex;
            flex-direction: column;
            gap: 5px;
        }

            .role-text strong {
                font-size: 12px;
                font-weight: 700;
            }

            .role-text small {
                color: var(--muted);
                font-size: 10px;
            }

        .role-check {
            display: grid;
            place-items: center;
            flex: 0 0 18px;
            width: 18px;
            height: 18px;
            margin-left: auto;
            border: 1px solid #4c536b;
            border-radius: 50%;
            color: transparent;
            font-size: 10px;
            transition: .2s;
        }

        .role-option.active .role-check {
            color: #0b0d17;
            border-color: var(--cyan);
            background: var(--cyan);
        }

        .submit-button {
            display: block;
            width: 100%;
            min-height: 51px;
            margin-top: 27px;
            padding: 12px 18px;
            border: 0;
            border-radius: 12px;
            color: #0a0c15;
            background: linear-gradient(100deg, var(--cyan), #a89aff);
            box-shadow: 0 8px 25px rgba(84, 229, 223, .12);
            font-size: 13px;
            font-weight: 800;
            cursor: pointer;
            transition: transform .2s, box-shadow .2s, filter .2s;
        }

            .submit-button:hover {
                transform: translateY(-2px);
                box-shadow: 0 12px 30px rgba(139, 124, 255, .22);
                filter: brightness(1.06);
            }

            .submit-button:active {
                transform: scale(.99);
            }

        .footer {
            display: flex;
            justify-content: center;
            gap: 6px;
            margin-top: 23px;
            color: var(--muted);
            font-size: 12px;
        }

            .footer a {
                color: var(--cyan);
                font-weight: 700;
                text-decoration: none;
            }

                .footer a:hover {
                    text-decoration: underline;
                }

        .page-caption {
            display: flex;
            align-items: center;
            gap: 8px;
            margin-top: 23px;
            color: #656d84;
            font-size: 9px;
            letter-spacing: 2px;
        }

        .caption-dot {
            width: 6px;
            height: 6px;
            border-radius: 50%;
            background: var(--cyan);
            box-shadow: 0 0 12px var(--cyan);
        }

        @keyframes appear {
            from {
                opacity: 0;
                transform: translateY(15px);
            }

            to {
                opacity: 1;
                transform: translateY(0);
            }
        }

        @media (max-width: 520px) {
            .page {
                padding: 22px 12px;
            }

            .register-card {
                padding: 24px 19px;
                border-radius: 21px;
            }

            .heading {
                margin-top: 24px;
            }

            .fields {
                grid-template-columns: 1fr;
                gap: 16px;
            }

            .field.full {
                grid-column: auto;
            }

            .role-option {
                gap: 7px;
                padding: 9px 7px;
            }

            .role-symbol {
                flex-basis: 31px;
                width: 31px;
                height: 31px;
            }
        }

        @media (prefers-reduced-motion: reduce) {
            *, *::before, *::after {
                animation-duration: .01ms !important;
                transition-duration: .01ms !important;
            }
        }

        /* ========================================
   FORM MESSAGE
======================================== */

        .form-message {
            --message-color: #54e5df;
            --message-bg: rgba(84, 229, 223, 0.07);
            --message-border: rgba(84, 229, 223, 0.22);
            display: flex;
            align-items: center;
            gap: 13px;
            width: 100%;
            box-sizing: border-box;
            margin: 0 0 22px;
            padding: 14px;
            color: var(--text, #f4f5fb);
            background: var(--message-bg);
            border: 1px solid var(--message-border);
            border-radius: 14px;
            /* Initial hidden state */
            opacity: 0;
            visibility: hidden;
            pointer-events: none;
            max-height: 0;
            overflow: hidden;
            padding-top: 0;
            padding-bottom: 0;
            margin-top: 0;
            margin-bottom: 0;
            border-width: 0;
            transform: translateY(-10px) scale(0.98);
            transform-origin: top center;
            transition: opacity 250ms ease, transform 250ms ease, visibility 250ms ease, max-height 300ms ease, padding 300ms ease, margin 300ms ease, border-width 300ms ease;
        }

            /* Visible state */
            .form-message.active {
                opacity: 1;
                visibility: visible;
                pointer-events: auto;
                max-height: 160px;
                padding: 14px;
                margin: 0 0 22px;
                border-width: 1px;
                transform: translateY(0) scale(1);
            }

            /* ========================================
   MESSAGE TYPES
======================================== */

            .form-message.success {
                --message-color: #54e5df;
                --message-bg: rgba(84, 229, 223, 0.07);
                --message-border: rgba(84, 229, 223, 0.22);
            }

            .form-message.error {
                --message-color: #ff718b;
                --message-bg: rgba(255, 113, 139, 0.07);
                --message-border: rgba(255, 113, 139, 0.24);
            }

            .form-message.warning {
                --message-color: #ffc66d;
                --message-bg: rgba(255, 198, 109, 0.07);
                --message-border: rgba(255, 198, 109, 0.24);
            }

        /* ========================================
   MESSAGE ICON
======================================== */

        .message-icon {
            display: grid;
            place-items: center;
            flex: 0 0 38px;
            width: 38px;
            height: 38px;
            color: var(--message-color);
            background: var(--message-bg);
            border: 1px solid var(--message-border);
            border-radius: 11px;
        }

            .message-icon svg {
                display: none;
                width: 21px;
                height: 21px;
            }

        .form-message.success .icon-success,
        .form-message.error .icon-error,
        .form-message.warning .icon-warning {
            display: block;
        }

        /* ========================================
   MESSAGE CONTENT
======================================== */

        .message-content {
            display: flex;
            flex: 1;
            flex-direction: column;
            gap: 4px;
            min-width: 0;
        }

        .message-title {
            color: var(--message-color);
            font-size: 12px;
            font-weight: 700;
            line-height: 1.5;
        }

        .message-text {
            color: #b4bad0;
            font-size: 11px;
            font-weight: 400;
            line-height: 1.8;
            overflow-wrap: anywhere;
            word-break: normal;
        }

        /* ========================================
   CLOSE BUTTON
======================================== */

        .message-close {
            display: grid;
            place-items: center;
            flex: 0 0 28px;
            width: 28px;
            height: 28px;
            padding: 0;
            color: #8991a9;
            background: transparent;
            border: none;
            border-radius: 8px;
            font-family: inherit;
            font-size: 22px;
            line-height: 1;
            cursor: pointer;
            transition: color 180ms ease, background 180ms ease;
        }

            .message-close:hover {
                color: var(--text, #f4f5fb);
                background: rgba(255, 255, 255, 0.07);
            }

            .message-close:focus-visible {
                outline: 2px solid var(--message-color);
                outline-offset: 3px;
            }

        /* ========================================
   RESPONSIVE
======================================== */

        @media (max-width: 420px) {
            .form-message,
            .form-message.active {
                gap: 9px;
                padding-left: 10px;
                padding-right: 10px;
            }

            .message-icon {
                flex-basis: 33px;
                width: 33px;
                height: 33px;
            }

                .message-icon svg {
                    width: 19px;
                    height: 19px;
                }

            .message-text {
                font-size: 10px;
            }
        }

        /* ========================================
   ACCESSIBILITY
======================================== */

        @media (prefers-reduced-motion: reduce) {
            .form-message,
            .message-close {
                transition: none;
            }

            .form-message {
                transform: none;
            }
        }
    </style>
</head>

<body>

    <div class="form-message success" id="formMessage" role="status" aria-live="polite">
        <span class="message-icon" aria-hidden="true">
            <svg class="icon-success" viewBox="0 0 24 24" fill="none">
                <path d="M5 12.5L9.5 17L19 7" stroke="currentColor"
                    stroke-width="2" stroke-linecap="round" stroke-linejoin="round" />
            </svg>

            <svg class="icon-error" viewBox="0 0 24 24" fill="none">
                <path d="M12 8V13" stroke="currentColor"
                    stroke-width="2" stroke-linecap="round" />
                <circle cx="12" cy="16.5" r="1" fill="currentColor" />
                <circle cx="12" cy="12" r="9" stroke="currentColor" stroke-width="2" />
            </svg>

            <svg class="icon-warning" viewBox="0 0 24 24" fill="none">
                <path d="M12 8V13" stroke="currentColor"
                    stroke-width="2" stroke-linecap="round" />
                <circle cx="12" cy="16.5" r="1" fill="currentColor" />
                <path d="M10.3 4.8L2.8 18A2 2 0 0 0 4.5 21H19.5A2 2 0 0 0 21.2 18L13.7 4.8A2 2 0 0 0 10.3 4.8Z"
                    stroke="currentColor" stroke-width="2" stroke-linejoin="round" />
            </svg>
        </span>

        <span class="message-content">
            <strong class="message-title">Success</strong>
            <span class="message-text">Your account has been created successfully.</span>
        </span>

        <button type="button" class="message-close"
            aria-label="Dismiss message" id="closeMessage">
            &times;</button>
    </div>

    <form id="form1" runat="server">

        <asp:ScriptManager
            ID="ScriptManager1"
            runat="server"
            EnablePageMethods="true" />


        <main class="page">
            <div class="ambient ambient-one"></div>
            <div class="ambient ambient-two"></div>

            <section class="register-card">

                <div class="brand">
                    <div class="brand-icon">T</div>
                    <span>TaskMaster</span>
                </div>

                <header class="heading">
                    <span class="eyebrow">JOIN THE TEAM</span>
                    <h1>Create your account</h1>
                    <p>Enter your details below and become part of our team.</p>
                </header>

                <div class="fields">

                    <div class="field">
                        <label for="txtFirstName">First name</label>
                        <asp:TextBox ID="txtFirstName" runat="server"
                            CssClass="input"
                            placeholder="e.g. Alex"
                            MaxLength="50"
                            autocomplete="given-name" />
                        <asp:RequiredFieldValidator ID="FirstNameValidator" runat="server" ControlToValidate="txtFirstName"
                            ErrorMessage="First name is required." Display="none" />
                    </div>

                    <div class="field">
                        <label for="txtLastName">Last name</label>
                        <asp:TextBox ID="txtLastName" runat="server"
                            CssClass="input"
                            placeholder="e.g. Morgan"
                            MaxLength="70"
                            autocomplete="family-name" />
                    </div>

                    <div class="field full">
                        <label for="txtUsername">Username</label>
                        <div class="input-wrap">
                            <span class="input-icon">@</span>
                            <asp:TextBox ID="txtUsername" runat="server"
                                CssClass="input"
                                placeholder="Choose a username"
                                MaxLength="30"
                                autocomplete="username" />
                        </div>
                        <small class="field-hint">Use letters, numbers, and underscores.
                        </small>
                    </div>

                    <div class="field">
                        <label for="txtPassword">Password</label>
                        <asp:TextBox ID="txtPassword" runat="server"
                            CssClass="input"
                            TextMode="Password"
                            placeholder="Create a password"
                            MaxLength="100"
                            autocomplete="new-password" />
                    </div>

                    <div class="field">
                        <label for="txtConfirmPassword">Confirm password</label>
                        <asp:TextBox ID="txtConfirmPassword" runat="server"
                            CssClass="input"
                            TextMode="Password"
                            placeholder="Repeat your password"
                            MaxLength="100"
                            autocomplete="new-password" />
                    </div>

                    <div class="field">
                        <label for="txtAge">Age</label>
                        <asp:TextBox ID="txtAge" runat="server"
                            CssClass="input age-input"
                            TextMode="Number"
                            placeholder="Enter your age"
                            min="1"
                            max="120"
                            step="1" />
                        <small class="field-hint">Enter your age in years.</small>
                    </div>

                    <div class="field">
                        <label>Gender</label>
                        <asp:HiddenField ID="hfGender" runat="server" Value="" />
                        <div class="gender-options" id="genderOptions" role="group" aria-label="Choose your gender">
                            <button type="button"
                                class="gender-option"
                                data-gender="Male"
                                aria-pressed="false">
                                <span>Male</span>
                                <span class="gender-check">✓</span>
                            </button>

                            <button type="button"
                                class="gender-option"
                                data-gender="Female"
                                aria-pressed="false">
                                <span>Female</span>
                                <span class="gender-check">✓</span>
                            </button>
                        </div>
                    </div>

                </div>

                <section class="role-section">
                    <div class="role-heading">
                        <div>
                            <h2 class="role-title">Choose your role</h2>
                            <p class="role-description">
                                How will you contribute to the team?
                            </p>
                        </div>
                        <span class="role-badge" id="roleBadge">INTERN</span>
                    </div>

                    <asp:HiddenField ID="hfRole" runat="server" Value="Intern" />

                    <div class="role-switch" id="roleSwitch">

                        <button type="button"
                            class="role-option active"
                            data-role="Intern"
                            aria-pressed="true">

                            <span class="role-symbol">✳</span>

                            <span class="role-text">
                                <strong>Intern</strong>
                                <small>Learn &amp; grow</small>
                            </span>

                            <span class="role-check">✓</span>
                        </button>

                        <button type="button"
                            class="role-option"
                            data-role="Designer"
                            aria-pressed="false">

                            <span class="role-symbol">✦</span>

                            <span class="role-text">
                                <strong>Designer</strong>
                                <small>Create &amp; design</small>
                            </span>

                            <span class="role-check">✓</span>
                        </button>

                    </div>
                </section>

                <asp:Button ID="btnRegister"
                    runat="server"
                    Text="Create Account  →"
                    CssClass="submit-button"
                    CausesValidation="false" />

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

    <script>
        (function () {
            const roleSwitch = document.getElementById('roleSwitch');
            const roleBadge = document.getElementById('roleBadge');
            const hiddenRole = document.getElementById('<%= hfRole.ClientID %>');

            roleSwitch.addEventListener('click', function (event) {
                const option = event.target.closest('.role-option');

                if (!option) return;

                const selectedRole = option.dataset.role;

                hiddenRole.value = selectedRole;
                roleBadge.textContent = selectedRole.toUpperCase();

                roleSwitch.querySelectorAll('.role-option').forEach(function (item) {
                    const isActive = item === option;

                    item.classList.toggle('active', isActive);
                    item.setAttribute('aria-pressed', String(isActive));
                });
            });
        })();

        (function () {
            const genderOptions = document.getElementById('genderOptions');
            const hiddenGender = document.getElementById('<%= hfGender.ClientID %>');

            genderOptions.addEventListener('click', function (event) {
                const option = event.target.closest('.gender-option');
                if (!option) return;

                hiddenGender.value = option.dataset.gender;

                genderOptions.querySelectorAll('.gender-option').forEach(function (item) {
                    const isActive = item === option;
                    item.classList.toggle('active', isActive);
                    item.setAttribute('aria-pressed', String(isActive));
                });
            });
        })();
    </script>
    <script src="./Scrypts/scrypt.js" type="module"></script>
</body>
</html>

