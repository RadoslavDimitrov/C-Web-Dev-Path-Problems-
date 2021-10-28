function getInfo() {
    const stopId = document.getElementById("stopId");
    const resultInfo = document.getElementById("buses");
    const stopNameDiv = document.getElementById("stopName");

    resultInfo.textContent = '';

    const baseUrl = "http://localhost:3030/jsonstore/bus/businfo/";

    fetch(`${baseUrl}${stopId.value}`)
        .then(body => body.json())
        .then(stopInfo => {
            stopNameDiv.textContent = stopInfo.name;

            let keys = Object.keys(stopInfo.buses);

            for (const key of keys) {
                const currBus = document.createElement("li");
                currBus.textContent = `Bus ${key} arrives in ${stopInfo.buses[key]} minutes`;
                resultInfo.appendChild(currBus);
                stopId.value = '';
            }
        })
        .catch(err => {
            stopNameDiv.textContent = `Error`;
            stopId.value = '';
        });
}