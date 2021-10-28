function solve(){
   //get all input references

   let createBtn = document.querySelector("form button");
   
   const olEl = document.querySelector('ol');
   const postSection = document.querySelector("main section");


   createBtn.addEventListener('click', createArticle);
   

   function createArticle(e){
      e.preventDefault();

      let author = document.getElementById('creator');
      let title = document.getElementById('title');
      let category = document.getElementById('category');
      let content = document.getElementById('content');


      //author.value for value;
      const article = document.createElement('article');

      const h1 = document.createElement('h1');
      h1.textContent = title.value;

      const categoryP = document.createElement('p');
      categoryP.textContent = 'Category:';

      const categoryStrong = document.createElement('strong');
      categoryStrong.textContent = category.value;

      categoryP.appendChild(categoryStrong);

      const creatorP = document.createElement('p');
      creatorP.textContent = 'Creator:';

      const creatorStrong = document.createElement('strong');
      creatorStrong.textContent = author.value;

      creatorP.appendChild(creatorStrong);

      const contentP = document.createElement('p');
      contentP.textContent = content.value;

      const btnDiv = document.createElement('div');
      btnDiv.classList.add('buttons');

      const btnDelete = createButton('btn','delete', 'Delete');
      const btnArchive = createButton('btn','archive', 'Archive');

      btnDiv.appendChild(btnDelete);
      btnDiv.appendChild(btnArchive);

      article.appendChild(h1);
      article.appendChild(categoryP);
      article.appendChild(creatorP);
      article.appendChild(contentP);
      article.appendChild(btnDiv);

      postSection.appendChild(article);

      btnDelete.addEventListener('click', deleteArticle.bind(null, article));
      btnArchive.addEventListener('click', archiveArticle);

      author.value = '';
      title.value = '';
      category.value = '';
      content.value = '';

      function deleteArticle(article){
         postSection.removeChild(article);
      }

      function archiveArticle(){
         const liArticle = document.createElement('li');
         liArticle.textContent = h1.textContent;


         olEl.appendChild(liArticle);

         //TODO sort articles
         const articles = Array.from(document.querySelectorAll('li'));
         olEl.innerHTML = '';
         
         articles.sort((a, b) => a.textContent.localeCompare(b.textContent))
         .forEach(e => olEl.appendChild(e));
         
         postSection.removeChild(article);
      }

      function createButton(className,classNameTwo, value){
         let result = document.createElement('button');
         result.classList.add(className, classNameTwo);
         result.textContent = value;

         return result;
      }
   }
  }


// function solve() {
 
//    const buttonCreate = document.querySelector('body > div > div > aside > section:nth-child(1) > form > button');
//    const posts = document.querySelector('body > div > div > main > section');
//    const archive =document.querySelector('body > div > div > aside > section.archive-section > ol') ;
  
//    buttonCreate.addEventListener('click', createPost);
  
//    function createPost(e) {
//      e.preventDefault();
  
//      let authorEl = document.querySelector('#creator');
//      let titleEl = document.querySelector('#title');
//      let categoryEl = document.querySelector('#category');
//      let contentEl = document.querySelector('#content');
  
//      let titleValue = titleEl.value;
  
  
//      const deleteBtn = el('button', 'Delete', {
//        className: 'btn delete'
//      });
  
//      const archiveBtn = el('button', 'Archive', {
//        className: 'btn archive'
//      });
  
//      archiveBtn.addEventListener('click', () =>{
//        let olEl = el('li',titleValue);
//        archive.appendChild(olEl);
  
//        const items = [...archive.querySelectorAll('li')];
//        archive.innerHTML = '';
  
//        items.sort((a, b) => a.textContent.localeCompare(b.textContent))
//           .forEach(e => archive.appendChild(e));
  
//        posts.removeChild(article);
//      });
  
//      deleteBtn.addEventListener('click', () => {
//        posts.removeChild(article);
//      });
  
//      const article =
//        el('article', [
//          el('h1', titleEl.value),
//          el('p', ['Category: ', el('strong', categoryEl.value)]),
//          el('p', ['Creator: ', el('strong', authorEl.value)]),
//          el('p', contentEl.value),
//          el('div', [deleteBtn, archiveBtn], {
//            className: 'buttons'
//          })
//        ]);
  
//      titleEl.value = '';
//      categoryEl.value = '';
//      authorEl.value = '';
//      contentEl.value = '';
  
//      posts.appendChild(article);
//    }
  
//    function el(type, content, attributes) {
//      const result = document.createElement(type);
  
//      if (attributes !== undefined) {
//        Object.assign(result, attributes);
//      }
  
//      if (Array.isArray(content)) {
//        content.forEach(append);
//      } else {
//        append(content);
//      }
  
//      function append(node) {
//        if (node === null) { node = ' '; }
//        if (typeof node === 'string' || typeof node === 'number') {
//          node = document.createTextNode(node);
//        }
//        result.appendChild(node);
//      }
//      return result;
//    }
//  }
  
