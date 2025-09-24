import React,{useState} from "react";

const ItemsPizza = ({ item,handleStatus }) => {
   const [openStates, setOpenStates] = useState({});

    const handleToggleCollapse = (id) => {
    setOpenStates((prevStates) => ({
      ...prevStates,
      [id]: !prevStates[id], // Inverte o valor booleano para o ID clicado
    }));
  };

    const renderSabor = () => {
    if (!item.optionGroup) return null;

    return item.optionGroup
        .filter((optionsGrup) => optionsGrup.type === "TOPPING")
        .flatMap((optionsGrup) =>
            optionsGrup.options.map((option, subIndex) => {
              //  console.log("Sabor", option.name);
                return (<>
                    <div className='dflexItems' key={option.id || subIndex}> {/* Use option.id para key, senão subIndex */}
                        <div className='dflexItems'>
                            <div className='iVvxoA'>
                                <div className='ftzmG'>
                                    <div className='huvoXc'>
                                        <div className='daPmSh'>
                                            <img
                                                className="dQhXnD"
                                                src={option.imageUrl || "https://static-images.ifood.com.br/image/upload/t_thumbnail/pratos/e2e967ea-b16e-4add-91c8-e1c4b6d5a9bf/202412022237_3KC7_i.jpg"} // Use option.imageUrl
                                                alt={option.name} width="60px" height="48px"
                                            />
                                        </div>
                                        <div className='hlYZNs'>
                                            <div className='fnYvXf'>
                                                {/* Ajuste o href se necessário */}
                                                <a className="fAGWio hxKVdR" href={`/menu/catalog/product/${option.id}?redirectURL=/menu/list`}>
                                                    <p className="fsEeli">{option.name}</p>
                                                </a>
                                                {option.description && ( // Renderiza descrição apenas se existir
                                                    <span title={option.description} className="chVyW">
                                                        <p className="jrqaRP">{option.description}</p>
                                                    </span>
                                                )}
                                            </div>
                                        </div>
                                    </div>
                                </div>


                                <div className='EVcke'>
                                    <div className='ctyLcS'>
                                        <button
                                        className="btn btn-primary"
                                        onClick={() => handleToggleCollapse(option.id)}
                                        >Tamanhos</button>
                                    </div>
                                </div>

                                <div className='kOTkfk'>
                                    <div>
                                        <div className='hzaojs'>
                                            <div className='iRubGO'>
                                                <div className='hGPUxv'>
                                                    <div className='jNgtji'>
                                                        <div class="Flex-sc-rrnf8w-0 guksfG">
                                                            <span class="BaseText-sc-1a1327l-0 gsrueK sc-fbgIAx fwzCKo">À partir de</span>
                                                            {/*console.log("A PArtir de ", option?.customizationModifiers?.[0]?.priceByCatalog?.[0]?.price?.value ?? "Valor não disponível")}
                                                            {/* <Preco option={option} /> */}
                                                        </div>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div>
                                        <div className='bt'>
                                             <button className="btn btn-outline-danger" onClick={()=>handleStatus(option,undefined)}>
                                               {option.contextModifiers?.every(cm => cm.status === "AVAILABLE") ? (
                                                    <i className="fa-solid fa-play"></i>
                                                ) : (
                                                    <i className="fa-solid fa-pause"></i>
                                                )}

                    </button>
                                        </div>
                                    </div>
                                    <div>
                                        <div className='bt'>
                                            <button id={`btnGroupDropOption${option.id}`} type="button" className="btn btn-outline-danger" data-bs-toggle="dropdown" aria-expanded="false">
                                                <i className="fas fa-ellipsis-v"></i>
                                            </button>
                                            <ul className="dropdown-menu" aria-labelledby={`btnGroupDropOption${option.id}`}>
                                                <li><a className="dropdown-item" href="#">Editar Fatia</a></li>
                                                <li><a className="dropdown-item" href="#">Remover Fatia</a></li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    {renderTamanhos(option)}
                </>);
            })
        );
};



    const renderTamanhos = (saborOption) => {
        if (!item.optionGroup) return null;
        const sizeGroup = item.optionGroup.find(group => group.type === "SIZE");
        if (!sizeGroup) return null;

        return sizeGroup.options.map((sizeOption, subIndex) => {
            // Find the correct context modifier for this size based on the flavor
            const contextModifier = saborOption.contextModifiers?.find(
                (cm) => cm.parentOptionId === sizeOption.id
            );

            // Determine the display status based on the contextModifier's status
            const statusDisplay = contextModifier?.status === "AVAILABLE" ? "disponível" : "indisponível";

            return (
                <div
                    key={sizeOption.id || subIndex}
                    className={`collapse ${openStates[saborOption.id] ? "show" : ""}`}
                    id={`collapse-${saborOption.id}`}
                >
                    <div className="card card-body">
                        <div className='group-body'>
                            <div className='jSZMlF'>
                                <div className='ksgYiW'>
                                    <div className='jOKseN'>
                                        <img className="dQhXnD"
                                            src="https://static-images.ifood.com.br/image/upload/t_thumbnail/pratos/e2e967ea-b16e-4add-91c8-e1c4b6d5a9bf/202412022237_3KC7_i.jpg"
                                            alt="Xis Salada" width="60px" height="48px" />
                                    </div>
                                    <p className='fhuebJ'>{sizeOption.name}</p>
                                </div>
                                <div className='dhDrVv'>
                                    {/* ... (seu input de preço) */}
                                </div>
                                <div className='bSaTlG'>
                                    <div className='bt'>
                                        {/* Botão de status para o tamanho, usando o status do contextModifier */}
                                        <button className="btn btn-outline-danger" onClick={() => handleStatus(saborOption,contextModifier)}>
                                            {contextModifier?.status === "AVAILABLE" ? (
                                                <i className="fa-solid fa-play"></i>
                                            ) : (
                                                <i className="fa-solid fa-pause"></i>
                                            )}
                                        </button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            );
        });
    };

    return (<>
                 {renderSabor()}
            </>)
}

export default ItemsPizza;