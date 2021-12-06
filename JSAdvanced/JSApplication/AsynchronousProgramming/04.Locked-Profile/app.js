async function lockedProfile() {
    const main = document.querySelector('main');
    main.appendChild(e('h1', {}, 'Loading.....'));

    const data = await getUserData();

    main.replaceChildren();

    profile(data);
    
}

function profile(data){
    Object.entries(data).forEach( el => {
        const imgSrc = './iconProfile2.png';

        const btn = e('button', {}, 'Show more');

        const inputEl = e('input', {type: 'text', name: el[1]._id, value: el[1].username});
        inputEl.disabled = true;
        inputEl.setAttribute("readonly", true);

        const inputEmailEl = e('input', {type: 'email', name: el[1]._id, value: el[1].email});
        inputEmailEl.disabled = true;
        inputEmailEl.setAttribute('readonly', true);

        const inputAgeEl = e('input', {type: 'email', name: el[1].age, value: el[1].age});
        inputAgeEl.disabled = true;
        inputAgeEl.setAttribute('readonly', true);

        const defaultCheckedRb = e('input', {type: 'radio', name: `${el[1]._id}Locked`, value: 'lock'});
        defaultCheckedRb.checked = true;

        const divToHide = e('div', {id: `${el[1]._id}HiddenFields`},
            e('hr', {}),
            e('label', {}, 'Email:'),
            inputEmailEl, //TODO add disabled and readonly)
            e('label', {}, 'Age:'),
            inputAgeEl, //TODO add disabled and readonly)
            );
        

        console.log(el);

        const profileCard = e('div', {className: 'profile'},
            e('img', {src: imgSrc, className: 'userIcon'}),
            e('label', {}, 'Lock'),
            defaultCheckedRb,
            e('label', {}, 'Unlock'),
            e('input', {type: 'radio', name: `${el[1]._id}Locked`, value: 'unlock'}),
            e('br', {}),
            e('hr', {}),
            e('label', {}, 'Username'),
            inputEl, //TODO add disabled and readonly
            btn
        )

        btn.addEventListener('click', () => showInfo(profileCard, divToHide, el[1]._id))

        main.appendChild(profileCard);
    })
}

function showInfo(element, divToHide, elementId){
    const btn = element.querySelector('button');

    const rbs = element.querySelectorAll(`input[name="${elementId}Locked"]`);
    let lockOrNot;
    for (const rb of rbs) {
        if(rb.checked){
            lockOrNot = rb.value;
            break;
        }
    }

    if(lockOrNot == 'unlock'){
        if(btn.textContent == 'Show more'){
            btn.textContent = 'Show less';
            element.insertBefore(divToHide, btn);
        }
        else{
            btn.textContent = 'Show more';
            element.removeChild(divToHide);
        }
    }

}

async function getUserData(){
    const url = 'http://localhost:3030/jsonstore/advanced/profiles';

    const response = await fetch(url);
    const data = await response.json();

    return data;
}

function e(type, attr, ...content){
    let element = document.createElement(type);

    for (const key in attr) {
        element[key] = attr[key];
    }

    for (let item of content) {
        if(typeof(item) == 'string' || typeof(item) == 'number'){
            item = document.createTextNode(item);
        }
        element.appendChild(item);
    }

    return element;
}