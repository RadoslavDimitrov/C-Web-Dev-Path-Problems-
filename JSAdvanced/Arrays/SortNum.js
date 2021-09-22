/**
 * 
 * @param {[Array]} arr 
 */
function Sort(arr){
    arr = arr.sort((a,b) => {
        return a-b
    });

    let result = [];

    while (arr.length) {
        result.push(arr.shift(), arr.pop());
    }
    return result;
}

Sort([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]);