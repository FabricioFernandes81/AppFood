import { requestTypes } from "./types/requestsType";
import cardapioService from "../_services/CardapioService";



export const fetchCardapioRequest = ()=>{
    return {
        type:requestTypes.APIMENU_REQUEST
    }
}
export const fetchCadapioSuccess = (payload) =>
{
    return {
        type:requestTypes.APIMENU_SUCCESS,
        payload: payload,
    }
}

export const fetchCatdapioFailure =(error)=>{
    return{
        type:requestTypes.APIMENU_FAILURE,
        payload:error,
    }
}

export const fetchProdutoRequest = ()=>{
    return{
        type:requestTypes.APIPRODUCT_REQUEST,

    }
}
export const fetchProdutoSuccess = (payload) => {
    return{
        type:requestTypes.APIPRODUCT_SUCCESS,
        payload:payload,
    }
}
export const fetchProdutoFailed = (error)=>{
    return{
        type:requestTypes.APIPRODUCT_FAILED,
        payload: error,
    }
}

export const LoadingCardapio = (merchantsId) =>{
    return async (dispatch)=>{
       dispatch(fetchCardapioRequest());
       cardapioService.GetCatalog(merchantsId).then(catalog=>{
      
        dispatch(fetchCadapioSuccess(catalog));
       }).catch(error=>{
        dispatch(fetchCatdapioFailure(error));
       })
    }
}

export const LoadingProduto = (merchantsId) => {
    return async (dispatch)=>{
        dispatch(fetchProdutoRequest());
        cardapioService.GetProdutos(merchantsId).then(result=>{
                dispatch(fetchProdutoSuccess(result));
        }).catch(error=>{
            dispatch(fetchProdutoFailed("Error API Produtos"))
        })

    }
}