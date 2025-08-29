import { requestTypes } from "./types/requestsType";
import merchantsService from "../_services/MerchantsServices";


export const fetchMerchantsRequest = ()=>({
    type:requestTypes.FETCH_PROFILE_REQUEST
})

export const fetchProfileSuccess = (profile) => {
    return {
        type:requestTypes.FETCH_PROFILE_SUCCESS,
        payload: profile,
    }
}

export const fetchProfileFailure = (error) => {
  return{
    type: requestTypes.FETCH_PROFILE_FAILURE,
    payload: error,
  }
};

export const UpdateFormField = (field,value) =>{
    return{
    type: requestTypes.UPDATE_FORM_FIELD,
    payload: {field,value},
    }
}

export const submitProfileRequest =() =>{
    return {
        type:requestTypes.SUBMIT_PROFILE_REQUEST,

    }
}
    export const submitMerchantSuccess=(response)=>{
        return {
            type: requestTypes.FETCH_PROFILE_SUCCESS,
            payload: response,

        }
    }
    export const submitMerchantFailure =(error) =>{
        return{
            type:requestTypes.SUBMIT_PROFILE_FAILURE,
            payload: error,
        }
    }
    export const updateImageField = (field,file,previewUrl) => {
        console.log("Imagens", field);
        return{
            type: requestTypes.UPDATE_IMAGE_FIELD,
             payload: {field,file,previewUrl}
        }
    }
    
export const loadingMerchant  = (merchantId) => {

     return async (dispatch) => {
       
        dispatch(fetchMerchantsRequest()); 
    
        try {
            const merchants = await merchantsService.GetByIdMerchants(merchantId);
        //    console.log("API MerchantsID: ",merchants)
            dispatch(fetchProfileSuccess(merchants));
        } catch (error) {
            dispatch(fetchProfileFailure(error.message || 'Erro ao Carregar a Loja (loadingMerchant)'));
        }
    } 
}

export const submitMerchants = (merchantsData, coverFile, logoFile) => {
    return async (dispatch) =>{
           dispatch(fetchMerchantsRequest);
           try {
            const dataForm = {...merchantsData};
            if(coverFile){
             //   const coverImageURL = await 
            }
            if (coverFile){

            }
            const response = await merchantsService.PatchMechats(dataForm.id, dataForm);
            if (!response) {
                 throw new Error('Resposta da API inválida.');
            }
                dispatch(submitMerchantSuccess({
                message: 'Perfil salvo com sucesso!',
                updatedData: response,
            }));

           } catch (error) {
            dispatch(submitMerchantFailure(error.message || "Erro ao Salvar o Merchants"))
           }
    }
}

