const ItemsProdutos = ({ products }) => {


  console.log("Produtos:", products)
  return (<div class="table-responsive">
    <table class="table table-bordered table-responsive">
      <thead>
        <tr>
          <th>Imagem</th>
          <th>Produto</th>
          <th>Classificação</th>
          <th>Disponível</th>
          <th>Ação</th>

        </tr>
      </thead>
      <tbody>

        {(products.data ?? []).map((dataProduct) => (
          <tr key={dataProduct.id}>
            <td>
              <button type="button" data-testid="image-container" className="gWKXGN">
                <div style={{ width: '276px' }} className="huuBzX">
                  <img
                    src="https://static-images.ifood.com.br/pratos/e2e967ea-b16e-4add-91c8-e1c4b6d5a9bf/202506271552_47GO_i.jpg"
                    alt="Imagem"
                    className="sc-ddcbSj bjzgjG"
                  />
                  <span className="hxzSWb">Alterar</span>
                </div>
              </button>
            </td>
            <td>
              <div className="jTIDQZ">
                <div className="Flex-sc-rrnf8w-0 bmXQvW hide-on-hover">
                  <span title="" className="gsrueK sc-iRqkff jlOWFT">{dataProduct.name}</span>
                  <span title="" className="eoglkj sc-iRqkff bwtQvd">{dataProduct.description}</span>
                </div>
              </div>
            </td>
            <td><span className="eOPDtH">{getDefaultItem(dataProduct.offerTypes[0])}</span></td>
            <td>{(dataProduct.availableAt ?? []).map((availableAt, index) => (
              <span key={index}>{availableAt.name}</span>
            ))}

            </td>
            <td>
              <div className="bt">
                <button className="btn btn-outline-danger">
                  <i className="fa-solid fa-play"></i>
                </button>
              </div>
            </td>
          </tr>
        ))}


      </tbody>
    </table>
  </div>)
}

function getDefaultItem(type) {
  switch (type) {
    case 'ITEM':
      return 'Item principal'
    case 'OPTION':
      return 'Complemento'
    default:
      return 'Indispinivel'
  }
}


export { ItemsProdutos }