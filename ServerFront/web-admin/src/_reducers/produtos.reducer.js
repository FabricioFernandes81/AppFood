import { requestTypes } from "../_actions/types/requestsType";

const inictialState = {
    products:[],
    loading: false,
    error:null,
    successMensage: null,
}


export function ProductsReduce (state = inictialState, action){
    switch (action.type) {
        case requestTypes.APIPRODUCT_REQUEST:
        return{    
        ...state,
        loading:true,
        error:null,
        }
            case requestTypes.APIPRODUCT_SUCCESS:
                return {
                    ...state,
                    loading:false,
                    products: action.payload
                }
                case requestTypes.APIPRODUCT_FAILED:
                    return{
                        ...state,
                        loading:false,
                        error:action.payload
                    }
        default:
            return state;
    }
}