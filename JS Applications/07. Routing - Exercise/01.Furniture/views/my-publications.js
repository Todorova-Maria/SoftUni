import { html, render } from 'https://unpkg.com/lit-html?module';
import page from '//unpkg.com/page/page.mjs';

const myPublicationsTemplate = (catalog) => html`
<div class="row space-top">
            <div class="col-md-12">
                <h1>My Furniture</h1>
                <p>This is a list of your publications.</p>
            </div>
        </div>
        <div class="row space-top">
        ${catalog.map(c => html`
        <div class="col-md-4">
            <div class="card text-white bg-primary">
                <div class="card-body">
                        <img src="${"01.Furniture/" + c.img}" />
                        <p>${c.description}</p>
                        <footer>
                            <p>Price: <span>${c.price} $</span></p>
                        </footer>
                        <div>
                            <a href="/details/${c._id}" class="btn btn-info">Details</a>
                        </div>
                </div>
            </div>
        </div>
        `)}
    </div>
        `

const url = 'http://localhost:3030/data/catalog';
async function getMyPublications() {
    const res = await fetch(url);
    const data = await res.json();

    return Object.values(data.filter(x => x._ownerId == localStorage.ownerId));
}

const root = document.querySelector('.container');
export function myPublicationsView() {
    getMyPublications()
    .then(catalog => render(myPublicationsTemplate(catalog), root));

}