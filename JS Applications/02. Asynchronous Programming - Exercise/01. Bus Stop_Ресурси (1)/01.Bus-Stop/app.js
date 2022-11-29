async function getInfo() {
    const busStopElement = document.getElementById('stopName');
    const busesElement = document.getElementById('buses');

    const stopId = document.getElementById('stopId').value;

    const url = `http://localhost:3030/jsonstore/bus/businfo/${stopId}`;

    try {

        busesElement.replaceChildren();
        const res = await fetch(url);

        if (res.status !== 200) {
            throw new Error('Stop ID is not found!')
        }

        const data = await res.json();
        busStopElement.textContent = data.name;

        Object.entries(data.buses).forEach(b => {
            let liElement = document.createElement('li');
            liElement.textContent = `Bus ${b[0]} arrives in ${b[1]} minutes`
            busesElement.appendChild(liElement);
        })

    } catch (err) {
        busStopElement.textContent = 'Error'
    }
}