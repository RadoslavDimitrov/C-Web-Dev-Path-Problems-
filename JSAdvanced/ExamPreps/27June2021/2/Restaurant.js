class Restaurant{
    constructor(budget){
        this.budgetMoney = budget;
        this.menu = {};
        this.stockProducts = {};
        this.history = [];
    }

    /**
     * 
     * @param {array} arr 
     */
    loadProducts(arr){
        //"{productName} {productQuantity} {productTotalPrice}"
        //Example: ["Banana 10 5", "Strawberries 50 30", "Honey 5 50"…]
        let result = [];
        //TODO check if we must return this.history
        for (let currProduct = 0; currProduct < arr.length; currProduct++) {
            let [product, quantityStr, priceStr] = arr[currProduct].split(' ');
            let quantity = Number(quantityStr);
            let price = Number(priceStr);
            const currProductPrice = price;

            if(this.budgetMoney >= currProductPrice){
                //we buy the product
                this.budgetMoney -= currProductPrice;
                if(this.stockProducts.hasOwnProperty(product)){
                    //we have it
                    this.stockProducts[product] += quantity;
                }
                else{
                    this.stockProducts[product] = quantity;
                }

                this.history.push(`Successfully loaded ${quantity} ${product}`);
                result.push(`Successfully loaded ${quantity} ${product}`);
            }
            else{
                this.history.push(`There was not enough money to load ${quantity} ${product}`);
                result.push(`There was not enough money to load ${quantity} ${product}`);
            }
        }

        return result;
    }

    /**
     * 
     * @param {string} meal 
     * @param {array} neededProducts 
     * @param {number} price 
     */
    addToMenu(meal, neededProducts, price){
        let products = 'products';

        if(this.menu.hasOwnProperty(meal)){
            return `The ${meal} is already in the our menu, try something different.`;
        }

        this.menu[meal] = {
            products: {},
            price
        };

        for (let index = 0; index < neededProducts.length; index++) {
            let [productName, productQuantityStr] = neededProducts[index].split(' ');
            let productQuantity = Number(productQuantityStr);

            if(this.menu[meal][products].hasOwnProperty(productName)){
                this.menu[meal][products][productName] += productQuantity;
            }
            else{
                this.menu[meal][products][productName] = productQuantity;
            }
            
        }

        const menuLenght = Object.keys(this.menu).length;

        if(menuLenght > 1){
            return `Great idea! Now with the ${meal} we have ${menuLenght} meals in the menu, other ideas?`;
        }
        else{
            return `Great idea! Now with the ${meal} we have 1 meal in the menu, other ideas?`;
        }
    }

    showTheMenu(){
        if(Object.keys(this.menu).length < 1){
            return `Our menu is not ready yet, please come later...`;
        }
        else{
            let result = [];
            for (const [key, entry] of Object.entries(this.menu)) {
                result.push(`${key} - $ ${entry.price}`);
            }

            return result.join('\n');
        }
    }

    /**
     * 
     * @param {string} meal 
     */
    makeTheOrder(meal){
        if(!this.menu.hasOwnProperty(meal)){
            return `There is not ${meal} yet in our menu, do you want to order something else?`;
        }

        let products = 'products';

        let resultProducts = {};
        let counter = 0;

        let currMealProducts = this.menu[meal][products];
        for (const currProduct in currMealProducts) {
            let currMenuProductQuantity = this.menu[meal][products][currProduct];
            if(this.stockProducts.hasOwnProperty(currProduct)){
                if(this.stockProducts[currProduct] >= currMenuProductQuantity){
                    counter++;
                    resultProducts[currProduct] = currMenuProductQuantity;
                }
            }
        }


        if(counter == Object.keys(this.menu[meal][products]).length){
            for (const [product, quantity] in resultProducts) {
                this.stockProducts[product]-=quantity;
            }

            return `Your order (${meal}) will be completed in the next 30 minutes and will cost you ${this.menu[meal].price}.`;
        }

        return `For the time being, we cannot complete your order (${meal}), we are very sorry...`;
    }
}

let kitchen = new Restaurant(1000); 

kitchen.loadProducts(['Yogurt 30 3', 'Honey 50 4', 'Strawberries 20 10', 'Banana 5 1']); 

kitchen.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10'], 9.99); 

console.log(kitchen.makeTheOrder('frozenYogurt')); 
