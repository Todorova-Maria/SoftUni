import { html, render } from "../node_modules/lit-html/lit-html.js";

const homeTemplate = () => html`
<h2>Home Page</h2>
<p>Welcome to our page!</p>`;

const main = document.querySelector('main');

export function showHome() {
    render(homeTemplate(), main); 
}


