import { updateInfo } from '../app.js';
import { html, render } from 'https://unpkg.com/lit-html?module';
import page from '//unpkg.com/page/page.mjs';

const url = 'http://localhost:3030/users/register';

const registerTemplate = () => html`
<div class="row space-top">
            <div class="col-md-12">
                <h1>Register New User</h1>
                <p>Please fill all fields.</p>
            </div>
        </div>
        <form @submit=${onSubmit}>
            <div class="row space-top">
                <div class="col-md-4">
                    <div class="form-group">
                        <label class="form-control-label" for="email">Email</label>
                        <input class="form-control" id="email" type="text" name="email">
                    </div>
                    <div class="form-group">
                        <label class="form-control-label" for="password">Password</label>
                        <input class="form-control" id="password" type="password" name="password">
                    </div>
                    <div class="form-group">
                        <label class="form-control-label" for="rePass">Repeat</label>
                        <input class="form-control" id="rePass" type="password" name="rePass">
                    </div>
                    <input type="submit" class="btn btn-primary" value="Register" />
                </div>
            </div>
        </form>
`

function onSubmit(event) {
    event.preventDefault();
    const formData = new FormData(event.currentTarget);
    const email = formData.get('email').trim();
    const password = formData.get('password').trim();
    const rePass = formData.get('rePass').trim(); 

    if(password != rePass) {
        alert('Passwords don`t match!')
        return;
    }

    fetch(url, {
        method: 'POST',
        body: JSON.stringify({ email, password })
    })
        .then(res => {
            if (!res.ok) {
                throw new Error('Invalid email/password!')
            }
            return res.json()
        })
        .then(data => {
            localStorage.setItem('token', data.accessToken)
            localStorage.setItem('ownerId', data._id)
            updateInfo()
            page.redirect('/catalog')
        })
        .catch(error => alert(error.message))
}    
const root = document.querySelector('.container');

export function registerView(ctx) {
    render(registerTemplate(), root);
}