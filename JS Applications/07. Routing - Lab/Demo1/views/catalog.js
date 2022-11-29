import { html, render } from "../node_modules/lit-html/lit-html.js";

const catalogTemplate = () => html `
<h2>Catalog Page</h2>
<ul>
    <li>1</li>
    <li>2</li>
</ul>
`
const main = document.querySelector('main');

export function showCatalog() {
    render(catalogTemplate(), main);
}