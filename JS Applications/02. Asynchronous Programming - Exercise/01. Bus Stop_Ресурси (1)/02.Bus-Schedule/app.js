function solve() {

    const labelElement = document.querySelector('#info span');
    const departButton = document.getElementById('depart');
    const arriveButton = document.getElementById('arrive');

    let stop = {
        next: 'depot'
    };


    async function depart() {

        departButton.disabled = true; 
        const url = `http://localhost:3030/jsonstore/bus/schedule/${stop.next}`;
        const res = await fetch(url);

        stop = await res.json();
        labelElement.textContent = `Next stop ${stop.name}`

        arriveButton.disabled = false; 
    }

    function arrive() {
        departButton.disabled = false; 
        labelElement.textContent = `Arriving at ${stop.name}`
        
        arriveButton.disabled = true; 

    }

    return {
        depart,
        arrive
    };
}

let result = solve();