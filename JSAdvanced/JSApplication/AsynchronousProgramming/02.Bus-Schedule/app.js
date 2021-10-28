function solve() {

    let initialBusStop = 'depot';
    const baseUrl = 'http://localhost:3030/jsonstore/bus/schedule/';
    const infoSpan = document.querySelector('.info');

    const departBtn = document.getElementById("depart");
    const arriveBtn = document.getElementById("arrive");

    function depart() {
        if(infoSpan.getAttribute('data-next-stop-id') != undefined){
            initialBusStop = infoSpan.getAttribute('data-next-stop-id');
        }

        fetch(`${baseUrl}${initialBusStop}`)
            .then(body => body.json())
            .then(nextStop => {
                infoSpan.textContent = `Next stop ${nextStop.name}`;
                departBtn.disabled = true;
                arriveBtn.disabled = false;

                infoSpan.setAttribute('data-stop-name', nextStop.name);
                infoSpan.setAttribute('data-next-stop-id', nextStop.next);
            })

            .catch(err => {
                infoSpan.textContent = `Error`;
            })
    }

    function arrive() {
        let stopName = infoSpan.getAttribute('data-stop-name');
        let nextStopId = infoSpan.getAttribute('data-next-stop-id');

        infoSpan.textContent = `Arriving at ${stopName}`;

        arriveBtn.disabled = true;
        departBtn.disabled = false;

    }

    return {
        depart,
        arrive
    };
}

let result = solve();