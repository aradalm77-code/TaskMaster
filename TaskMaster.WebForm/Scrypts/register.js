import {
    FirstNameInput,
    LastNameInput,
    UsernameInput,
    PasswordInput,
    ConfirmPassword,
    RoleSelectors,
    SignUpForm
} from './elements.js';
import {RenderMessage} from './RenderMessage.js';
const Register = (e) => {
    e.preventDefault();
    if (FirstNameInput.value.length < 1) {
        RenderMessage('error',
            'Invalid Username',
            'please enter a valid firstname');
        return;
    }
    if (LastNameInput.value.length < 1) {
        RenderMessage('error',
            'Invalid Username',
            'please enter a valid lastname');
        return;
    }
    const username = UsernameInput.value;

    const isUsernameValid = /[a-z]/.test(username) && username.length > 1;
    if (!isUsernameValid) {
        RenderMessage('error',
            'Invalid Username',
            'please enter a valid Username');
        return;
    }
    const password = PasswordInput.value;

        const isPasswordValid =
            /[A-Z]/.test(password) &&
            /[a-z]/.test(password) &&
            /@/.test(password) &&
            /^[a-zA-Z0-9@]+$/.test(password) &&
            password.length >= 8;
        if (!isPasswordValid) {
            RenderMessage('error',
                'Invalid Password',
                'Password must have upercase and lowercase and @ and at least 8 character ');
            return;
        }
    if (password !== ConfirmPassword.value) {
        RenderMessage('error',
            'Passwords do not match',
            'please confirm your password correctly');
        return;
    }
    const selectedRole = [...RoleSelectors].find(role =>
        role.classList.contains('active')
    );

    const role = selectedRole?.getAttribute('data-role');

    PageMethods.Register(
        FirstNameInput.value,
        LastNameInput.value,
        username,
        password,
        role,
        function (registeredUser) {
            if (!registeredUser) {
                RenderMessage('error', 'Registration failed', 'The server returned no data.');
                return;
            }

            localStorage.setItem("name", JSON.stringify(registeredUser));

            window.location.href = "Users.aspx";
        },
        function (error) {
            RenderMessage('error', 'something went wrong', `${error.get_message() }`);
        }
    );
}

if (SignUpForm != null) SignUpForm?.addEventListener('submit', Register);