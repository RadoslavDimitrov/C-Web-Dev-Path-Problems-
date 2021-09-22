function Extract(arr){
    let higherst = Number.MIN_SAFE_INTEGER;
    let result = arr.filter((el) => {
        if(el >= higherst){
            higherst = el;
            return true;
        }

        return false;
    })

    return result;
}

console.log(Extract([1, 
    3, 
    8, 
    4, 
    10, 
    12, 
    3, 
    2, 
    24]
    ));