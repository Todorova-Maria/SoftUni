export function createRouter(main, vies) {
    window.addEventListener('hashchange', onChange); 
    return onChange; 
    function onChange() {

        const name = window.location.hash;
        const view = views[name]; 

        if(typeof view == 'function') {
            main.innerHTML = view(); 
        }
    }
}