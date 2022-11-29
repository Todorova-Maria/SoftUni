function notify(message) {
  let notification = document.getElementById('notification'); 
  notification.innerText = message; 

  notification.style.display = 'block'; 

  notification.addEventListener('click', hideTheDiv);

  function hideTheDiv() {
    notification.style.display = 'none';
  }
}