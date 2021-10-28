/**
 * 
 * @param {[Array]} arr 
 * @param {*} rotations 
 */
function Rotate(arr, rotations){
    for (let index = 0; index < rotations; index++) {
        arr.unshift(arr.pop())
        
    }

    console.log(arr.join(' '));
}

Rotate(['Banana', 
'Orange', 
'Coconut', 
'Apple'], 
15
);