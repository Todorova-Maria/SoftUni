import { html, render } from 'https://unpkg.com/lit-html?module';
import { data, nav } from './data.js'

const articleTemplate = (article) => html`
<article class=${article.class}>
<h2>${article.title}</h2>
<button @click= ${() => alert('clicked!')}>Click me</button>
<div class="content">
    <p>
            ${article.content}
    </p>
</div>
<footer>Author: ${article.author}</footer>
</article>`;




start()
async function start() {
    const main = document.querySelector('main');
    const articles = data.map(articleTemplate, main);

   render(articles, main); 
   
}


