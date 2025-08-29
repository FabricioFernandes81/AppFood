import { requestTypes } from "./types/requestsType";
import merchantsService from "../_services/MerchantsServices";
export const GetMerchants = () => {

    return async (dispatch) => {

        dispatch(request());
    try {
        const merchants = await merchantsService.getAllMerchants();
       // console.log("API Merchants: ",merchants)
        dispatch(success(merchants));
        if(merchants.length === 1){
            dispatch({
            type: requestTypes.MERCHANTS_SELECT,
            payload: merchants[0],
        })
        }

    } catch (error) {
        throw new Error("Merchants");
    }

    }
    

    
    function request(){
        return {
            type: requestTypes.MERCHANTS_REQUEST,
            
        }

    }
    function success(payload){
        return {
            type:requestTypes.MERCHANTS_SUCCESS,
            payload,
        }
    }
}

export const setSelectedMerchant = (merchant) => {

    console.log("Selecionado: ", merchant)
    return (dispatch) => {
            dispatch({
                type: requestTypes.MERCHANTS_SELECT,
                payload:merchant
            })
}

}

export const GetProfile = (merchatId) => 
    {

 return async (dispatch) => 
    {
        dispatch(request());

        try {
                const merchants = await merchantsService.GetByIdMerchants(merchatId);
                dispatch(success(merchants));
            
        } catch (error) {
            throw new Error("ERRo");
            
        }

    }  

        function request(){
        return {
            type: requestTypes.APIPERFIL_REQUEST,
            
        }

    }
    function success(payload){
        return {
            type:requestTypes.APIPERFIL_SUCCESS,
            payload,
        }
    }
}
    