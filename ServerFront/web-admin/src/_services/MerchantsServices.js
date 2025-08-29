import authHeader from "../_helpers/authHeader";
import handleResponse from "../_helpers/HandleResponse";

const MERCHANTS_SERVER_URL = 'https://localhost:7144'; // Ajuste conforme necessário

class MerchantsService {
  constructor() {}

  async getAllMerchants() {
    try {
      const requestOptions = {
        method: 'GET',
      //  headers: authHeader()
      };
      const response = await fetch(
        `${MERCHANTS_SERVER_URL}/api/Merchant`,
        requestOptions
      );
      
  
      return handleResponse(response);
    } catch (error) {
      throw error;
    }
  }

   async GetByIdMerchants(merchantId){
      const requestOptions = {
        method: 'GET',
      //  headers: authHeader()
      };
       const response = await fetch(
        `${MERCHANTS_SERVER_URL}/api/Merchant/${merchantId}`,
        requestOptions
      );
      
  
      return handleResponse(response);
    
   }
  // nova função aqui https://localhost:7144/api/Merchant/b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d/address
   async GetAddress(merchantId){
    const requestOptions = {
        method: 'GET',
       // headers: authHeader()
      };
       const response = await fetch(
        `${MERCHANTS_SERVER_URL}/api/Address/${merchantId}/address`,
        requestOptions
      );
      return handleResponse(response);
   }

   //Nova Função 

   async PatchMechats(merchantsId,formData){
    const requestOptions = {
        method: 'PATCH',
        headers: {
         //   ...authHeader(),
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(formData),
    }  
    const response = await fetch(
        `${MERCHANTS_SERVER_URL}/api/Merchant/${merchantsId}`,
        requestOptions)

      return handleResponse(response);
    
    }
    async PatchAddress (merchantId, formData){
      ///api/Address/{merchantId}/address
      const requestOptions = {
        method: 'PATCH',
        headers: {
         //   ...authHeader(),
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(formData),
    }  
    const response = await fetch(
        `${MERCHANTS_SERVER_URL}/api/Address/${merchantId}/address`,
        requestOptions)

      return handleResponse(response);
    }
}

const merchantsService = new MerchantsService();
export default merchantsService;