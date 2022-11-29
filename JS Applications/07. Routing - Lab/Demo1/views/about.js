import { html, render } from "../node_modules/lit-html/lit-html.js"; 

const aboutTemplate = () => html `<h2>About Page</h2><p>Contact us: +55-55-55</p>`;

const main = document.querySelector('main');

export function showAbout() {
    render(aboutTemplate(), main);
}