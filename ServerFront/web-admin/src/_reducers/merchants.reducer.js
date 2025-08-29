import { requestTypes } from "../_actions/types/requestsType";


const initialState = {
 loading: false,
    merchants: [],
    selectedMerchant: null,


    error: null,

}


export function Merchants(state = initialState, action){
    switch (action.type) {
        case requestTypes.MERCHANTS_REQUEST:
            return{
                loading: true,
                error: null,
            }
            case requestTypes.MERCHANTS_SUCCESS: 
                return {
                    ...state,
                    merchants: action.payload,
                    error:null
                }

            case requestTypes.MERCHANTS_SELECT:
                return {
                  ...state,
                 selectedMerchant: action.payload,


                }
            
    
        default:
            return state;
    }
}

