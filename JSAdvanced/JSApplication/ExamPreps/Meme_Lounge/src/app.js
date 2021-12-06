import { render, page } from '../src/lib.js';
import { logout } from './api/data.js';
import { getUserData } from './util.js';
import { createPage } from './views/create.js';
import { detailsPage } from './views/details.js';
import { editPage } from './views/edit.js';

import { homePage } from './views/home.js';
import { loginPage } from './views/login.js';
import { allMemes } from './views/memes.js';
import { profilePage } from './views/my-profile.js';
import { registerPage } from './views/register.js';

const main = document.querySelector('main');
document.getElementById('logoutBtn').addEventListener('click', onLogout);
//add logout event listener and function


page(decorateContext);
page('/', homePage)
page('/login', loginPage)
page('/register', registerPage)
page('/create', createPage)
page('/memes', allMemes)
page('/details/:id', detailsPage)
page('/edit/:id', editPage)
page('/my-profile', profilePage)

updateUserNav();
page.start();


function decorateContext(ctx, next){
    ctx.render = (content) => render(content, main);
    ctx.updateUserNav = updateUserNav;
    next();
}

function onLogout(event){
    event.preventDefault();
    logout();
    updateUserNav();
}

function updateUserNav(){
    const userData = getUserData();

    if(userData){
        document.querySelector('.user').style.display = 'block';
        document.querySelector('.guest').style.display = 'none';
        document.querySelector('.user span').textContent = `Welcome, ${userData.email}`;
    }
    else{
        document.querySelector('.user').style.display = 'none';
        document.querySelector('.guest').style.display = 'block';
    }
}
