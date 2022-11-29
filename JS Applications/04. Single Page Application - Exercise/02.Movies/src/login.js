import { homePage } from './home.js';
import {showView, updateNav} from './router.js'

const section = document.querySelector('#form-login'); 
const form = section.querySelector('form'); 
form.addEventListener('submit', onSubmit); 

export function loginPage() {
    showView(section); 
}

async function onSubmit(event){
    event.preventDefault(); 

    const formData = new FormData(form); 

    const email = formData.get('email');
    const password = formData.get('password'); 

    await login(email, password);  
    updateNav();
    homePage(); 
}

async function login(email, password) {
    try {
        const res = await fetch('http://localhost:3030/users/login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({email, password})
        });
        if(!res.ok) {
            const err = await res.json(); 
            throw new Error(err.message); 
        }

        const user = await res.json(); 
        localStorage.setItem('user', JSON.stringify(user)); 
    } catch (err) {
        alert(err.message); 
        throw err;
    }

}



