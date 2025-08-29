
const PainelProdutos = ({ children, count }) => {


    return (<>
        <div className="header-actions-produto">
            <div class="PfHPZ">
                <div class="ceFelm">
                    <p class="bsrRPk">
                        Produtos do seu cardápio [{count?.length}]</p>
                    <p class="cgFAaj">
                        Adicione, pause ou ative os produtos que seus clientes podem pedir no app iFood.</p></div>
                <button className="btn btn-outline-danger" type="button">
                    <i class="fa fa-plus" aria-hidden="true"></i>
                    Adicionar produto
                </button>
            </div>
        </div>
        {children}
    </>)

}

export { PainelProdutos }