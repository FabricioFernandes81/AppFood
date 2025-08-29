import { requestTypes } from "../_actions/types/requestsType";

const inictialState = {
    category:[],
    loading: false,
    error: null,
    successMenssage: null,
};


export function CategoriaList(state = inictialState, action){

   switch (action.type) {
    case requestTypes.APICATEGORY_REQUEST:
      return{
        ...state,
        loading: true,
        error: null,
        successMenssage: null,
      }
    case requestTypes.APICATEGORY_SUCCESS:
     return{
        ...state,
        loading:false,
        category: action.payload


     }
     case requestTypes.APICATEGORY_FAILURE:
        return{
            ...state,
            loading:false,
            error:action.payload,
        }
    default:
       return state;
   }


}