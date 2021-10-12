function Heroes(arr){
    let result = [];

    for (let heroData of arr) {
        let hero = {};

        let data = heroData.split(/[\s, ]+/);

        hero.name = data[0];
        hero.level = Number(data[2]);

        if(data.length > 4){
            let heroItems = [];

            for (let currItem = 4; currItem < data.length; currItem++) {
                heroItems.push(data[currItem]);
            }

            hero.items = heroItems;
        }
        else{
            hero.items = [];
        }

        result.push(hero);
    }

    console.log(JSON.stringify(result));
}

Heroes(['Isacc / 25 / Apple, GravityGun',
'Derek / 12 / BarrelVest, DestructionSword',
'Hes / 1 / Desolator, Sentinel, Antara']
);