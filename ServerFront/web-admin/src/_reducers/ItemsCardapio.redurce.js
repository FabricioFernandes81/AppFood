import { error } from "ajv/dist/vocabularies/applicator/dependencies";
import { requestTypes } from "../_actions/types/requestsType";
import { Items } from "../_components/Items";


const inictialState ={
     normalItems: {},
     pizzaItems:{},

   loading:false,
   error: null,
   successMessage:null,
};


export function ItemsRedurce (state = inictialState , action){
   switch (action.type) {
    case requestTypes.APIITEM_REQUEST:
        return{
            ...state,
            loading: true,
            error:null,
        }
        case requestTypes.APIITEM_SUCCESS:
       const { categoryId,items } = action.payload;
     
       const normalItemsForCategory = [];
       const pizzaItemsForCategory = [];
                    items.rows.forEach(item=>{
                        if(item.type === "DEFAULT"){
                        normalItemsForCategory.push(item);
                        }else if (item.type === "PIZZA"){
                            pizzaItemsForCategory.push(item)
                        }
                    })
 
       return {
        ...state,
        loading: false,
        error: null,
        successMessage: 'Itens carregados com sucesso',
        //Items: action.payload,
        normalItems: {
          ...state.normalItems,
           [categoryId]:{
            ...items,
            rows:normalItemsForCategory,
           }
        },pizzaItems:{
            ...state.pizzaItems,
            [categoryId]:{
                ...items,
                rows:pizzaItemsForCategory, 
            }
        }
      };
 
                case requestTypes.APIITEM_FAILURE:
                    return{
                        ...state,
                        loading:false,
                        error:action.payload,
                        Items: null,
                    }
    default:
        return state
   }
}