import { createRouter } from "../router.js";
const views = {
    '#home': () => '<h2>Home Page</h2><p>Welcome to our site!</p>',
    '#catalog': () => '<h2>Catalog Page</h2><ul><li>1</li><li>2</li></ul>',
    '#about': () => '<h2>About Page</h2><p>Contact us: +55-55-55</p>'

}
const main = document.querySelector('main');
const start = createRouter(main, views); 
//To start with a page
start();