import page from '//unpkg.com/page/page.mjs';
import { html, render } from 'https://unpkg.com/lit-html?module';

const detailsTemplate = (detail) => html `
<div class="row space-top">
<div class="col-md-12">
    <h1>Furniture Details</h1>
</div>
</div>
<div class="row space-top">
            <div class="col-md-4">
                <div class="card text-white bg-primary">
                    <div class="card-body">
                        <img src=${"../01.Furniture/"  + detail.img} />
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <p>Make: <span>${detail.make}</span></p>
                <p>Model: <span>${detail.model}</span></p>
                <p>Year: <span>${detail.year}</span></p>
                <p>Description: <span>${detail.description}</span></p>
                <p>Price: <span>${detail.price}</span></p>
                <p>Material: <span>${detail.material}</span></p>
                <div>
                    <a href="/edit/${detail._id}" class="btn btn-info" style="display: ${detail._ownerId == localStorage.ownerId ? 'inline' : 'none'}">Edit</a>
                </div>
            </div>
        </div>
`

function getDetails(detailsId) {
    const url = `http://localhost:3030/data/catalog/${detailsId}`;
    return fetch(url)
    .then(res => res.json())
}

const root = document.querySelector('.container')

export function detailsView(ctx) {
    getDetails(ctx.params.detailsId)
    .then(detail => render(detailsTemplate(detail), root));

}