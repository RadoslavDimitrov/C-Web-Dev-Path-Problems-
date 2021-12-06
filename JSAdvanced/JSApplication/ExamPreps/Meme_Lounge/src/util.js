function getUserData(){
    const data = JSON.parse(sessionStorage.getItem('userData'));
    return data;
}

function setUserData(data){
    sessionStorage.setItem('userData', JSON.stringify(data));
}

function clearUserData(){
    sessionStorage.removeItem('userData');
}

export{
    getUserData,
    setUserData,
    clearUserData
}