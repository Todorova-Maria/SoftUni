import {html,render} from '../node_modules/lit-html/lit-html.js' 

const button = document.getElementById('btnLoadTowns'); 
button.addEventListener('click', loadTowns);  
 
const htmlText = (towns) => html` 
<ul> 
${towns.map(town => html`<li>${town}</li>`)}
</ul>`

function loadTowns(event) {  
  
event.preventDefault(); 
const towns = document.getElementById('towns').value.split(', ');   

if(towns != '') {
    const root = document.getElementById('root');
    render(htmlText(towns), root); 
    document.getElementById('towns').value = '';
}
}