import { useSelector, useDispatch } from 'react-redux';
import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { LoadingCardapio } from '../../_actions/cardapio.action';
import { selectCatalog, deselectCatalog } from '../../_actions/catalogoSelecionado.actions';
import entregaImg from '../../assets/Images/entrega.png';
import retirarImg from '../../assets/Images/retirar.png';
import mesaImg from '../../assets/Images/NaMesa.png'
import '../../assets/css/styleCardapio.css';

const AdicionarCategoria = () => {
  const { selectedMerchant } = useSelector((state) => state.Merchants);
  const { catalogs, loading } = useSelector((state) => state.MenuList);
  const dispatch = useDispatch();
  const navigate = useNavigate();
  const { selectedCatalogs } = useSelector((state) => state.CatalogoSelecionado);

  // Mapeamento de imagens padrão
  const catalogImages = {
    DEFAULT: entregaImg,
    TAKEOUT: retirarImg,
    BASIC: mesaImg
  };

  useEffect(() => {
    if (selectedMerchant?.id) {
      dispatch(LoadingCardapio(selectedMerchant?.id));
    }
  }, [dispatch, selectedMerchant?.id]);

  useEffect(() => {
    // Se só tiver 1 catálogo, vai direto para outra seleção
    if (catalogs && catalogs.length === 1) {
      dispatch(selectCatalog(catalogs[0].catalogId))
      navigate(`../../menu/category`);
    }
  }, [catalogs, navigate]);

  const toggleCatalog = (id) => {
    if (selectedCatalogs.includes(id)) {
      dispatch(deselectCatalog(id));
    } else {
      dispatch(selectCatalog(id));
    }
  };

  if (loading) {
    return <p>Carregando...</p>;
  }

  if (catalogs.length === 1) {
    return null; // Navegação já feita no useEffect
  }
  console.log("Catalogos", catalogs);
  return (
    <div className="cardapios-container">
      <div className="cardapios-header">
        <h1>Cardápios</h1>
        <p>
          Seu cardápio é sua vitrine de produtos no iFood. Agora você pode atender
          seus clientes de diferentes formas e disponibilizar um cardápio para cada situação.
        </p>
      </div>

      <div className="cardapios-grid">
        {catalogs.map((catalog) => {
          const imageSrc = catalog.image || catalogImages[catalog.catalogType] || entregaImg;
          return (
            <div
              key={catalog.catalogId}
              className={`cardapio-card ${selectedCatalogs.includes(catalog.catalogId) ? 'selected' : ''}`}
              onClick={() => toggleCatalog(catalog.catalogId)}
            >
              <input
                type="checkbox"
                checked={selectedCatalogs.includes(catalog.catalogId)}
                onChange={(e) => {
                  e.stopPropagation(); // evita clique duplicado
                  toggleCatalog(catalog.catalogId);
                }}
              />
              <img src={imageSrc} alt={catalog.name} />
              <h3>{catalog.name || 'Cardápio Padrão'}</h3>
              <p>{catalog.description || getDefaultDescription(catalog.catalogType)}</p>
            </div>
          );
        })}
      </div>

      {selectedCatalogs.length > 0 && (
        <div className="btn-avancar-container">
          <button
            className="btn-avancar"
            onClick={() => navigate(`../../menu/category`)} // onClick={() => navigate(`../../menu/category?ids=${selectedCatalogs.join(',')}`)}
          >

            Avançar
          </button>
        </div>
      )}
    </div>
  );
};

function getDefaultDescription(type) {
  switch (type) {
    case 'DEFAULT':
      return 'O cliente recebe o pedido em casa';
    case 'BASIC':
      return 'O cliente retira o pedido na loja';
    case 'INDOOR':
      return 'O cliente pede pelo iFood e consome no salão';
    default:
      return 'Descrição não disponível';
  }
}

export { AdicionarCategoria };