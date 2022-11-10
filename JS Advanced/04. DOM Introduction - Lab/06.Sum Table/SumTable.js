function sumTable() {
let costElements = document.querySelectorAll('tr td:nth-of-type(2)')
   
let arr = Array.from(costElements); 
let lastElement2 = arr.pop(); 
lastElement2.textContent = arr.reduce((a,x) => {  
    return a + Number(x.textContent); 
}, 0);     
} 
