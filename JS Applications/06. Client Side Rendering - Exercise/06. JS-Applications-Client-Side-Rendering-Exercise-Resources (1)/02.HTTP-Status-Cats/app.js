import { html, render } from '../node_modules/lit-html/lit-html.js';
import { cats } from './catSeeder.js';
 
// Visualizing cats 
const htmlText = (data) => html` 
<ul> 
${data.map(cat => html 
    `<li>   
    <img src="./images/${cat.imageLocation}.jpg" width="250" height="250" alt="Card image cap">
        <div class="info">
            <button class="showBtn">Show status code</button>
             <div class="status" style="display: none" id=${cat.id}>
             <h4>Status Code: ${cat.statusCode}</h4>
             <p>${cat.statusMessage}</p>
            </div>
        </div> 
    </li>`)}
</ul>` 
const root = document.getElementById('allCats'); 
render(htmlText(cats), root);
 
root.addEventListener('click', toggle); 
 
// Show and hide status of the cat
function toggle(event) { 
 
    if(event.target.tagName == 'BUTTON') { 
        
        const statusClass = event.target.parentNode.querySelector('.status'); 
         
        if(statusClass.style.display == 'none') { 
            statusClass.style.display = 'block'; 
            event.target.textContent = 'Hide status code'; 
        } 
        else { 
            statusClass.style.display = 'none'; 
            event.target.textContent = 'Show status code'; 
        }
    }
}
