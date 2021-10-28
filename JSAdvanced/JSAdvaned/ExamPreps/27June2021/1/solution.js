window.addEventListener('load', solution);

function solution() {
  const fullNameInput = document.getElementById('fname');
  const emailInput = document.getElementById('email');
  const numberInput = document.getElementById('phone');
  const addressInput = document.getElementById('address');
  const postCodeInput = document.getElementById('code');

  const submitBtnInput = document.getElementById('submitBTN');

  submitBtnInput.addEventListener('click', submitInfo);

  const infoUl = document.getElementById('infoPreview');
  const editBtn = document.getElementById('editBTN');
  const continueBtn = document.getElementById('continueBTN');

  editBtn.addEventListener('click', editInput);
  continueBtn.addEventListener('click', continueReservation);

  function submitInfo(e){
    e.preventDefailt;

      if(fullNameInput.value == '' || emailInput.value == ''){
        return;
      }

      const fullNamePreviewLi = createLiElement('Full Name', fullNameInput.value);    
      const emailPreviewLi = createLiElement('Email', emailInput.value);
      const numberPreviewLi = createLiElement('Phone Number', numberInput.value);
      const addressPreviewLi = createLiElement('Address', addressInput.value);
      const postCodePreviewLi = createLiElement('Postal Code', postCodeInput.value);

      infoUl.appendChild(fullNamePreviewLi);
      infoUl.appendChild(emailPreviewLi);
      infoUl.appendChild(numberPreviewLi);
      infoUl.appendChild(addressPreviewLi);
      infoUl.appendChild(postCodePreviewLi);

      const fname = fullNameInput.value;
      const email = emailInput.value;
      const number = numberInput.value;
      const address = addressInput.value;
      const postCode = postCodeInput.value;
      
      submitBtnInput.disabled = true;
      editBtn.disabled = false;
      continueBtn.disabled = false;
      
      fullNameInput.value = '';
      emailInput.value = '';
      numberInput.value = '';
      addressInput.value = '';
      postCodeInput.value = '';
  }

  function editInput(){
    //const allLielements = Array.from(document.getElementsByTagName('li'));
    const fNameValue = (infoUl.children[0].textContent).slice(11);
    const emailValue = (infoUl.children[1].textContent).slice(7);
    const numberValue = (infoUl.children[2].textContent).slice(14);
    const addressValue = (infoUl.children[3].textContent).slice(9);
    const postCodeValue = (infoUl.children[4].textContent).slice(13);
    console.log(fNameValue,emailValue,numberValue,addressValue,postCodeValue);

    editBtn.disabled = true;
    continueBtn.disabled = true;
    submitBtnInput.disabled = false;

    fullNameInput.value = fNameValue;
    emailInput.value = emailValue;
    numberInput.value = numberValue;
    addressInput.value = addressValue;
    postCodeInput.value = postCodeValue;

    infoUl.textContent = '';
  }

  function continueReservation(){
    const divToRemove = document.getElementById('block');
    divToRemove.innerHTML = '';

    const thanksMessage = document.createElement('h3');
    thanksMessage.textContent = 'Thank you for your reservation!';
    divToRemove.appendChild(thanksMessage);
  }

  function createLiElement(startStr, value){
    const element = document.createElement('li');

    element.textContent = `${startStr}: ${value}`;

    return element;
  }
}
