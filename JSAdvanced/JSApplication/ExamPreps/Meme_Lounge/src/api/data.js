
import * as api from './api.js';

const login = api.login;
const register = api.register;
const logout = api.logout;

async function createMeme(mime){
    return api.postRequest('/data/memes', mime);
}

async function getAllMemes(){
    return api.getRequest('/data/memes?sortBy=_createdOn%20desc');
}

async function getMimeById(id){
    return api.getRequest('/data/memes/' + id);
}

async function deleteMemeById(id){
    return api.deleteRequest('/data/memes/' + id);
}

async function editMeme(id, meme){
    return api.putRequest('/data/memes/' + id,meme);
}

async function getUserMemes(userId){
    return api.getRequest(`/data/memes?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
}

export{
    login,
    register,
    logout,
    createMeme,
    getAllMemes,
    getMimeById,
    deleteMemeById,
    editMeme,
    getUserMemes
}