import { requestTypes } from "./types/requestsType";
import cardapioService from "../_services/CardapioService";

export const fetchCategoriaRequest =()=>{
return {
    type:requestTypes.APICATEGORY_SUCCESS,
 }
}

export const fetchCategoriaSuccess =(payload)=>{
return {
    type:requestTypes.APICATEGORY_SUCCESS,
    payload:payload,
 }
}

export const fetchCategoriaFailure =(error)=>{
 return {
    type:requestTypes.APICATEGORY_FAILURE,
    payload:error,
 }
}


export const LoadingCategory = (merchantId) => {
    return async (dispatch) => {
        dispatch(fetchCategoriaRequest());
        cardapioService.GetCategory(merchantId).then(categ=>{
            dispatch(fetchCategoriaSuccess(categ));
        }).catch(error=>{
            dispatch(fetchCategoriaFailure(error));
        })
    }
}