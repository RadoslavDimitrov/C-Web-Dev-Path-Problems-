class ArtGallery {
    constructor(creator){
        this.creator = creator;
        this.possibleArticles = { "picture":200,"photo":50,"item":250 };
        this.listOfArticles = [];
        this.guests = [];

        this.guestPersonality = {
            'Vip': 500,
            'Middle': 250
        };
    }

    addArticle( articleModel, articleName, quantity ){
        let hasArticle = this._hasArticle(articleModel);

        if(!hasArticle){
            throw Error(`This article model is not included in this gallery!`);
        }

        if(this.listOfArticles.some(a => a.articleName == articleName)){
            let currArticle = this.listOfArticles.filter(a => a.articleName == articleName);
            currArticle[0].quantity += quantity;
        }
        else{
            this.listOfArticles.push({articleModel : articleModel.toLowerCase(), articleName, quantity})
        }

        return `Successfully added article ${articleName} with a new quantity- ${quantity}.`;
    }

    /**
     * 
     * @param {string} guestName 
     * @param {string} personality 
     */
    inviteGuest ( guestName, personality){
        if(this.guests.some(g => g.guestName == guestName)){
            throw Error(`${guestName} has already been invited.`);
        }
        
        let guest = {
            guestName, 
            points: 0, 
            purchaseArticle: 0
        };

        if(this.guestPersonality.hasOwnProperty(personality)){
            guest.points = this.guestPersonality[personality];
        }
        else{
            guest.points = 50;
        }

        this.guests.push(guest);

        return `You have successfully invited ${guest.guestName}!`;
    }

    /**
     * 
     * @param {string} articleModel 
     * @param {string} articleName 
     * @param {string} guestName 
     */
    buyArticle ( articleModel, articleName, guestName){
        
        let objArticle = this._getObj(articleName, this.listOfArticles);

        if(objArticle == undefined){
            throw Error('"This article is not found."');
        }

        if(objArticle.articleModel != articleModel){
            throw Error('"This article is not found."');
        }

        if(objArticle.quantity == 0){
            return `The ${articleName} is not available.`;
        }

        let currGuest = this.guests.filter(g => g.guestName == guestName)[0];

        if(currGuest == undefined){
                return `This guest is not invited.`;
        }

        let guestPoints = currGuest.points;
        let currArticlePoints = undefined;

        if(this.possibleArticles.hasOwnProperty(articleModel.toLowerCase())){
            currArticlePoints = this.possibleArticles[articleModel.toLowerCase()];
        }
        
        if(guestPoints < currArticlePoints){
            return `You need to more points to purchase the article.`;
        }

        currGuest.points -= currArticlePoints;
        currGuest.purchaseArticle++;
        objArticle.quantity--;

        return `${currGuest.guestName} successfully purchased the article worth ${currArticlePoints} points.`; 

    }

    showGalleryInfo (criteria){
        let result = [];
        if(criteria == 'article'){
            result.push(`Articles information:`);

            for (const obj of this.listOfArticles) {
                result.push(`${obj.articleModel} - ${obj.articleName} - ${obj.quantity}`);
            }

            return result.join('\n');
        }
        else{
            //return guests
            result.push(`Guests information:`);

            for (const guest of this.guests) {
                result.push(`${guest.guestName} - ${guest.purchaseArticle}`);
            }

            return result.join('\n');
        }
    }

    _getObj(articleName, arr){

        for (const obj of arr) {
            if(obj.articleName == articleName){
                return obj;
            }
        }

        return undefined;
    }

    _hasArticle(articleModel){
        let hasArticle = false;

        for (const article in this.possibleArticles) {
            if(article.toLowerCase() == articleModel.toLowerCase()){
                hasArticle = true;
                break;
            }
        }

        return hasArticle;
    }
}


let art = new ArtGallery("Curtis Mayfield");

art.addArticle('picture', 'Mona Liza', 3);
art.addArticle('Item', 'Ancient vase', 2);
art.addArticle('picture', 'Mona Liza', 1);

art.inviteGuest('John', 'Vip');
art.inviteGuest('Peter', 'Middle');

art.buyArticle('picture', 'Mona Liza', 'John');
art.buyArticle('item', 'Ancient vase', 'Peter');

console.log(art.showGalleryInfo('article'));
console.log(art.showGalleryInfo('guest'));

