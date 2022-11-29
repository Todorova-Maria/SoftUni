import  page from './node_modules/page/page.mjs';
import { showAbout } from './views/about.js';
import { showCatalog } from './views/catalog.js';
import { showHome } from './views/home.js';

const main = document.querySelector('main');

page('/', showHome);
page('/catalog', showCatalog);
page('/about', showAbout);

page.start(); 