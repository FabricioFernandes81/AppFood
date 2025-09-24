import React, { useState, useEffect } from 'react';
import { connect } from 'react-redux';
import { LoadingItems, UpdateStatusItem, UpdateStatusPizza } from '../_actions/Items.action';
import ItemsDefault from './ItemsDefault';
import ItemsPizza from './ItemsPizza';
import 'bootstrap/dist/js/bootstrap.bundle.min';


const Items = ({
  categoryId,
  merchantId,
  ItemNormal,
  ItemPizza,
  loading,
  dispatchLoadingItems, dispatchUpdateStatusItem, dispatchUpdateStatusPizza }) => {
  const [openItemId, setOpenItemId] = useState(null);


  useEffect(() => {
    if (merchantId && categoryId) {
      dispatchLoadingItems(merchantId, categoryId);
    }
  }, [categoryId, merchantId, dispatchLoadingItems]);


  if (!loading) {
    return <p>Carregando itens...</p>;
  }
  const handleToggleCollapse = (itemId) => {

    setOpenItemId(prevId => (prevId === itemId ? null : itemId));
  };

  const normalItemsToDisplay = ItemNormal && ItemNormal.rows ? ItemNormal.rows : [];
  const pizzaItemsToDisplay = ItemPizza && ItemPizza.rows ? ItemPizza.rows : [];

  const handleStatusItem = (item) => {
    const novoStatus = item.status === "UNAVAILABLE" ? "AVAILABLE" : "UNAVAILABLE";
    const updatedStatusByCatalog = item.statusByCatalog?.map((catalogEntry, index) => {
      if (index === 0 && catalogEntry.status === item.status) {
        return { ...catalogEntry, status: novoStatus };
      }
      return catalogEntry;
    });

    const payloadData = {
      catalogItemId: item.id,
      status: novoStatus,
      statusByCatalog: updatedStatusByCatalog,
    };
    dispatchUpdateStatusItem(merchantId, payloadData)

    console.log("Item Selecionado...", payloadData);

  }

 const handleStatusPizzas = (option, contextModifier) => {
  if (!contextModifier) {
    // Se não houver contextModifier, significa que a action veio do sabor principal
    // e deve alterar o status de todos os modificadores.
    const options = option.contextModifiers?.map((context) => {
      const newStatus = context.status === "UNAVAILABLE" ? "AVAILABLE" : "UNAVAILABLE";
      const statusByCatalog = context.statusByCatalog?.map((catalogStatus) => {
        const catalogStatusUpdated = catalogStatus.status === "UNAVAILABLE" ? "AVAILABLE" : "UNAVAILABLE";
        return {
          ...catalogStatus,
          status: catalogStatusUpdated,
        };
      });
      return {
        optionId: option.id,
        parentOptionId: context.parentOptionId,
        status: newStatus,
        statusByCatalog: statusByCatalog,
      };
    });

    const payloadSource = {
      options: options,
    };
     console.log("PayloadSource de envio:", JSON.stringify(payloadSource, null, 2));
    dispatchUpdateStatusPizza(merchantId, payloadSource);

  } else {
    // Se o contextModifier existir, a action veio do tamanho.
    // O payload deve conter somente este modificador para atualização.
    const newStatus = contextModifier.status === "UNAVAILABLE" ? "AVAILABLE" : "UNAVAILABLE";
    const statusByCatalog = contextModifier.statusByCatalog?.map((catalogStatus) => {
      const catalogStatusUpdated = catalogStatus.status === "UNAVAILABLE" ? "AVAILABLE" : "UNAVAILABLE";
      return {
        ...catalogStatus,
        status: catalogStatusUpdated,
      };
    });

    const payloadSource = {
      options: [ // O payload agora é um array com apenas um item
        {
          optionId: option.id,
          parentOptionId: contextModifier.parentOptionId,
          status: newStatus,
          statusByCatalog: statusByCatalog,
        },
      ],
    };
    console.log("PayloadSource de envio:", JSON.stringify(payloadSource, null, 2));
    dispatchUpdateStatusPizza(merchantId, payloadSource);
  }
};




  const renderItems = (items) => {

    if (!items || items.lengh === 0) {
      return null;
    }
    return (
      items.map(itemRow => {
        if (itemRow.type === 'DEFAULT') {
          return <ItemsDefault key={itemRow.id}
            item={itemRow}
            handleStatus={handleStatusItem}
          />
        }
        if (itemRow.type === 'PIZZA') {
          return <ItemsPizza key={itemRow.id}
            item={itemRow}
            handleStatus={handleStatusPizzas}
          />
        }

      })
    )
  }

  return (
    <>
      {normalItemsToDisplay.length === 0 && pizzaItemsToDisplay.length === 0 ? (
        <div className='dflexItems'>
          <p>Nenhum item encontrado para esta categoria.</p>
        </div>
      ) : (
        <>
          {renderItems(normalItemsToDisplay)}
          {renderItems(pizzaItemsToDisplay)}
        </>
      )}
    </>)
}
const mapStateToProps = (state, ownProps) => {
  const { categoryId } = ownProps;
  const currentCategoryNormalItems = categoryId
    ? state.ItemsRedurce.normalItems[categoryId]
    : null;
  const currentCategoryPizzaItems = categoryId
    ? state.ItemsRedurce.pizzaItems[categoryId]
    : null;
  return {
    ItemNormal: currentCategoryNormalItems,
    ItemPizza: currentCategoryPizzaItems,
    loading: state.ItemsRedurce,
    merchantId: state.Merchants.selectedMerchant?.id,
  };
};

const mapDispatchToProps = (dispatch) => ({
  dispatchLoadingItems: (merchantId, categoryId) =>
    dispatch(LoadingItems(merchantId, categoryId)),
  dispatchUpdateStatusItem: (itemId, payloadData) => dispatch(UpdateStatusItem(itemId, payloadData)),
  dispatchUpdateStatusPizza: (merchantId,payloadSource) => dispatch(UpdateStatusPizza(merchantId,payloadSource)),
});

const connectItem = connect(mapStateToProps, mapDispatchToProps)(Items)
export { connectItem as Items }