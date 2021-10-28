window.addEventListener('load', solve);

function solve() {
    //get all references
    const genre = document.getElementById('genre');
    const name = document.getElementById('name');
    const author = document.getElementById('author');
    const date = document.getElementById('date');

    const songsList = document.querySelector('.all-hits-container');
    const savedList = document.querySelector('.saved-container');
    const totalLikes = document.querySelector('.likes p');

    const addBtn = document.querySelector('#add-btn');
    addBtn.addEventListener('click', addSong);

    function addSong(event){
        event.preventDefault();

        if(genre.value == '' || name.value == '' || author.value == '' || date.value == ''){
            return;
        }

        //TODO check date validation

        // console.log(date.value);

        // Date.prototype.isValid = function () {
              
        //     // If the date object is invalid it
        //     // will return 'NaN' on getTime() 
        //     // and NaN is never equal to itself.
        //     return this.getTime() === this.getTime();
        // };



        const divEl = document.createElement('div');
        divEl.classList.add('hits-info');

        const image = document.createElement('img');
        image.src = './static/img/img.png';

        const h2Genre = document.createElement('h2');
        h2Genre.textContent = `Genre: ${genre.value}`;

        const h2Name = document.createElement('h2');
        h2Name.textContent = `Name: ${name.value}`;

        const h2Author = document.createElement('h2');
        h2Author.textContent = `Author: ${author.value}`;

        const h3Date = document.createElement('h3');
        h3Date.textContent = `Date: ${date.value}`;

        divEl.appendChild(image);
        divEl.appendChild(h2Genre);
        divEl.appendChild(h2Name);
        divEl.appendChild(h2Author);
        divEl.appendChild(h3Date);

        const saveBtn = document.createElement('button');
        saveBtn.classList.add('save-btn');
        saveBtn.textContent = `Save song`;

        const likeBtn = document.createElement('button');
        likeBtn.classList.add('like-btn');
        likeBtn.textContent = `Like song`;

        const deleteBtn = document.createElement('button');
        deleteBtn.classList.add('delete-btn');
        deleteBtn.textContent = `Delete`;

        divEl.appendChild(saveBtn);
        divEl.appendChild(likeBtn);
        divEl.appendChild(deleteBtn);

        songsList.appendChild(divEl);

        genre.value = '';
        name.value = '';
        author.value = '';
        date.value = '';

        likeBtn.addEventListener('click', addLikes);
        saveBtn.addEventListener('click', saveSong);
        deleteBtn.addEventListener('click', deleteSong);

        function deleteSong(e){
            let parent = e.target.parentElement;
            //console.log(parent);
            if(parent.parentElement.classList.contains('all-hits-container')){
                songsList.removeChild(parent);
            }
            else{
                savedList.removeChild(parent);
            }

        }

        function saveSong(e){
            const parentDiv = e.target.parentElement;
            const currSaveBtn = parentDiv.querySelector('.save-btn');
            const currLikeBtn = parentDiv.querySelector('.like-btn');
            parentDiv.removeChild(currSaveBtn);
            parentDiv.removeChild(currLikeBtn);

            savedList.appendChild(parentDiv);
        }

        function addLikes(){
            let likeNum = Number(totalLikes.textContent.split(' ')[2]);
            likeNum++;
            totalLikes.textContent = `Total Likes: ${likeNum}`;
            likeBtn.disabled = true;
        }
    }
}