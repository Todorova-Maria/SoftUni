
async function solve() {
    const url = 'http://localhost:3030/jsonstore/collections/students';
    const table = document.querySelector('#results tbody');
    const res = await fetch(url);
    const data = await res.json();

    Object.values(data).forEach(s => {
        const firstName = s.firstName;
        const lastName = s.lastName;
        const facultyNumber = s.facultyNumber;
        const grade = Number(s.grade);

        const tr = document.createElement('tr');   

 
        //Added cells 
        const firstNameCell = tr.insertCell(0);
        firstNameCell.innerText = firstName;

        const lastNameCell = tr.insertCell(1);
        lastNameCell.innerText = lastName;

        const facultyNumberCell = tr.insertCell(2);
        facultyNumberCell.innerText = facultyNumber;

        const gradeCell = tr.insertCell(3);
        gradeCell.innerText = grade; 

        //Create Delete Button 
        const DeleteBtn = document.createElement('button'); 
        DeleteBtn.innerText = 'delete';  
        DeleteBtn.style.width = '100%'; 
        DeleteBtn.style.color = 'red';
        const deleteButtonCell = tr.insertCell(4); 
        deleteButtonCell.appendChild(DeleteBtn); 
         
        DeleteBtn.addEventListener('click', async (e) => { 
            const id = e.target.parentNode.parentNode.id;  
            e.target.parentNode.parentNode.remove(); 

            const DeleteResponse = await fetch(`${url}/${id}`, { 
                method: 'Delete'
            })
        })
        
        table.appendChild(tr);

    });

    const submitButton = document.getElementById('submit');
    submitButton.addEventListener('click', onClickSubmit);

 
    // Click sumbit button
 async function onClickSubmit(e) {
    e.preventDefault();
    const firstNameElement = document.getElementsByName('firstName')[0];
    const lastNameElement = document.getElementsByName('lastName')[0];
    const facultyNumberElement = document.getElementsByName('facultyNumber')[0];
    const gradeElement = document.getElementsByName('grade')[0];
     
    //Check if faculty and grade are numbers
    if (isNaN(gradeElement.value)) {
        return alert('Wrong grade data!');
    }
 
    //Check for empty fields 
    if (firstNameElement.value !== '' && lastNameElement.value !== '' &&
        facultyNumberElement.value !== '' && gradeElement.value !== '') {
     
            // POST Query
        const res = await fetch(url, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                firstName: firstNameElement.value,
                lastName: lastNameElement.value,
                facultyNumber: Number(facultyNumberElement.value),
                grade: Number(gradeElement.value),
            })
        })
         
        // Added cells
        const tr = document.createElement('tr');

        const firstNameCell = tr.insertCell(0);
        firstNameCell.innerText = firstNameElement.value;

        const lastNameCell = tr.insertCell(1);
        lastNameCell.innerText = lastNameElement.value;

        const facultyNumberCell = tr.insertCell(2);
        facultyNumberCell.innerText = facultyNumberElement.value;

        const gradeCell = tr.insertCell(3);
        gradeCell.innerText = gradeElement.value;

        table.appendChild(tr);
    }   

    firstNameElement.value = ''; 
    lastNameElement.value = ''; 
    facultyNumberElement.value = ''; 
    gradeElement.value = '';
}
}
solve(); 
