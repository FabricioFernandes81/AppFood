import authHeader from "../_helpers/authHeader";
import handleResponse from "../_helpers/HandleResponse";

const CATALOGS_SERVER_URL = 'https://localhost:7060';

class CardapioService {


  async GetCatalog(merchantId) {
    const requestOptions = {
      method: 'GET',
      //  headers: authHeader()
    };
    try {
      const response = await fetch(`${CATALOGS_SERVER_URL}/merchants/${merchantId}/catalogs`, requestOptions);
      return handleResponse(response);

    } catch (error) {
      throw new error;
    }

  }

  async GetCategory(merchantId) {
    const requestOptions = {
      method: 'GET',
      //  headers: authHeader()
    };
    try {                                         ///merchants/{merchantId}/categories
      const response = await fetch(`${CATALOGS_SERVER_URL}/merchants/${merchantId}/categories`, requestOptions);
      return handleResponse(response);
    } catch (error) {
      throw new error;
    }
  }
  async GetCategoryById(categoryId, merchantId) {
    const requestOptions = {
      method: 'GET',
      //  headers: authHeader()
    };
    try {                                //   /api/Category/{categoryId}
      const response = await fetch(`${CATALOGS_SERVER_URL}/api/Category/${categoryId}?merchantId=${merchantId}`, requestOptions);
      return handleResponse(response);
    } catch (error) {
      throw new error;
    }
  }

  async CreateCategory(merchantId, bodyForm) {
    const requestOptions = {
      method: 'POST',
      headers: {
        // ...authHeader(),
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(bodyForm)
    };
    try {                                //   /merchants/{merchantId}/categories
      const response = await fetch(`${CATALOGS_SERVER_URL}/merchants/${merchantId}/categories`, requestOptions);
      return handleResponse(response);
    } catch (error) {
      throw new error;
    }

  };

   async GetProdutos(merchantId){
         const requestOptions = {
        method: 'GET',
      //  headers: authHeader()
      };
        try {                             // 'https://localhost:7060/api/Product?page=1&pageSize=10&ownerId=b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d'
            const response = await fetch( `${CATALOGS_SERVER_URL}/api/Product?page=1&pageSize=10&ownerId=${merchantId}`, requestOptions);
                return handleResponse(response);
            
        } catch (error) {
            throw new error;
        }

    }
  async GetItems(merchantId,CategoryId){
      const requestOptions = {
        method: 'GET',
      //  headers: authHeader()
      };
        try {                             // 'https://localhost:7060/category/a810a5a3-8d69-476f-96cd-12d268c1d847/items?ownerId=b1c8f3d2-4e5f-4b6a-9c7e-0d8f9a1b2c3d'
            const response = await fetch( `${CATALOGS_SERVER_URL}/category/${CategoryId}/items?ownerId=${merchantId}`, requestOptions);
                return handleResponse(response);
            
        } catch (error) {
            throw new error;
        }
  }
  async PutStatus(merchantId, payloadData){
  
    const requestOptions = {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json' 
        // ...authHeader(),
      },
      body: JSON.stringify(payloadData)
    };
  
    try {
                                  /// https://localhost:7060/api/Item?mercnhaId=11111111111
       const response = await fetch(`${CATALOGS_SERVER_URL}/api/Item?mercnhaId=${merchantId}`, requestOptions);
            return handleResponse(response);
    } catch (error) {
      throw new error;
      
    }

  }
}

const cardapioService = new CardapioService();
export default cardapioService;