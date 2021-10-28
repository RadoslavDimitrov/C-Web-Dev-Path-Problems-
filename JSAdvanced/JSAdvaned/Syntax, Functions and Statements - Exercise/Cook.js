function Cook(numAsStr, op1, op2, op3,op4,op5){
    let num = Number(numAsStr);

    function Chop(num){
        return num / 2;
    }

    function Dice(num){
        return Math.sqrt(num);
    }

    function Spice(num){
        return num + 1;
    }

    function Bake(num){
        return num * 3;
    }

    function Fillet(num){
        return num * 0.8;
    }

    let arr = new Array(op1, op2,op3,op4,op5);

    for (let i = 0; i < arr.length; i++) {
        switch (arr[i]) {
            case 'chop':
                num = Chop(num);
                console.log(num);
            break;
            case 'dice':
                num = Dice(num);
                console.log(num);
            break;
            case 'spice':
                num = Spice(num);
                console.log(num);
            break;
            case 'bake':
                num = Bake(num);
                console.log(num);
            break;
            case 'fillet':
                num = Fillet(num);
                console.log(num);
            break;
        }
    }
}

Cook('9', 'dice', 'spice', 'chop', 'bake', 'fillet');

