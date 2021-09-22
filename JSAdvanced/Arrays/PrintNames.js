function Print(arr){
    const result = arr.sort((a,b) => a.localeCompare(b));

    let currNum = 1;
    for (const ele of result) {
        console.log(`${currNum}.${ele}`);
        currNum++;
    }
}

Print(["John", "Bob", "Christina", "Ema"]);