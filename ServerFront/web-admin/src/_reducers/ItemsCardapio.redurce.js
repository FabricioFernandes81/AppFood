/* eslint-disable no-case-declarations */
import { requestTypes } from "../_actions/types/requestsType";

const inictialState = {
  normalItems: {},
  pizzaItems: {},
  loading: false,
  error: null,
  successMessage: null,
};

export function ItemsRedurce(state = inictialState, action) {
  switch (action.type) {
    case requestTypes.APIITEM_REQUEST:
      return {
        ...state,
        loading: true,
        error: null,
      };

    case requestTypes.APIITEM_SUCCESS:
      const { categoryId, items } = action.payload;
      const normalItemsForCategory = items.rows.filter(item => item.type === "DEFAULT");
      const pizzaItemsForCategory = items.rows.filter(item => item.type === "PIZZA");

      return {
        ...state,
        loading: false,
        error: null,
        successMessage: 'Itens carregados com sucesso',
        normalItems: {
          ...state.normalItems,
          [categoryId]: {
            ...items,
            rows: normalItemsForCategory,
          }
        },
        pizzaItems: {
          ...state.pizzaItems,
          [categoryId]: {
            ...items,
            rows: pizzaItemsForCategory,
          }
        }
      };

    case requestTypes.APIITEM_FAILURE:
      return {
        ...state,
        loading: false,
        error: action.payload,
        Items: null,
      };

    case requestTypes.APIITEM_STATUS: {
      const { catalogItemId, status, statusByCatalog } = action.payload;

      const updatedNormalItems = Object.fromEntries(
        Object.entries(state.normalItems).map(([catId, categoryData]) => {
          const updatedRows = categoryData.rows.map(item =>
            item.id === catalogItemId ? { ...item, status, statusByCatalog } : item
          );
          return [catId, { ...categoryData, rows: updatedRows }];
        })
      );

      return {
        ...state,
        normalItems: updatedNormalItems,
        successMessage: 'Status do item atualizado com sucesso'
      };
    }

    case requestTypes.APIPIZZA_STATUS: {
     const { options } = action.payload;

    const updatedPizzaItems = Object.fromEntries(
        Object.entries(state.pizzaItems).map(([catId, categoryData]) => {
            const updatedRows = categoryData.rows.map((item) => {
                const updatedOptionGroups = item.optionGroup.map((group) => {
                    const updatedOptions = group.options.map((opt) => {
                        // Find the relevant options from the payload that match the current option's ID
                        const modifiersToUpdate = options.filter((o) => o.optionId === opt.id);

                        if (modifiersToUpdate.length > 0) {
                            
                            const updatedContextModifiers = opt.contextModifiers.map((modifier) => {
                                const payloadModifier = modifiersToUpdate.find((m) => m.parentOptionId === modifier.parentOptionId);
                                
                                if (payloadModifier) {
                             
                                    return {
                                        ...modifier,
                                        status: payloadModifier.status,
                                        statusByCatalog: payloadModifier.statusByCatalog
                                    };
                                }
                                return modifier;
                            });

                            return {
                                ...opt,
                                contextModifiers: updatedContextModifiers
                            };
                        }

                    
                        return opt;
                    });

                    return {
                        ...group,
                        options: updatedOptions
                    };
                });

                return {
                    ...item,
                    optionGroup: updatedOptionGroups
                };
            });

            return [catId, { ...categoryData, rows: updatedRows }];
        })
    );

    return {
        ...state,
        pizzaItems: updatedPizzaItems,
        successMessage: "Status da pizza atualizado com sucesso"
    };
    }

    default:
      return state;
  }
}