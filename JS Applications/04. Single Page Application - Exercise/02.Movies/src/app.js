import { showView, updateNav } from "./router.js";
import { homePage } from "./home.js";
import {loginPage} from "./login.js"; 
import { registerPage } from "./register.js"
import {createPage} from "./create.js"

const routes = {
'/': homePage, 
'/login': loginPage,
'/register': registerPage,
'/logout': logoutPage,
'/create': createPage,
};

document.querySelector('nav').addEventListener('click', onNavigate);
document.querySelector('#add-movie-button a').addEventListener('click', onNavigate); 

function onNavigate(event) {
    if(event.target.tagName == 'A' && event.target.href) {
        event.preventDefault(); 
        const url = new URL(event.target.href);
        
        const view = routes[url.pathname]; 

        
        if(typeof view == 'function') {
            view(); 
        }

    }   
};

function logoutPage() {
    localStorage.removeItem('user'); 
    updateNav();
}

//Start application with home page 
updateNav();
homePage();

