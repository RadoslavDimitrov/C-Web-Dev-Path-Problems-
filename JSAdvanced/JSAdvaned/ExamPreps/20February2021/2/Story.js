class Story{
    constructor(title, creator){
        this.title = title;
        this.creator = creator;
        this.comments = [];
        this._likes = []; 
    }

    get likes(){
        if(this._likes.length == 0){
            return `${this.title} has 0 likes`
        }
        else if(this._likes.length == 1){
            return `${this._likes[0]} likes this story!`;
        }
        else{
            return `${this._likes[0]} and ${this._likes.length -1} others like this story!`;
        }
    }

    // set likes(value){
    //     this._likes.push(value);
    // }

    like (username){
        if(this._likes.some(el => el == username)){
            throw Error(`You can't like the same story twice!`);
        }
        else if(this.creator == username){
            throw Error(`You can't like your own story!`);
        }
        else{
            this._likes.push(username);
            return `${username} liked ${this.title}!`;
        }
    }

    dislike (username){
        if(!this._likes.some(el => el == username)){
            throw Error(`You can't dislike this story!`);
        }
        else{
            //TODO logic
            let index = this._likes.indexOf(username);
            this._likes.splice(index, 1)
            return `${username} disliked ${this.title}`;
        }
    }

    comment (username, content, id){
        if(id == undefined || !this.comments.some(x => x.Id == id)){
            //make new comment
            let newId = this.comments.length + 1;
            this.comments.push({
                Id: newId,
                Username: username,
                Content: content,
                Replies: []
            })

            return `${username} commented on ${this.title}`;
        }
        else{
            let comment = this.comments.filter(x => x.Id == id)[0];
            let commentId = comment.Id;
            let newReplyId = comment.Replies.length + 1;

            comment.Replies.push({
                Id: `${commentId}.${newReplyId}`,
                Username: username,
                Content: content
            })

            return `You replied successfully`;
        }
    }

    toString(sortingType){

        let result = [];
        result.push(`Title: ${this.title}`);
        result.push(`Creator: ${this.creator}`);
        result.push(`Likes: ${this._likes.length}`);
        result.push(`Comments:`);

        if(this.comments.length == 0){
            return result.join('\n');
        }

        if(sortingType.toLowerCase() == 'asc'){
            //comments and replies asc
            let sortedArr = this.comments.sort((a, b) => a.Id - b.Id);

            for (const el of sortedArr) {
                result.push(`-- ${el.Id}. ${el.Username}: ${el.Content}`);

                if(el.Replies.length > 0){
                    let sortedRep = el.Replies.sort((a, b) => a.Id - b.Id);

                    for (const reply of sortedRep) {
                        result.push(`--- ${reply.Id}. ${reply.Username}: ${reply.Content}`);
                    }
                }
            }
        }
        else if(sortingType.toLowerCase() == 'desc'){
            //comments and replies desc
            let sortedArr = this.comments.sort((a, b) => b.Id - a.Id);

            for (const el of sortedArr) {
                result.push(`-- ${el.Id}. ${el.Username}: ${el.Content}`);

                if(el.Replies.length > 0){
                    let sortedRep = el.Replies.sort((a, b) => b.Id - a.Id);

                    for (const reply of sortedRep) {
                        result.push(`--- ${reply.Id}. ${reply.Username}: ${reply.Content}`);
                    }
                }
            }
        }
        else if(sortingType.toLowerCase() == 'username'){
            //comments and replies by username asc
            let sortedArr = this.comments.sort((a, b) => (a.Username).localeCompare(b.Username));

            for (const el of sortedArr) {
                result.push(`-- ${el.Id}. ${el.Username}: ${el.Content}`);

                if(el.Replies.length > 0){
                    let sortedRep = el.Replies.sort((a, b) => (a.Username).localeCompare(b.Username));

                    for (const reply of sortedRep) {
                        result.push(`--- ${reply.Id}. ${reply.Username}: ${reply.Content}`);
                    }
                }
            }
        }

        return result.join('\n');
    }
}

let art = new Story("My Story", "Anny");
art.like("John");
console.log(art.likes);
art.dislike("John");
console.log(art.likes);
art.comment("Sammy", "Some Content");
console.log(art.comment("Ammy", "New Content"));
art.comment("Zane", "Reply", 1);
art.comment("Jessy", "Nice :)");
console.log(art.comment("SAmmy", "Reply@", 1));
console.log()
console.log(art.toString('username'));
console.log()
art.like("Zane");
console.log(art.toString('desc'));

