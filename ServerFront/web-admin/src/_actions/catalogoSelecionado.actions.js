import { requestTypes } from "./types/requestsType";

export const selectCatalog = (catalogId)=>({
        type: requestTypes.SELECT_CATALOG,
        payload: catalogId,
})

export const deselectCatalog = (catalogId) => ({
  type: requestTypes.DESELECT_CATALOG,
  payload: catalogId
});


export const clearSelectedCatalogs = () => ({
  type: requestTypes.CLEAR_SELECTED_CATALOGS
});