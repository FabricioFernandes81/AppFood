import { requestTypes } from "./types/requestsType";
import cardapioService from "../_services/CardapioService";


export const fetCategoryRequest = () => ({
    type: requestTypes.APICATEGORYBYID_REQUEST
})

export const fetchCategorySuccess =(response) => {
    return{
    type:requestTypes.APICATEGORYBYID_SUCCESS,
    payload: response,
}}
export const fetchCategoryFailure = (error) => {
  return{
    type: requestTypes.APICATEGORYBYID_FAILURE,
    payload: error,
  }
};

export const UpdateFormField = (field,value) =>{
    return{
    type: requestTypes.UPDATE_FORM_FIELD,
    payload: {field,value},
    }
}
export const submitCategoryRequest =() =>{
    return {
        type:requestTypes.SUBMIT_CATEGORY_REQUEST,

    }
}
    export const submitCategorySuccess=(response)=>{
        return {
            type: requestTypes.SUBMIT_CATEGORY_SUCCESS,
            payload: response,

        }
    }

export const submitCategoryFailed=(error)=>{
        return {
            type: requestTypes.SUBMIT_CATEGORY_FAILURE,
            payload: error,

        }
    }

export const loadingCategoryId = (merchantId, categoryId) =>{
    return async (dispatch)=> {
        dispatch(fetCategoryRequest());

        cardapioService.GetCategoryById(categoryId,merchantId).then(result=>{
            dispatch(fetchCategorySuccess(result));
        }).catch(error=>{
            dispatch(fetchCategoryFailure(error.message || "Erro ao carregar Api Category ById"))            
            
        })
      
    }
}

export const submitCategory =(merchantId,category)=>{
    return async(dispatch)=>{
        dispatch(submitCategoryRequest());
        cardapioService.CreateCategory(merchantId, category).then(result=>{
            dispatch(submitCategorySuccess(result));
        }).catch(error=>{
           dispatch(submitCategoryFailed(error.message || "Erro ao Salvar a Categoria"))
        })
    }
} 

export const submitEditCategory =(category)=>{
    return async(dispatch)=>{
        dispatch(submitCategoryRequest());
        console.log("Submit Add: ", category)
    }
} 