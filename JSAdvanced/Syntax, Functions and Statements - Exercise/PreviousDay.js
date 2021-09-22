function previousDate (year, month, day) {
    let dateString = new Date(year, month-1, day);
    dateString.setDate(day-1);
    console.log(dateString.getFullYear() + '-' + (dateString.getMonth() + 1) + '-' + dateString.getDate());
}

previousDate(2016, 9, 30);


    // let dateString = year + '-' + month + '-' + day;
    // let event = new Date(dateString);
    // event.setDate(day-1);
    // console.log(event.getFullYear()+`-` + (Number(event.getMonth()) + 1)+ '-' + event.getDate());