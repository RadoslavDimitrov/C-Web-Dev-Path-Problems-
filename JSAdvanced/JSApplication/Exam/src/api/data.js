
import * as api from './api.js';

const login = api.login;
const register = api.register;
const logout = api.logout;

async function getAllAlbums(){
    return api.getRequest('/data/albums?sortBy=_createdOn%20desc&distinct=name');
}

async function createAlbum(data){
    return api.postRequest('/data/albums', data);
}

async function getAlbumById(id){
    return api.getRequest('/data/albums/' + id);
}

async function deleteById(id){
    return api.deleteRequest('/data/albums/' + id);
}

async function editAlbumById(id, data){
    return api.putRequest('/data/albums/' + id, data);
}

async function searchAlbum(query){
    return api.getRequest(`/data/albums?where=name%20LIKE%20%22${query}%22`)
}

export{
    login,
    register,
    logout,
    getAllAlbums,
    createAlbum,
    getAlbumById,
    deleteById,
    editAlbumById,
    searchAlbum
    
}