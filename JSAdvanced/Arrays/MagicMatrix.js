
function Magic(arr){
    let firstRow = arr[0];
    let result = 0;
    let isValid = true;


    for (let index = 0; index < firstRow.length; index++) {
        result+=firstRow[index];
    }

    while (isValid) {
        for (let row = 0; row < arr.length; row++) {
            let currSum = 0;
            for (let col = 0; col < arr[row].length; col++) {
                currSum+=arr[row][col];
                
            }

            if(currSum != result){
                isValid = false;
                break;
            }
        }

        for (let col = 0; col < arr[0].length; col++) {
            let currColSum = 0;
            for (let row = 0; row < arr.length; row++) {
                currColSum+=arr[row][col];
            }

            if(currColSum != result){
                isValid = false;
                break;
            }
            
        }

        break;
    }

    console.log(isValid);
}

Magic([[4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]
   );