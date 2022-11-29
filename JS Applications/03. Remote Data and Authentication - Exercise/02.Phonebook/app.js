const url = 'http://localhost:3030/jsonstore/phonebook';

const ulElement = document.getElementById('phonebook');


function attachEvents() {
    let loadBtn = document.getElementById('btnLoad').addEventListener('click', onClickLoad);
    let createBtn = document.getElementById('btnCreate').addEventListener('click', onClickCreate);
}

async function onClickLoad() {
    ulElement.innerHTML = '';

    const res = await fetch(url);
    const data = await res.json();
 
        //Create li 
    Object.values(data).forEach(row => {
        const { person, phone, _id } = row;
        const li = createElement('li', `${person}: ${phone}`, ulElement);
        li.setAttribute('id', _id)
 
         // Create Delete Button
        const deleteBtn = createElement('button', 'Delete', li);
        deleteBtn.setAttribute('id', 'btnDelete');
        deleteBtn.addEventListener('click', onClickDelete);

    })
}

function createElement(type, text, appender) {
    let element = document.createElement(type);
    element.textContent = text;

    appender.appendChild(element);

    return element;

}

async function onClickCreate() {
    const personInput = document.getElementById('person');
    const phoneInput = document.getElementById('phone');
    const person = personInput.value;
    const phone = phoneInput.value;
    const contact = { person, phone };

    if (person.value !== '' || phone.value !== '') {
        const result = await request(url, contact);
    }

}

async function request(url, contact) {

    const res = fetch(url, {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(contact)
    });

    const data = await res.json();
    return data;


}

async function onClickDelete(e) {
    let id = e.target.parentNode.id;
    e.target.parentNode.remove();

    const deleteResponse = await fetch(`http://localhost:3030/jsonstore/phonebook/${id}`, {
        method: 'DELETE'
    });
}

attachEvents();