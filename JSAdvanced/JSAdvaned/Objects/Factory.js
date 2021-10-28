function Solve(obj){
    const car = {};

    car.model = obj.model;
    car.engine = GetEngine(obj.power);
    car.carriage = MakeCarriage(obj.color, obj.carriage);
    car.wheels = MakeWheels(obj.wheelsize);

    return car;

    function MakeWheels(size){
        let wheelSize = [];

        if(size % 2 == 0){
            for (let index = 0; index < 4; index++) {
                wheelSize.push(size - 1);
            }
        }
        else{
            for (let index = 0; index < 4; index++) {
                wheelSize.push(size);
            }
        }

        return wheelSize;
    }

    function MakeCarriage(color, type){
        let carriage = {};

        carriage.type = type;
        carriage.color = color;

        return carriage;
    }

    function GetEngine(power){
        let engine = {};

        if(power <= 90){
            engine = { power: 90, volume: 1800 };
        }
        else if(power <= 120){
            engine = { power: 120, volume: 2400};
        }
        else{
            engine = { power: 200, volume: 3500 };
        }

        return engine;
    }
}

console.log(Solve({
    model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14
}));