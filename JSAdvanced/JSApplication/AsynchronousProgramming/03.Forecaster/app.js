function attachEvents() {
    const submitBtn = document.getElementById("submit");
    submitBtn.addEventListener('click', getForecast);
    const baseUrl = `http://localhost:3030/jsonstore/forecaster/locations`;
    const currConditionsBaseUrl = `http://localhost:3030/jsonstore/forecaster/today/`; // + code
    const threeDaysBaseUrl = `http://localhost:3030/jsonstore/forecaster/upcoming/`; // + code
    
    function getForecast(ev){
        ev.preventDefault();
        const userLocationInput = document.getElementById("location");
        const userLocation = userLocationInput.value;

        const forecastDiv = document.getElementById("forecast");
        const currentDiv = document.getElementById("current");
        const upcomingDiv = document.getElementById("upcoming");

        let toDelete = document.querySelectorAll('.forecasts').forEach(el => el.remove());
        let toDeleteUpcoming = document.querySelectorAll('.forecast-info').forEach(el => el.remove());

        const conditions = {
            'Sunny': '☀',
            'Partly sunny': '⛅',
            'Overcast': '☁',
            'Rain': '☂'
        }

        let forecast = fetch(baseUrl)
            .then(body => body.json())
            .then(forecastLocation => {
                let currLocation = {};

                for (let currLocationIndex = 0; currLocationIndex < forecastLocation.length; currLocationIndex++) {
                    if(forecastLocation[currLocationIndex].name == userLocation){
                        currLocation.name = forecastLocation[currLocationIndex].name,
                        currLocation.code = forecastLocation[currLocationIndex].code
                    }
                }

                if(currLocation.name == undefined){
                    throw Error('no such location');
                }

                fetch(`${currConditionsBaseUrl}${currLocation.code}`)
                    .then(body => body.json())
                    .then(cityForecast => {

                        const forecastDivElement = e('div', {className: 'forecasts'}, 
                            e('span', {className: 'condition symbol'}, `${conditions[cityForecast.forecast.condition]}`),
                            e('span', {className: 'condition'}, 
                                e('span', {className: 'forecast-data'}, `${cityForecast.name}`),
                                e('span', {className: 'forecast-data'}, `${cityForecast.forecast.low}°/${cityForecast.forecast.high}°`),
                                e('span',{className: 'forecast-data'}, `${cityForecast.forecast.condition}`))
                        );

                        currentDiv.appendChild(forecastDivElement);
                        console.log(forecastDivElement);

                        forecastDiv.style.display = 'block';
                    });

                fetch(`${threeDaysBaseUrl}${currLocation.code}`)
                    .then(body => body.json())
                    .then(upcomingForecast => {

                        const upcomingDivEl = e('div', {className: 'forecast-info'}, 
                            e('span', {className: 'upcoming'}, 
                                e('span', {className: 'symbol'}, `${conditions[upcomingForecast.forecast[0].condition]}`),
                                e('span', {className: 'forecast-data'}, `${upcomingForecast.forecast[0].low}°/${upcomingForecast.forecast[0].high}°`),
                                e('span', {className: 'forecast-data'}, `${upcomingForecast.forecast[0].condition}`)
                                ),
                            e('span', {className: 'upcoming'}, 
                                e('span', {className: 'symbol'}, `${conditions[upcomingForecast.forecast[1].condition]}`),
                                e('span', {className: 'forecast-data'}, `${upcomingForecast.forecast[1].low}°/${upcomingForecast.forecast[1].high}°`),
                                e('span', {className: 'forecast-data'}, `${upcomingForecast.forecast[1].condition}`)
                                ),
                            e('span', {className: 'upcoming'}, 
                                e('span', {className: 'symbol'}, `${conditions[upcomingForecast.forecast[2].condition]}`),
                                e('span', {className: 'forecast-data'}, `${upcomingForecast.forecast[2].low}°/${upcomingForecast.forecast[2].high}°`),
                                e('span', {className: 'forecast-data'}, `${upcomingForecast.forecast[2].condition}`)
                                )
                            );
                                
                        upcomingDiv.appendChild(upcomingDivEl);
                                
                    })
            })
            .catch(err => {
                currentDiv.appendChild(e('div', {}, `Error`));
            });

        
        
    };

    function e(type, attr, ...content){
        const element = document.createElement(type);

        for (const prop in attr) {
            element[prop] = attr[prop];
        }

        for (let item of content) {
            if(typeof item == 'string' || typeof item == 'number'){
                item = document.createTextNode(item);
            }
            element.appendChild(item);
        }

        return element;
    }
}

attachEvents();