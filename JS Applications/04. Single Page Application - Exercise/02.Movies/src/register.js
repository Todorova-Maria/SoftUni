import { homePage } from './home.js';
import { loginPage } from './login.js';
import { showView, updateNav } from './router.js'

const section = document.querySelector('#form-sign-up');
const form = section.querySelector('form');
form.addEventListener('submit', registration);


export function registerPage() {
    showView(section);
}

async function registration(event) {
    event.preventDefault();

    const formData = new FormData(form);

    const email = formData.get('email').trim();
    const password = formData.get('password').trim();
    const repeatPassword = formData.get('repeatPassword').trim();

    if (email == '' || password == '' || repeatPassword == '') {
        return alert('All fields are required!');
    }  
    else if (password.length < 6) { 
        return alert('The password should be at least 6 characters long');
    }
    else if(password != repeatPassword) { 
        return alert('Password do not match!');
    }  

    try { 
        const response = await fetch('http://localhost:3030/users/register', { 
            method: 'POST', 
            headers: { 
                'Content-Type' : 'application/json'
            }, 
            body: JSON.stringify({email,password})
        });  
         
        if(response.ok == false) { 
            const error = await response.json(); 
            throw new Error(error.message);
        } 

        const user = await response.json(); 
        localStorage.setItem('user', JSON.stringify(user)); 

        form.reset(); 
        updateNav(); 
        homePage();
    } 
    catch (error) { 
        alert(error.message);
    }
}
