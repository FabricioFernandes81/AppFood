import { requestTypes } from "../_actions/types/requestsType";


const inictialState = {
    categoryform: 
       {
            categoryId: null,
            name: "",
            description: "",
            type: "",
            itemCount: 0,
            hasViolations: false,
            canEdit: true,
            status: "",
            items: null,
            available: true
   },
    loading: false,
    error:null,
    successMessage:null,
}

export function FormCategoria( state = inictialState, action){
    switch (action.type) {
       case requestTypes.APICATEGORYBYID_REQUEST:
        return{
            ...state,
            loading:true,
            error:null,
        }
        case requestTypes.APICATEGORYBYID_SUCCESS:
        return{
            ...state,
            loading:false,
            error:null,
            categoryform: action.payload,
        }
        case requestTypes.APICATEGORYBYID_FAILURE:
            return{
                ...state,
                loading:false,
                error:action.payload,
            }
        case requestTypes.UPDATE_FORM_FIELD:
            return{
                ...state,
                categoryform:{
                        ...state.categoryform,
                        [action.payload.field]:action.payload.value,
                }
            }

        case requestTypes.SUBMIT_CATEGORY_REQUEST:
            return{
                ...state,
                loading:false,
                successMessage:null,
                error:null,
            }

        case requestTypes.SUBMIT_ADDRESS_SUCCESS:
            return{
                ...state,
                loading:false,
                successMessage:action.payload.message,
                error:null,
            }
        case requestTypes.SUBMIT_CATEGORY_FAILURE:
            return{
                ...state,
                loading:false,
                error:action.payload,
            }

        
        default:
            return state;
    }
}