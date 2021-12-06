import { getAllAlbums } from '../api/data.js';
import { html } from '../lib.js';
import { getUserData } from '../util.js';


const catalogTemplate = (cards, userData) => html`
<section id="catalogPage">
    <h1>All Albums</h1>

    ${cards.length > 0 ? cards.map((c) => cardTemplate(c, userData))
    : html`<p>No Albums in Catalog!</p>`}


    <!--No albums in catalog-->


</section>`;

function cardTemplate(card, userData) {
    return html`
    <div class="card-box">
        <img src="${card.imgUrl}">
        <div>
            <div class="text-center">
                <p class="name">Name: ${card.name}</p>
                <p class="artist">Artist: ${card.artist}</p>
                <p class="genre">Genre: ${card.genre}</p>
                <p class="price">Price: ${card.price}</p>
                <p class="date">Release Date: ${card.releaseDate}</p>
            </div>
            ${userData ? html`<div class="btn-group">
                <a href="/details/${card._id}" id="details">Details</a>
            </div>` : null}
    
        </div>
    </div>`;
}

export async function catalogPage(ctx) {
    const albums = await getAllAlbums();

    const userData = getUserData();

    ctx.render(catalogTemplate(albums, userData));
}