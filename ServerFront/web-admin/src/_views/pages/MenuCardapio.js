import React, { useEffect, useState } from 'react';
import { connect } from 'react-redux';
import { useNavigate } from 'react-router-dom';

import '../../assets/css/styleCardapio.css';
import '@fortawesome/fontawesome-free/css/all.min.css';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faSearch } from '@fortawesome/free-solid-svg-icons';

import { LoadingCardapio, LoadingProduto } from '../../_actions/cardapio.action';
import { LoadingItems } from '../../_actions/Items.action';
import { LoadingCategory } from '../../_actions/category.action';
import { PainelCategoria } from '../../_components/PainelCategoria';
import { PainelProdutos } from '../../_components/PainelProdutos';
import { Items } from '../../_components/Items';
import { ItemsProdutos } from '../../_components/ItemsProdutos';

const MenuCardapio = ({
  selectedMerchant,
//  catalogs,
  category,
  categoryLoading,
  products,
  productsLoading,
//  dispatchLoadingCardapio,
  dispatchLoadingProduto,
  dispatchLoadingCategory,
  dispatchLoadingItems,
}) => {
  const [activeTab, setActiveTab] = useState('cardapio');
  const navigate = useNavigate();

  useEffect(() => {
    if (selectedMerchant?.id) {
      if (activeTab === 'cardapio') {
      // dispatchLoadingCardapio(selectedMerchant.id);
        dispatchLoadingCategory(selectedMerchant.id);
      } else if (activeTab === 'produtos') {
        dispatchLoadingProduto(selectedMerchant.id);
      } else if (activeTab === 'complemento') {
        console.log("Ativando os Complementos");
      }
    }
  }, [selectedMerchant?.id, activeTab]);


  const renderTabContent = () => {
    switch (activeTab) {
      case 'cardapio':
        return (
          <>
            <div className="header-actions">
              <button className="btn btn-outline-danger">Replicar cardápio</button>
              <button className="btn btn-outline-danger">Backup</button>
              <div className="search-box">
                <div className="d-flex" role="search">
                  <form type="search" placeholder="Search" className="me-2" aria-label="Search" />
                  <button className="btn btn-outline-danger"><FontAwesomeIcon icon={faSearch} /></button>
                </div>
              </div>
              <button className="btn btn-outline-danger" onClick={() => navigate(`/menu/catalogs`)}>
                <i className="fa fa-plus" aria-hidden="true"></i> Adicionar categoria
              </button>
            </div>
            {(category ?? []).map((item, index) => (
              <PainelCategoria category={item} key={index}>
               <Items categoryId={item.categoryId} />
              </PainelCategoria>
            ))}
          </>
        );
      case 'produtos':
        return (
          <PainelProdutos count={products.data}>
            <ItemsProdutos products={products} />
          </PainelProdutos>
        );
      case 'complemento':
        return <>Complementos</>;
      default:
        return null;
    }
  };

  return (
    <div className="content-wrapper" style={{ minHeight: '1518.4px' }}>
      <section className="content-header">
        <div className="container-fluid">
          <div className="menu-management-container">
            <div className="header">
              <div className="header-title">
                <div className="box">
                  <div className="box-1">
                    <div className="vBKDp">
                      <h1>Cardápio</h1>
                      <p>Gerencie os itens do seu cardápio de forma fácil e eficiente.</p>
                    </div>
                  </div>
                </div>
                <div className="flex-v">
                  <i className="fa fa-laptop" aria-hidden="true"></i>
                  <i className="fa fa-line-chart" aria-hidden="true"></i>
                  <i className="fa fa-cogs" aria-hidden="true"></i>
                </div>
              </div>
              <nav>
                <div className="nav nav-tabs" id="nav-tab" role="tablist">
                  <button className={`nav-link ${activeTab === 'cardapio' ? 'active' : ''}`} onClick={() => setActiveTab('cardapio')}>Cardápio</button>
                  <button className={`nav-link ${activeTab === 'produtos' ? 'active' : ''}`} onClick={() => setActiveTab('produtos')}>Produtos</button>
                  <button className={`nav-link ${activeTab === 'complemento' ? 'active' : ''}`} onClick={() => setActiveTab('complemento')}>Complemento</button>
                </div>
              </nav>
              <div className="category-section">
                {renderTabContent()}
              </div>
            </div>
          </div>
        </div>
      </section>
    </div>
  );
};


const mapStateToProps = (state) => {

return{
 
  selectedMerchant: state.Merchants.selectedMerchant,
  catalogs: state.MenuList.catalogs,
  category: state.CategoriaList.category,
  categoryLoading: state.CategoriaList.loading,
  products: state.ProductsReduce.products,
  productsLoading: state.ProductsReduce.loading
};
}


const mapDispatchToProps = (dispatch) => ({
 // dispatchLoadingCardapio: (id) => dispatch(LoadingCardapio(id)),
  dispatchLoadingProduto: (id) => dispatch(LoadingProduto(id)),
  dispatchLoadingCategory: (id) => dispatch(LoadingCategory(id)),
  dispatchLoadingItems:(mechantsId,categoryId) => dispatch(LoadingItems(mechantsId,categoryId))
});

const contectMenu = connect(mapStateToProps, mapDispatchToProps)(MenuCardapio);
export { contectMenu as MenuCardapio }