import { requestTypes } from "./types/requestsType";
import cardapioService from "../_services/CardapioService";


export const fetchItemsRequest =()=>{
    return{
        type:requestTypes.APIITEM_REQUEST
    }
}

export const fetchItemsSuccess =(payload,categoryId)=>{
    return{
        type:requestTypes.APIITEM_SUCCESS,
        payload: {
            categoryId : categoryId,
            items:payload,
        },
    }
}

export const fetchItemsFailed =(error)=>{
    return{
        type:requestTypes.APIITEM_FAILURE,
        payload:error,
    }
}

export const LoadingItems = (merchantsId,categorgyId) =>{
    return async(dispatch) => {
        dispatch(fetchItemsRequest);
        cardapioService.GetItems(merchantsId,categorgyId).then(result=>{
            dispatch(fetchItemsSuccess(result,categorgyId));
           // console.log("Item", result);
        }).catch(error=>{
            dispatch(fetchItemsFailed(error));
        })
    }
}