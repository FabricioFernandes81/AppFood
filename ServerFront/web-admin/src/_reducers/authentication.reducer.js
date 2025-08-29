import { requestTypes } from "../_actions/types/requestsType";

const initialState = {
    isAuthenticated: false,
    loading: false,
    user: null,
    accessToken: null,
    refreshToken: null,
    idToken: null,
    error: null,
};

export function Authenticacao(state = initialState, action){
    switch (action.type) {
        case requestTypes.LOGIN_REQUEST:
            return{
                 ...state,
                loading: true,
                error: null,
            }
        case requestTypes.LOGIN_SUCCESS:
            return{
                 ...state,
                isAuthenticated: true,
                loading: false,
                user: action.payload.profile,
                accessToken: action.payload.accessToken,
                refreshToken: action.payload.refreshToken,
                idToken: action.payload.idToken,
                error: null,
            }
        case requestTypes.LOGIN_FAILURE:
            return{
                 ...state,
                isAuthenticated: false,
                loading: false,
                user: null,
                accessToken: null,
                refreshToken: null,
                idToken: null,
                error: action.payload,
            };
        
        case requestTypes.LOGIN_LOGOUT:
            return{
                ...initialState,
            };
            case requestTypes.SET_INITIAL_AUTH_STATE:
            return {
                ...state,
                isAuthenticated: action.payload.isAuthenticated,
                user: action.payload.user,
                accessToken: action.payload.accessToken,
                refreshToken: action.payload.refreshToken,
                idToken: action.payload.idToken,
                loading: false, // O estado inicial não está carregando
            };    
        default:
            return state;
    }
}
