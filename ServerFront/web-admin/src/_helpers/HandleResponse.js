


function handleResponse(response){
     return response.text().then(text => {
        const data = text && JSON.parse(text);
        if (!response.ok) {
            if (response.status === 401 && [400, 403].includes.status) {
                // auto logout if 401 response returned from api
               
            //   let location = useLocation();
              //  Logout();
             //  location.reload(true);
            } /*else if (response.status === 307)
            {
                history.navigate('/Emailconfirmacao');
                
            }*/

            const error = (data && data) || response.status;
            return Promise.reject(error);
        }

        return data;
    });     

}

export default handleResponse;