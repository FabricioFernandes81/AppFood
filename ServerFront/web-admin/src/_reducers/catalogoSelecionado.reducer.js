import { requestTypes } from "../_actions/types/requestsType";



const initialState ={
    selectedCatalogs: []
}


export const catalogoSelecionadoReducer = (state = initialState, action) =>{
   switch (action.type) {
    case requestTypes.SELECT_CATALOG:
        if (state.selectedCatalogs.includes(action.payload)){
            return state;
        }
       return {
        ...state,
        selectedCatalogs: [...state.selectedCatalogs, action.payload]
      };

        case requestTypes.DESELECT_CATALOG:
            return{
                ...state,
                selectedCatalogs: state.selectedCatalogs.filter(id=> id!== action.payload)
            }

            case  requestTypes.CLEAR_SELECTED_CATALOGS:
                return{
                    ...state,
                    selectedCatalogs:[]
                };
   
    default:
        return state;
   } 
}