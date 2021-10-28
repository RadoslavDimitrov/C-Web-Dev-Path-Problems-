function PointValidator(x1, y1, x2, y2){
    let validZ1 = false;

    let z1 = Math.sqrt(Math.pow(x1, 2) + Math.pow(y1, 2));

    let z1Rounded = Math.round(z1);

    if(z1Rounded == z1){
        validZ1 = true;
    }

    console.log(`{${x1}, ${y1}} to {0, 0} is ${validZ1 == true ? 'valid' : 'invalid'}`)

    let validZ2 = false;
    let z2 = Math.sqrt(Math.pow(x2, 2) + Math.pow(y2, 2));
    let z2Rounded = Math.round(z2);

    if(z2Rounded == z2){
        validZ2 = true;
    }

    console.log(`{${x2}, ${y2}} to {0, 0} is ${validZ2 == true ? 'valid' : 'invalid'}`)

    let validZ3 = false;
    let z3 = Math.sqrt(Math.pow(Math.max(x1 - x2), 2) + Math.pow(Math.max(y1 - y2), 2));
    let z3Rounded = Math.round(z3);

    if(z3Rounded == z3){
        validZ3 = true;
    }

    console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is ${validZ3 == true ? 'valid' : 'invalid'}`)
}

PointValidator(3,0,0,4);
