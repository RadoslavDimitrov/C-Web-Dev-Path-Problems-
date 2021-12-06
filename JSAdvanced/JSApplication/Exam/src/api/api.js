import { getUserData, setUserData, clearUserData } from "../util.js";

const host = 'http://localhost:3030';

async function request(url, options){

    try{
        const result = await fetch(host + url, options);

        if(result.ok != true){
            const error = await result.json();
            throw new Error(error.message);
        }

        try{
            return await result.json();
        } catch(err){
            return result;
        }
    }catch(err){
        alert(err.message);
        throw err;
    }
    
}

function createOptions(method = 'get', data){
    const opitons = {
        method,
        headers: {}
    }

    if(data != undefined){
        opitons.headers['Content-Type'] = 'application/json';
        opitons.body = JSON.stringify(data);
    }

    const userData = getUserData();

    if(userData){
        opitons.headers['X-Authorization'] = userData.token;
    }

    return opitons;
}

async function getRequest(url){
    return request(url, createOptions());
}

async function postRequest(url, data){
    return request(url, createOptions('post', data));
}

async function putRequest(url, data){
    return request(url, createOptions('put', data));
}

async function deleteRequest(url){
    return request(url, createOptions('delete'));
}

async function login(email, password){
    const result = await postRequest('/users/login', {email, password});

    const userData = {
        email: result.email,
        id: result._id,
        token: result.accessToken
    }

    setUserData(userData);

    return result;
}

async function register(email, password){
    const result = await postRequest('/users/register', {email, password});

    const userData = {
        email: result.email,
        id: result._id,
        token: result.accessToken
    }

    setUserData(userData);

    return result;
}

async function logout(){
    getRequest('/users/logout')
    clearUserData();
}

export{
    getRequest,
    postRequest,
    putRequest,
    deleteRequest,
    login,
    register,
    logout
}

