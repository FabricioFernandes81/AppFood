import { requestTypes } from "../_actions/types/requestsType";


const inictialState ={
   /*  data:{
        catalogId:'',
        ownerId:'',
        catalogName: '',
        catalogDescription:'',
        Status :'',
        catalogGroup:'',
        catalogType:'',
        available:'', 

    },*/
    catalogs:[],
    loading: false,
    error: null,
    successMessage: null,
}


export function MenuList (state = inictialState, action){
switch (action.type) {
   case requestTypes.APIMENU_REQUEST:
        return{
            ...state,
            loading: true,
            error:null,
            successMessage:null,
        }

    case requestTypes.APIMENU_SUCCESS: 
    return {
        ...state,
        loading: false,
        catalogs: action.payload,
        
    }
    case requestTypes.APIMENU_FAILURE:
        return {
            ...state,
            loading:false,
            error: action.payload,
        }

    default:
      return state;
}

}