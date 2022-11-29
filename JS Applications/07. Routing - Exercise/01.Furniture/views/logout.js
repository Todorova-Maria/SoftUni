import { updateInfo } from '../app.js';
import page from '//unpkg.com/page/page.mjs';

const url = 'http://localhost:3030/users/logout'; 

export async function logout() {
    const res = await fetch(url);

    localStorage.clear();
    updateInfo(); 
    page.redirect('/catalog');
}

