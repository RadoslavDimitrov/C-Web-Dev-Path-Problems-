
import { searchAlbum } from "../api/data.js";
import { html } from "../lib.js";
import { getUserData } from "../util.js";

const searchTemplate = (albums, onSubmit, queryStr = '', userData) => html`
<section id="searchPage">
    <h1>Search by Name</h1>

    <div class="search">
        <input id="search-input" type="text" name="search" placeholder="Enter desired albums's name"
            .value="${queryStr}">
        <button @click=${onSubmit} class="button-list">Search</button>
    </div>
    <h2>Results:</h2>



    ${albums.length == 0 ? html`<div class="search-result">
        <!--If there are no matches-->
        <p class="no-result">No result.</p>
    </div>` : albums.map((c) => searchCard(c, userData))}

</section>`;


function searchCard(album, userData) {
    return html`<div class="card-box">
    <img src="${album.imgUrl}">
    <div>
        <div class="text-center">
            <p class="name">Name: ${album.name}s</p>
            <p class="artist">Artist: ${album.artist}</p>
            <p class="genre">Genre: ${album.genre}</p>
            <p class="price">Price: ${album.price}</p>
            <p class="date">Release Date: ${album.releaseDate}</p>
        </div>

        ${isLogged(userData, album)}

    </div>
</div>`;
}

function isLogged(userData,album) {
    if (userData) {
        return html`<div class="btn-group">
                        <a href="/details/${album._id}" id="details">Details</a>
                    </div>`;
    }
    else{
        return null;
    }
}

export async function searchPage(ctx) {
    const queryStr = ctx.querystring.split('=')[1];

    let albums = [];
    if (queryStr) {
        albums = await searchAlbum(queryStr);
    }

    const userData = getUserData();

    ctx.render(searchTemplate(albums, onSubmit, queryStr, userData));

    async function onSubmit(event) {
        event.preventDefault();

        const searchTerm = document.querySelector('#search-input').value;

        if (searchTerm) {
            ctx.page.redirect('/search?query=' + encodeURIComponent(searchTerm));
        }
        else {
            alert('please fill the field');
            return;
        }
    }
}