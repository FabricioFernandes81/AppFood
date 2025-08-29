import React, {useState, useEffect } from 'react';
import { connect } from 'react-redux';
import { LoadingItems } from '../_actions/Items.action';
import ItemsDefault from './ItemsDefault';
import ItemsPizza from './ItemsPizza';
import 'bootstrap/dist/js/bootstrap.bundle.min';


const Items = ({
  categoryId,
  merchantId,
  ItemNormal,
  ItemPizza,
  loading,
  dispatchLoadingItems }) => {
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
  

   const renderItems = (items)=>{
    if(!items || items.lengh === 0){
      return null;
    }
    return( 
    items.map(itemRow =>{
      if(itemRow.type === 'DEFAULT'){
         // console.log("Teste,",itemRow);
       return <ItemsDefault key={itemRow.id} item={itemRow}/>
      }
      if(itemRow.type === 'PIZZA'){
        return <ItemsPizza key={itemRow} item={itemRow}/>
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
});

const connectItem = connect(mapStateToProps, mapDispatchToProps)(Items)
export { connectItem as Items }