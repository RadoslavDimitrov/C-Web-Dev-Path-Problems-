function Time(steps, lenghtM, speedKm){
    //every 500m => 1 minute break
    //4000, 0.60, 5

    const speedM = speedKm * (5/18);
    const totalDistance = steps * lenghtM;
    let secondsNeeded = totalDistance / speedM;

    let brakes = Math.floor(totalDistance / 500);

    if(totalDistance <= 500){
        brakes = 0;
    }
    let minutes = Math.floor(secondsNeeded / 60);

    let secondsLeft = secondsNeeded % 60;

    if((totalDistance % 500) == 0){
        brakes-=1;
    }

    let totalMinutes = minutes + brakes;

    let hours = 0;

    if(totalMinutes > 60){
        hours = Math.floor(totalMinutes / 60);
        totalMinutes = totalMinutes % 60;
    }

    const padded = (hours).toString().padStart(2, '0')

    if(secondsNeeded < 1){
        console.log(`00:00:01`);
    }
    else{
        console.log(`${padded}:${Math.round(totalMinutes)}:${Math.round(secondsLeft)}`);

    }
}

Time(1, 1, 5);