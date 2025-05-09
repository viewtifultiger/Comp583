window.submitLoginForm = (email, password) => {
    const form = document.createElement('form');
    form.method = 'POST';
    form.action = '/LoginHandler';

    const emailInput = document.createElement('input');
    emailInput.type = 'hidden';
    emailInput.name = 'Email';
    emailInput.value = email;

    const passwordInput = document.createElement('input');
    passwordInput.type = 'hidden';
    passwordInput.name = 'Password';
    passwordInput.value = password;

    form.appendChild(emailInput);
    form.appendChild(passwordInput);
    document.body.appendChild(form);
    form.submit();
};