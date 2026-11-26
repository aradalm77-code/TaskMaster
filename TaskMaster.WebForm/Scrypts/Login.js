(function () {
    const toggle = document.getElementById('togglePassword');
    const password = document.getElementById(
        '<%= txtPassword.ClientID %>'
    );

    toggle.addEventListener('click', function () {
        const isPassword = password.type === 'password';

        password.type = isPassword ? 'text' : 'password';

        toggle.classList.toggle('visible', isPassword);

        toggle.setAttribute(
            'aria-label',
            isPassword ? 'Hide password' : 'Show password'
        );
    });
})();