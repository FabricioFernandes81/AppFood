import { requestTypes } from "./types/requestsType";
//import { Postlogin } from "../_services/UserServices";
import authServiceROPC from '../_services/UserServices';
import { history } from "../_helpers/history";
export const login = (formData) => {

 //history.navigate("/home");
   return async (dispatch) =>{
        dispatch(request(formData));
         try {
            const tokenData = await authServiceROPC.Postlogin(formData.username, formData.password);
            dispatch(sucess({
                accessToken: tokenData.access_token,
                refreshToken: tokenData.refresh_token,
                idToken: tokenData.id_token,
                profile: tokenData.profile
            }));
            return tokenData;
        } catch (error) {
            dispatch(failure(error.message || 'Erro desconhecido ao fazer login.'));
            throw error;
        }
   }

    function request(payload){
        return {
            type: requestTypes.LOGIN_REQUEST,
            payload
        }
    }
    function sucess(payload){
        return {
            type: requestTypes.LOGIN_SUCCESS,
            payload
        }
    }
     function failure(error) { 
        return { 
            type: requestTypes.LOGIN_FAILURE, 
            error 
        } 
      }


}

export const startLogout = () => {
    return async (dispatch) => {
        try {
            await authServiceROPC.logout();
            dispatch(logoutSuccess());
        } catch (error) {
            console.error('Erro durante o logout:', error);
        }
    }

 function logoutSuccess () {
    return{
    type: requestTypes.LOGIN_LOGOUT,
    }
}   
}

export const setInitialAuthState = (authState) => ({
    type: requestTypes.SET_INITIAL_AUTH_STATE,
    payload: authState,
});

export const initializeAuth = () => {
    return (dispatch) => {
        const accessToken = authServiceROPC.getAccessToken();
        const refreshToken = authServiceROPC.getRefreshToken();
        const idToken = authServiceROPC.getIdToken();
        const userProfile = authServiceROPC.getUserProfile();

        const isAuthenticated = authServiceROPC.isAuthenticated();

        dispatch(setInitialAuthState({
            isAuthenticated,
            user: userProfile,
            accessToken,
            refreshToken,
            idToken,
        }));
    };
};