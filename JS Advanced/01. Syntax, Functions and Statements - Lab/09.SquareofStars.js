function solve (number = 5) {
    let star = '*'; 

    for(let i = 1; i < number; i++){
        star += ' *';
    }
    console.log(star);  
    for (let i = 1; i < number; i++)
    console.log(star); 
}

solve(); 

