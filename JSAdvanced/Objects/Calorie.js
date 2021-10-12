function Solve(arr){
    const result = {};

    for (let index = 0; index < arr.length; index+=2) {
        result[arr[index]] = Number(arr[index + 1]);
    }

    console.log(result);
}

Solve(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);