import { requestTypes } from "../_actions/types/requestsType";


const initialState = {
   loading: false,
   merchants:null,
   error:null,
}

export function MerchantsProfile(state = initialState, action){
    switch (action.type) {
        case requestTypes.APIPERFIL_REQUEST:
            return{
                loading:true,
                error:null,
            }
        case requestTypes.APIPERFIL_SUCCESS:
            return{
                ...state,
                merchants: action.payload,
                error:null,
            }
            case requestTypes.APIPERFIL_FAILURE:
                return{
                    loading: false,
                    error: action.payload,
                }
        default:
            return state;
    }
}