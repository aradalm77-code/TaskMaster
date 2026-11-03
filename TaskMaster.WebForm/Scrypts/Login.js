
import { loginForm, loginPasswordInput, loginUsernameInput } from './elements.js';
import { RenderMessage } from './RenderMessage.js';

const Login = (e) => {
    e.preventDefault();

    const username = loginUsernameInput.value;
    const password = loginPasswordInput.value;

    PageMethods.UserLogin(
        username,
        password,
        function (user) {
            localStorage.setItem("name", JSON.stringify(user));
            user.Role == 0 ? window.location.href = "DesignerMenu.aspx" : window.location.href = "InternMenu.aspx";
        },
        function (error) {
            RenderMessage(
                "error",
                "Something went wrong!",
                error.get_message()
            );
        }
    );
};

loginForm?.addEventListener("submit", Login);
