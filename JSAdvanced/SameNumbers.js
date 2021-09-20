    
function SameNum(number){
    const numAsStr = number.toString();

    let result = parseInt(numAsStr[0]);
    let isValid = true;

    for (let i = 1; i < numAsStr.length; i++) {
        result += parseInt(numAsStr[i]);
 
        if (numAsStr[i] != numAsStr[i-1]) {
            isValid = false;
        }
    }

    console.log(isValid);
    console.log(result);
}

SameNum(2222222);
SameNum(1234);
