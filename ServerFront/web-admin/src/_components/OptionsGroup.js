import React from "react";

export const OptionsGroup = ()=>{

    return(
           <div className="card card-body"> 
                            <div className='bDAwPD'>
                                <div className='fzFVSz'>
                                    <p className='EaSYv'>{"opt.name"}</p>
                                    <div className='kwwSmT'>
                                            <div className='fPxnjl'> <i className="fa fa-lock" ></i>
                                                OBRIGATÓRIO
                                            </div>
                                       
                                         <div className='fPxnjl'>Reutilizado</div>
                                    </div>
                                </div>
                                <div className='gArgWY'>
                                    <div className='gEZdxJ'>
                                        <div className='bt'>
                                            <button className="btn btn-outline-danger" >
                                                <i className="fa-solid fa-play"></i>
                                            </button>
                                        </div>
                                        <div className='bt'>
                                            <button className="btn btn-outline-danger" >
                                                <i className="fas fa-ellipsis-v"></i>
                                            </button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            {/* {opt.options && opt.options.map((option, subIndex) => ( */}
                                <div className='group-body' > {/* Key para o loop aninhado */}
                                    <div className='jSZMlF'>
                                        <div className='ksgYiW'>
                                            <div className='jOKseN'>  
                                                <img className="dQhXnD"
                                                    src="https://static-images.ifood.com.br/image/upload/t_thumbnail/pratos/e2e967ea-b16e-4add-91c8-e1c4b6d5a9bf/202412022237_3KC7_i.jpg"
                                                    alt="Xis Salada" width="60px" height="48px" />
                                            </div>
                                            <p className='fhuebJ'>{"option.name"}</p>
                                        </div>
                                        <div className="dhDrVv">
                                            {/* {option.priceByCatalog && option.priceByCatalog.map((preco, priceIndex) => ( */}
                                            
                                                    {/* {preco.catalogType === "DEFAULT" ? ( */}
                                                        <>
                                                            <div className='dhDrVv'>
                                                                <i className="fa fa-motorcycle" aria-hidden="true"></i>
                                                            </div>
                                                            <input
                                                                placeholder="R$ 0,00"
                                                                name={`item-price-${"option.id"}-${"preco.catalogType"}`} // ID dinâmico
                                                                type="text" // Usar "text" para formatação de moeda
                                                                data-testid="currency-field"
                                                                className="InvisibleInput-sc-1d20jmf-1 jOwbbB sc-lgkFzn flsHoX"
                                                                id={`item-price-${"option.id"}-${"preco.catalogType"}`} // ID dinâmico
                                                                aria-invalid="false"
                                                              //  value={new Intl.NumberFormat('pt-BR', { style: 'currency', currency: 'BRL', }).format(preco.price.value.value)}
                                                                readOnly // Preço de exibição geralmente é readOnly
                                                            />
                                                        </>
                                                  
                                                        <>
                                                            <div className='dhDrVv'>
                                                                <i className="fa fa-list" aria-hidden="true"></i>
                                                            </div>
                                                            <input
                                                                placeholder="R$ 0,00"
                                                             //   name={`item-price-${option.id}-${preco.catalogType}`} // ID dinâmico
                                                                type="text"
                                                                data-testid="currency-field"
                                                                className="InvisibleInput-sc-1d20jmf-1 jOwbbB sc-lgkFzn flsHoX"
                                                              //  id={`item-price-${option.id}-${preco.catalogType}`} // ID dinâmico
                                                                aria-invalid="false"
                                                               // value={new Intl.NumberFormat('pt-BR', { style: 'currency', currency: 'BRL', }).format(preco.price.value.value)}
                                                                readOnly
                                                            />
                                                        </>
                                                   
                                               
                                           
                                        </div>
                                        <div className='bSaTlG'>
                                            <div className='bt'>
                                                <button className="btn btn-outline-danger" >
                                                    <i className="fa-solid fa-play"></i>
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                           
                       

           </div>)
}

export default OptionsGroup;