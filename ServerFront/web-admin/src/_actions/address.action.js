import { requestTypes } from "./types/requestsType";
import merchantsService from "../_services/MerchantsServices";

export const fetchAddressRequest =()=> ({
  type: requestTypes.FETCH_ADDRESS_REQUEST,
})
export const fetchAddressSuccess =(address)=>({
    type:requestTypes.FETCH_ADDRESS_SUCCESS,
    payload: address,
}) 

export const fetchAddressFailure = (error)=> ({
    type: requestTypes.FETCH_ADDRESS_FAILURE,
    payload: error,
})
export const updateFormField =(field, value)=>({
    type: requestTypes.UPDATE_FORM_FIELD,
    payload:{field,value},
})

export const resetFrom = ()=> ({
    type:requestTypes.RESET_FORM,
})

export const submitAddressRequest = () => ({
    type:requestTypes.SUBMIT_ADDRESS_REQUEST,
})
export const submitAddressSucess = (response) =>({
    type: requestTypes.SUBMIT_ADDRESS_SUCCESS,
    payload:response,
})

export const submitAdrressFailure = (error) => ({
    type: requestTypes.SUBMIT_ADDRESS_FAILURE,
    payload:error,
})

//Carregar Dados do Perfil

export const loadAddress = (merchantId) => {
    return async (dispatch) => {
            dispatch(fetchAddressRequest());
            try {
                const address = await  merchantsService.GetAddress(merchantId);
                dispatch(fetchAddressSuccess(address));  
            } catch (error) {
                dispatch(fetchAddressFailure(error.message || 'Erro ao Carregar'));
            }
    } 


}


export const submitAddress= (merchantId, addressData)=> {

    return async (dispatch)=>{
        dispatch(submitAddressRequest);
       
        merchantsService.PatchAddress(merchantId,addressData).then(result=>{
                dispatch(submitAddressSucess(result));
                //dispatch de alerta de sucesso!!!
        }).catch(error=>{
          dispatch(submitAdrressFailure(error));   
        })
       
    }
}