
export function authHeader () {
    // return authorization header with jwt token
    let user = localStorage.getItem('access_token');
    if (user && user) {
        return { 'Authorization': 'Bearer ' + user};
    } else {
        return {};
    }
} 

export default authHeader