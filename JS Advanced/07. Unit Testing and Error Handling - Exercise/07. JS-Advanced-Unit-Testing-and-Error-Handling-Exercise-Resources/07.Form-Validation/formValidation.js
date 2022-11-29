function validate() {
    const userRegex = /^[A-Za-z0-9]{3,20}$/;
    const passRegex = /^[\w]{5,15}$/;
    const emailRegex = /^.*@.*\.*$/;

    let submitBtn = document.getElementById('submit');
    submitBtn.addEventListener('click', validateFormHandler);
    let companyCheckbox = document.getElementById('company');
    companyCheckbox.addEventListener('change', companyHandler);

    function validateFormHandler(e) {
        e.preventDefault();

        let username = document.getElementById('username');
        let isUsernameValid = userRegex.test(username.value);
        setBorder(username, isUsernameValid);

        let password = document.getElementById('password');
        let confirmPassword = document.getElementById('confirm-password');
        let isPasswordValid = passRegex.test(password.value);
        let isPasswordsAreOk = isPasswordValid && password.value === confirmPassword.value;
        setBorder(password, isPasswordsAreOk);
        setBorder(confirmPassword, isPasswordsAreOk);

        let email = document.getElementById('email');
        let isEmailValid = emailRegex.test(email.value);
        setBorder(email, isEmailValid);

        let isCompanyCorrect = false;
        let checkBox = document.getElementById('company');

        if (checkBox.checked) {
            let companyNumberInput = document.getElementById('companyNumber');
            if (companyNumberInput.value.trim() !== '' && !isNaN(Number(companyNumberInput.value))) {
                    let companyNumber = Number(companyNumberInput.value); 
                    if(companyNumber >= 1000 && companyNumber <= 9999) {
                        isCompanyCorrect = true; 
                    }
            } 
            setBorder(companyNumberInput, isCompanyCorrect); 
        }
        let validDiv = document.getElementById('valid'); 
        let mainInputsValidator = isEmailValid && isPasswordsAreOk && isUsernameValid; 
        let companyValidator = !checkBox.checked || (checkBox.checked && isCompanyCorrect);
        let allValidators = mainInputsValidator && companyValidator; 
        
            validDiv.style.display = allValidators ? 'block' : 'none';  
       


    }
    function companyHandler(element) {
        let companyInfo = document.getElementById('companyInfo');
        companyInfo.style.display = element.target.checked ? 'block' : 'none'
    }

    function setBorder(element, isValid) {
        if (isValid) {
            element.style.setProperty('border', 'none');
        } else {
            element.style.setProperty('border', '2px solid red');
        }
    }
}
