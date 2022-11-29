 const url = 'http://localhost:3030/jsonstore/messenger'; 
 const messages = document.getElementById('messages');
 
 function attachEvents() {
   document.getElementById('submit').addEventListener('click', postMessage); 
   document.getElementById('refresh').addEventListener('click', loadAllMessages);
}
 
async function loadAllMessages() { 
    const res = await fetch(url); 
    const data = await res.json(); 
   messages.value = Object.values(data).map(({author, content}) => `${author}: ${content}`).join('\n');
}

async function postMessage() {
    const nameElement = document.querySelector('[name="author"]');
    const messageElement = document.querySelector('[name="content"]');
    if(nameElement.value !== '' || messageElement.value !== ''){
        await request(url, {author: nameElement.value, content: messageElement.value}); 
        nameElement.value = '';
        messageElement.value = ''; 
    } 
}

async function request(url, option) {
    if(option) {
        option = {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(option)
        };
    }
    let res = await fetch(url, option); 
    let data = await res.json();

    return data; 
}
attachEvents();