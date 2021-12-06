import { render, page } from '../src/lib.js';
import { getUserData } from './util.js';
import {logout} from '../src/api/data.js';

import {homePage} from '../src/views/home.js';
import { loginPage } from './views/login.js';
import { registerPage } from './views/register.js';
import { catalogPage } from './views/catalog.js';
import { createPage } from './views/create.js';
import { detailsPage } from './views/details.js';
import { editPage } from './views/edit.js';
import { searchPage } from './views/search.js';





const main = document.querySelector('main');
document.getElementById('logoutBtn').addEventListener('click', onLogout);
//add logout event listener and function


page(decorateContext);
page('/', homePage)
page('/login', loginPage)
page('/register', registerPage)
page('/catalog', catalogPage)
page('/create', createPage)
page('/details/:id', detailsPage)
page('/edit/:id', editPage)
page('/search', searchPage)


updateUserNav();
page.start();



function decorateContext(ctx, next){
    ctx.render = (template) => render(template, main);
    ctx.updateUserNav = updateUserNav;

    next();
}

function onLogout(event){
    event.preventDefault();
    logout();
    updateUserNav();
    page.redirect('/');
}

function updateUserNav(){
    const userData = getUserData();

    if(userData){
        document.querySelector('#userCreateBtn').style.display = 'block';
        document.querySelector('#userLogout').style.display = 'block';
        document.querySelector('#guestLoginBtn').style.display = 'none';
        document.querySelector('#guestRegisterBtn').style.display = 'none';
    }
    else{
        document.querySelector('#userCreateBtn').style.display = 'none';
        document.querySelector('#userLogout').style.display = 'none';
        document.querySelector('#guestLoginBtn').style.display = 'block';
        document.querySelector('#guestRegisterBtn').style.display = 'block';
    }
}
