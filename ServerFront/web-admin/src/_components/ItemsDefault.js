import React, { useState } from 'react';
import OptionsGroup from './OptionsGroup'; // Certifique-se de que o caminho está correto

const ItemsDefault = ({ item }) => {
    const [isOpen, setIsOpen] = useState(false);

    const handleToggleCollapse = () => {
        setIsOpen(!isOpen);
    };

    return (
        <React.Fragment>
          <div className='dflexItems'>
            <div className='iVvxoA'>
              <div className='ftzmG'>
                <div className='huvoXc'>
                  <div className='daPmSh'>
                    <img class="dQhXnD"
                      src={'../imagens/xis1.jpg'}
                      alt="Xis Salada" width="60px" height="48px" />
                  </div>
                  <div className='hlYZNs'>
                    <div className='fnYvXf'>
                      <a class="fAGWio hxKVdR" href="redirectURL=/menu/list">
                        <p class="fsEeli">{item.name}</p></a>
                      <span title="Pao milho" class="chVyW">
                        <p class="jrqaRP">{item.description}</p>
                      </span>

                    </div>
                  </div>
                </div></div>
              <div className='EVcke'>
                <div className='ctyLcS'>
                    {item.optionGroup && item.optionGroup.length > 0 && (
                 <button
                  className="btn btn-primary"
                  onClick={() => handleToggleCollapse(item.id)}
                >
                  Componentes
                </button>
                )}
                </div>
              </div>

              <div className='kOTkfk'>
                <div>
                  <div className='hFgrJs'>
                    <div className='gSVllA'>
                      <div className='iEIiiH'>
                        <div className='bwaOug'>
                          <div className='gSVllA'>
                            <div className='jNgtji'>
                              <input placeholder="Estoque" type="number" data-testid="stock-field" class="cFSuoX" aria-invalid="false" value="10" >
                              </input>
                            </div>
                          </div>
                        </div>

                      </div>
                    </div>
                  </div>
                </div>
                <div>
                  <div className='hzaojs'>
                    <div className='iRubGO'>
                      <div className='hGPUxv'>
                        <div className='jNgtji'>

                        </div>
                      </div>

                    </div>

                  </div>
                </div>
                <div>
                  <div className='bt'>
                    <button className="btn btn-outline-danger" >
                      <i class="fa-solid fa-play"></i>
                    </button>

                  </div>
                </div>

              </div> <div>
                <div className='bt'>
                  <button className="btn btn-outline-danger" >
                    <i class="fas fa-ellipsis-v"></i>
                  </button>
                </div>
              </div>

            </div>
          
          </div>
            <div className={`collapse ${isOpen ? 'show' : ''}`} id={`collapseExample${item.id}`}>
            <OptionsGroup /> 
          </div>
           </React.Fragment>
    );
};

export default ItemsDefault;