function moneyNeeded(fruit, weight, price){ //weight in grams
    let weitghtKg = weight / 1000;
    let totalPrice = weitghtKg * price;
    console.log(`I need $${totalPrice.toFixed(2)} to buy ${weitghtKg.toFixed(2)} kilograms ${fruit}.`)
}

moneyNeeded('orange', 2500, 1.80);
moneyNeeded('apple', 1563, 2.35);
