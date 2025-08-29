import { requestTypes } from "../_actions/types/requestsType";



const initialState = {
        data:{
           // merchantsId: null,
            zipCode:'',
            streetNumber: '',
            address: '',
            complement:	'',
            district:'',
            city:'',
            state:'',
            country:'',
            reference:'',
            latitude: '',
            longitude: ''
        },
        loading:false,
        error: null,
        successMessage: null,
}


export function FormAddresss (state = initialState, action) {

    switch (action.type) {
        case requestTypes.FETCH_ADDRESS_REQUEST:
          return{}    
        case requestTypes.SUBMIT_ADDRESS_REQUEST:
            return{
                ...state,
                loading: true,
                error: null,
                successMessage:null,
            }
        case requestTypes.FETCH_ADDRESS_SUCCESS:
                return{
                    ...state,
                    loading:false,
                    error:null,
                    data:{
                        ...initialState.data,
                        ...action.payload,
                    }
                }
                case requestTypes.FETCH_ADDRESS_FAILURE:
                    return{
                        ...state,
                        loading:false,
                        error:action.payload,
                    };
                case requestTypes.UPDATE_FORM_FIELD:
                    return {
                        ...state,
                        data:{
                            ...state.data,
                            [action.payload.field]: action.payload.value,
                        },
                        error: null,
                        successMessage: null,
                    }

                case requestTypes.RESET_FORM:
                    return{
                        ...initialState,
                    }
                    case requestTypes.SUBMIT_ADDRESS_SUCCESS:
                        return{
                            ...state,
                            loading: false,
                            successMessage: action.payload.message,
                            error:null,
                        }

                        case requestTypes.SUBMIT_ADDRESS_FAILURE:
                            return{
                                ...state,
                                loading: false,
                                error: action.payload,
                            }

                            
                        default:
                            return state;
    }

}

