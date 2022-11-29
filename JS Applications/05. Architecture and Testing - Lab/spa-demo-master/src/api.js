const host = 'http://localhost:3030';

    async function request(method, url, data) {

    const options = {
        method,
        headers: {},
        body: JSON.stringify(data)
    };

    //Cheking if data is available
    if (data !== undefined) {
        options.headers['Content-Type'] = 'application/json';
        options.body = JSON.stringify(data);
    }

    //Checking if the user is logged!!!
    const userData = JSON.parse(sessionStorage.getItem('userData'));
    if (userData != null) {
        options.headers['X-Authorization'] = userData.accessToken;
    }


    //Connect with server! 
    try {
        const res = await fetch(host + url, options);

        if (res.ok == false) {
            const error = await res.json();
            throw new Error(error.message);
        }
        if(res.status == 204){
            return res;
        } else {  
            const result = await res.json();
            return result;
        }
      

    } catch (err) {
        alert(err.message);
        throw err;
    }
}

export async function get(url) {
    return request('get', url);
}
export async function post(url, data) {
    return request('post', url, data);
}