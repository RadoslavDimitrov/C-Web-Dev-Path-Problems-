function AddRemove(arr){
    let initialNum = 1;
    let result = [];

    for (let index = 0; index < arr.length; index++) {
        
        if(arr[index] == 'add'){
            result.push(initialNum);
        }
        else{
            result.pop();
        }
        
        initialNum++;
    }

    if(result.length){
        console.log(result.join('\n'))
    }
    else{
        console.log('Empty')
    }
}