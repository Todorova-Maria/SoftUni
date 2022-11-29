import { get } from "./api.js";
import { render } from "./dom.js";

const section = document.getElementById('catalogView');
const list = section.querySelector('ul');
section.remove();

let ctx = null;
export async function showCatalog(inCtx) {
    ctx = inCtx;
    ctx.render(section);

    list.replaceChildren('Loading...');

    // Get all movies from server
    const movies = await get('/data/movies');

    const fragment = document.createDocumentFragment();

    movies.map(createMovieItem).forEach(c => fragment.appendChild(c));

    list.replaceChildren(fragment);
}

function createMovieItem(movie) {
    const li = document.createElement('li');
    li.textContent = movie.title;

    return li;
}