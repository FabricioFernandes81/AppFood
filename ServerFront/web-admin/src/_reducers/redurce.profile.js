import { error } from "ajv/dist/vocabularies/applicator/dependencies"
import { requestTypes } from "../_actions/types/requestsType"

const initialState = {
 data: {
        id: null,
        uuid: null,
        name: '',
        email: "",
        address: "",
        complement: '',
        shortAddress: "",
        deliveryPhone: "",
        ownerPhone: "",
        minimumOrderValue :{
            currency:'',
            value:'',
        },
        location: {
            latitude: '',
            longitude: '',
        },
        description: "",

        logo: null, 
        cover: null, 
        country: '',
        state: "",
        city: "",
        district: "",
  
        mainCuisine: "",
        type: "",
    },

    imageFiles: {
        logoFile: null,  
        coverFile: null, 
    },
    loading: false,
    error: null,
    successMessage: null,

}

export function FormProfile(state = initialState, action) {

    switch (action.type) {
        case requestTypes.FETCH_PROFILE_REQUEST:
        case requestTypes.SUBMIT_PROFILE_REQUEST:
            return {
                ...state,
                loading: true,
                error: null,
                successMessage: null,

            }
        case requestTypes.FETCH_PROFILE_SUCCESS:
            return {

                ...state,
                loading: false,
                //data:action.payload,
                data: {  
                   
                    ...initialState.data,
                    ...action.payload,
                    logo: action.payload.logo || null,
                    cover: action.payload.cover || null,
                },
                imageFiles: {
                    logoFile: null,
                    coverFile: null,
                },
                error: null,
            }
        case requestTypes.FETCH_PROFILE_FAILURE:
            return {
                ...state,
                loading: false,
                error: action.payload,
            }


        case requestTypes.UPDATE_FORM_FIELD:
            return {
                ...state,
                data: {
                    ...state.data,
                    [action.payload.field]: action.payload.value,
                },
                error: null,
                successMessage: null,
            }
        case requestTypes.SUBMIT_PROFILE_SUCCESS:
           return {
                ...state,
                loading: false,
                successMessage: action.payload.message,
                error: null,
                imageFiles: { 
                    logoFile: null,
                    coverFile: null,
                },
                data: {
                    ...state.data,
                    logo: action.payload.updatedData?.logo || state.data.logo,
                    cover: action.payload.updatedData?.cover || state.data.cover,
                }

            
           }
        case requestTypes.SUBMIT_PROFILE_FAILURE:
            return {
                ...state,
                loading: false,
                error: action.payload,
            }

         case requestTypes.UPDATE_IMAGE_FIELD:
            return {
                ...state,
                data: {
                     
                    ...state.data,
                   [action.payload.field]: action.payload.previewUrl,
                },
                imageFiles: {
                    ...state.imageFiles,
                    
                    [`${action.payload.field}File`]: action.payload.file,
                },
                error: null,
                successMessage: null,
            }
        default:
            return state;
    }

}