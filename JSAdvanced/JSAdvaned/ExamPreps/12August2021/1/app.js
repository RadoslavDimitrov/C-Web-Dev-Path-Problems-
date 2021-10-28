window.addEventListener('load', solve);

function solve() {
    //get all input references
    let model = document.getElementById('model');
    let year = document.getElementById('year');
    let description = document.getElementById('description');
    let price = document.getElementById('price');

    let addBtn = document.getElementById('add');
    
    addBtn.addEventListener('click', getInfo);
    
    function getInfo(e){
        e.preventDefault();
        
        yearValue = Number(year.value);
        priceValue = Number(price.value);

        if(model.value == '' 
            || yearValue <= 0 
            || Number.isNaN(yearValue) 
            || description.value == '' 
            || priceValue <= 0){
            return;
        }

        let tableBody = document.getElementById('furniture-list');

        //create table row
        let tr = document.createElement('tr');
        tr.className = 'info';

        //create td element with model
        let tdName = document.createElement('td');
        tdName.textContent = `${model.value}`;

        //create td element with price
        let tdPrice = document.createElement('td');
        tdPrice.textContent = `${priceValue.toFixed(2)}`;


        tr.appendChild(tdName);
        tr.appendChild(tdPrice);
        const tdBtn = document.createElement('td');
        const moreIfnoBtn = document.createElement('button');
        moreIfnoBtn.classList.add('moreBtn');
        moreIfnoBtn.textContent = 'More Info';
        const buyBtn = document.createElement('button');
        buyBtn.classList.add('buyBtn');
        buyBtn.textContent = 'Buy it';
        tdBtn.appendChild(moreIfnoBtn);
        tdBtn.appendChild(buyBtn);
        tr.appendChild(tdBtn);


        tableBody.appendChild(tr);

        tdBtn.addEventListener('click', moreInfo);
        
        buyBtn.addEventListener('click', buyItem);


        const trHide = document.createElement('tr');
        trHide.classList.add('hide');

        const tdYear = document.createElement('td');
        tdYear.textContent = `Year: ${yearValue}`;

        const tdDesc = document.createElement('td');
        tdDesc.colSpan = 3;
        tdDesc.textContent = `Description: ${description.value}`

        trHide.appendChild(tdYear);
        trHide.appendChild(tdDesc);

        tableBody.appendChild(trHide);  



        model.value = "";
        price.value = "";
        description.value = "";
        year.value = "";
        
    }

    function moreInfo(ev){
        const trToHide = ev.target.parentElement.parentElement.nextSibling;
        
        if(ev.target.textContent == 'More Info'){
            ev.target.textContent = 'Less Info';
            trToHide.style.display = 'contents';
        }
        else{
            ev.target.textContent = 'More Info';
            trToHide.style.display = 'none';
        }
    
    
    }
    
    function buyItem(e){
        let total = document.querySelector('.total-price');
    
        const price = Number(e.target.parentElement.previousSibling.textContent);
    
        let totalNum = Number(total.textContent);
    
        total.textContent = (totalNum += price).toFixed(2);
    
        const firstTr = e.target.parentElement.parentElement;
        const secontTr = e.target.parentElement.parentElement.nextSibling;
    
        secontTr.parentElement.removeChild(secontTr);
        firstTr.parentElement.removeChild(firstTr);
    
    }
}





