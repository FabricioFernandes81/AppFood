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
export const ItemsUpdateStatus = (payload)=> {
    return{
        type:requestTypes.APIITEM_STATUS,
        payload: payload,
   
    }
}

export const PizzaUpdateStatus =(payload)=>{
    return {
        type:requestTypes.APIPIZZA_STATUS,
        payload: payload,
        
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

export const UpdateStatusItem = (merchantId,payloadData) =>{

    return async(dispatch)=>{
          cardapioService.PutStatus(merchantId,payloadData).then(result=>{
             dispatch(ItemsUpdateStatus(payloadData));
         }).catch(error=>{
            console.log("Erro Api", error);
         });    
    
    }
}

export const UpdateStatusPizza = (merchantId,payloadSource) =>{
 return async(dispatch)=>{
   // dispatch(PizzaUpdateStatus(payloadSource));
    cardapioService.PutStatus(merchantId,payloadSource).then(result=>{
           dispatch(PizzaUpdateStatus(payloadSource));
        
         }).catch(error=>{
            console.log("Erro Api", error);
         });
    
 }
}