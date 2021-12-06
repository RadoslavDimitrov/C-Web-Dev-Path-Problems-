import { deleteMemeById, getMimeById } from '../api/data.js';
import { html } from '../lib.js';
import { getUserData } from '../util.js';

const detailsTemplate = (meme, userId, onDelete) => html`
<section id="meme-details">
    <h1>Meme Title: ${meme.title}

    </h1>
    <div class="meme-details">
        <div class="meme-img">
            <img alt="meme-alt" src="${meme.imageUrl}">
        </div>
        <div class="meme-description">
            <h2>Meme Description</h2>
            <p>
                ${meme.description}
            </p>

            <!-- Buttons Edit/Delete should be displayed only for creator of this meme  -->
            ${isOwner(userId, meme, onDelete)};

        </div>
    </div>
</section>`;

function isOwner(userId, meme, onDelete) {
    if (userId == meme._ownerId) {
        return html`
        <a class="button warning" href="/edit/${meme._id}">Edit</a>
        <button @click=${onDelete} class="button danger">Delete</button>`;
    }
    else {
        return null
    }

}


export async function detailsPage(ctx) {
    const memeId = ctx.params.id;
    const meme = await getMimeById(memeId);

    const userData = getUserData();
    const userId = userData.id;

    ctx.render(detailsTemplate(meme, userId, onDelete));

    async function onDelete(event){
        event.preventDefault();
        
        await deleteMemeById(memeId);
        ctx.page.redirect('/memes');
    }
}