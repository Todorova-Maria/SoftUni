import { html, render } from '../node_modules/lit-html/lit-html.js'

const url = 'http://localhost:3030/jsonstore/advanced/dropdown'
const root = document.getElementById('menu');

const htmlText = (towns) => html`  
 ${towns.map(town => html`<option value=${town._id}>${town.text}</option>`)}` 

getData();

//GET QUERY TO SERVER
async function getData() {
    const response = await fetch(url);
    const data = await response.json();

    update(Object.values(data));
}

// RENDER RESULT TO ROOT
async function update(data) {
    const result = htmlText(data);
    render(result, root);
}


// POST QUERY TO SERVER 
document.querySelector('form').addEventListener('submit', addItem)
async function addItem(e) {
    e.preventDefault();
    const text = document.getElementById('itemText').value;

    const item = {
        text
    };

    const res = await fetch(url, {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    }); 
    
    if (res.ok) {
        document.getElementById('itemText').value = '';
        getData();
    }
}
