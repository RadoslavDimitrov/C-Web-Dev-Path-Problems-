window.addEventListener('DOMContentLoaded', start);

async function start() {
    const main = document.querySelector('#main');

    const data = await getArticle();

    data.map(el => {
        const element = document.createElement('div');
        element.classList.add('accordion');

        const div = document.createElement('div');
        div.classList.add('head');

        const span = document.createElement('span');
        span.textContent = `${el.title}`;

        const btn = document.createElement('button');
        btn.classList.add('button');
        btn.id = `${el._id}`;
        btn.textContent = 'More';

        div.appendChild(span);
        div.appendChild(btn);

        element.appendChild(div);
        
        btn.addEventListener('click', () => showInfo(el._id, element));

        main.appendChild(element);
    })
}

async function showInfo(id, element){
    const data = await getArticleInfo(id);
    const btn = element.querySelector(`button`);

    let extraDiv = element.querySelector('.extra');

    if(btn.textContent == 'More'){
        btn.textContent = 'Less';

        if(extraDiv == null){
            extraDiv = document.createElement('div');
            extraDiv.classList.add('extra');
    
            extraDiv.style.display = 'block';
        
            const p = document.createElement('p');
            p.textContent = data.content;
        
            extraDiv.appendChild(p);
        
            element.appendChild(extraDiv);
        }
        else{
            extraDiv.style.display = 'block';
        }
    }
    else{
        btn.textContent = 'More';
        extraDiv.style.display = 'none';
    }

    

    //console.log(extraDiv.style.display);

    
}

async function getArticle(){
    const url = `http://localhost:3030/jsonstore/advanced/articles/list`;

    const response = await fetch(url);

    const data = await response.json();

    return data;
}

//"ee9823ab-c3e8-4a14-b998-8c22ec246bd3","title"

async function getArticleInfo(id){
    const url = `http://localhost:3030/jsonstore/advanced/articles/details/${id}`;

    const response = await fetch(url);

    if(response.status != 200){
        throw new Error('Wrong article id')
    }

    const data = await response.json();

    return data;
}