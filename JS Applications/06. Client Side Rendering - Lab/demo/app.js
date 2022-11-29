import { data, nav as links } from './data.js';
import { createTemplate } from './engine.js';


start();
async function start() {
    const main = document.querySelector('main');
    const nav = document.querySelector('nav ul');

    const articleTemplateAsString = await (await fetch('./templates/article.html')).text();
    const articleTemplate = createTemplate(articleTemplateAsString); 

    const navTepmlateAsString = await (await fetch('./templates/nav.html')).text(); 
    const navTemplate = createTemplate(navTepmlateAsString); 

    main.innerHTML = data.map(articleTemplate).join('');
    nav.innerHTML = links.map(navTemplate).join(''); 
   
}