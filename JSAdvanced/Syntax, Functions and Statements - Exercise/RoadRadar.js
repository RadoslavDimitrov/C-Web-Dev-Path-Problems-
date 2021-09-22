// •	On the motorway the limit is 130 km/h
// •	On the interstate the limit is 90 km/h
// •	In the city the limit is 50 km/h 
// •	Within a residential area the limit is 20 km/h

function speedValidation(speed, area){
    let speedNum = +speed;
    let overSpeed = 0;
    let speedLimit = 0;
    let currArea = '';
    let status = '';

    switch (area) {
        case 'motorway' :
            speedLimit = 130;     
            currArea = 'motorway';       
        break;
        case 'interstate':                
            speedLimit = 90;
            currArea = 'interstate';
        break;
        case 'city':
            speedLimit = 50;
            currArea = 'city';
        break;
        case 'residential':
            speedLimit = 20;
            currArea = 'residential';
        break;
    }

    if(speedNum <= speedLimit){
        console.log(`Driving ${speed} km/h in a ${speedLimit} zone`)
    }
    else{
        overSpeed = speedNum - speedLimit;

        if(overSpeed <= 20){
            status = 'speeding';
        }
        else if(overSpeed <= 40){
            status = 'excessive speeding';
        }
        else{
            status = 'reckless driving';
        }

        console.log(`The speed is ${overSpeed} km/h faster than the allowed speed of ${speedLimit} - ${status}`);
    }
}

speedValidation(40, 'city');
speedValidation(21, 'residential');
speedValidation(120, 'interstate');
speedValidation(200, 'motorway');

