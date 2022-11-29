import { html, render } from 'https://unpkg.com/lit-html?module';
import page from '//unpkg.com/page/page.mjs';
import { loginView } from './views/login.js';
import {catalogView} from './views/catalog.js'
import {registerView} from './views/register.js'
import { logout } from './views/logout.js';
import { createView } from './views/create.js';
import { myPublicationsView } from './views/my-publications.js';
import { detailsView } from './views/details.js';

page('/login', loginView)
page('/catalog', catalogView)
page('/register', registerView)
page('/create', createView)
page('/my-publications', myPublicationsView)
page('/details', detailsView)

document.getElementById('logoutBtn').addEventListener('click', logout);

export const updateInfo = () => {
    const userDiv = document.getElementById('user');
    const guestDiv = document.getElementById('guest');

    if(localStorage.length == 0) {
        userDiv.style.display = 'none';
        guestDiv.style.display = 'inline';
    } else { 
        userDiv.style.display = 'inline';
        guestDiv.style.display = 'none';
    }
}
updateInfo(); 

page.start(); 