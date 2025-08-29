import React, { useState, useEffect,useRef } from 'react';

const FormularioEditMap = ({ handleBuscarListCitys, input, setInput,
    onAddress, onSetAddress, sugestoes, handleSelecionarSugestao, }) => {
    const [etapa, setEtapa] = useState(1);
   
    const handleChange = (e) => {
        const { name, value } = e.target;
        onSetAddress((prev) => ({
            ...prev, [name]: value
        }));
    };

    const handleSubmit = (e) => {
        e.preventDefault();
           const valorAltr = { 
                address: onAddress.address, 
                city: onAddress.city, 
                complement: onAddress.complement, 
                district: onAddress.district, 
                state: onAddress.state, 
                streetNumber: onAddress.streetNumber, 
                zipCode: onAddress.zipCode, 
            }
                handleSelecionarSugestao(valorAltr);
        avancar();
      
    }
   
    const handleSalvarEndereco = ()=>{
                console.log("Salvar Formulario!")
    }
    const handleEnter = (e)=>{

        if (e.key === 'Enter') {
            e.preventDefault();
            
            const valorAltr = { 
                address: onAddress.address, 
                city: onAddress.city, 
                complement: onAddress.complement, 
                district: onAddress.district, 
                state: onAddress.state, 
                streetNumber: onAddress.streetNumber, 
                zipCode: onAddress.zipCode, 
            }
                handleSelecionarSugestao(valorAltr);
        }
    }


    const avancar = () => {
        if (etapa < 3) {
            setEtapa(etapa + 1);

            // console.log("Etapa;", etapa)

        }
    };

    const voltar = () => {
        if (etapa > 1) setEtapa(etapa - 1);

    };

    const cancelar = () => {
        setEtapa(1);

    };

    return (<div className="container">

        <div className="barra-etapas">
            {[1, 2, 3].map((n) => (
                <div
                    key={n}
                    className={`barra ${etapa === n ? 'ativa' : ''}`}
                    onClick={voltar}
                />
            ))}
        </div>
        <p>Etapa {etapa} de 3</p>

        {etapa === 1 && (
            <>
                <h3 class="profile-address-edit__step-title">Buscar endereço</h3>
                <label>CEP:</label>
                <input
                    type="text"
                    name='input'
                    placeholder="Digite o CEP ou endereço"
                    style={{ width: '100%', padding: '8px', marginTop: '8px' }}
                    onChange={(e) => {
                        handleBuscarListCitys(e.target.value);

                    }}
                    value={input}
                />


                <div style={{ marginTop: '8px', backgroundColor: '#f4f4f4', padding: '8px', whiteSpace: 'normal' }} onClick={null}>
                    {sugestoes?.map((list) => (
                        <div key={list.id}
                            style={{
                                padding: '4px',
                                marginBottom: '4px',
                                cursor: 'pointer',
                                backgroundColor: '#eaeaea',
                            }}
                            onClick={() => {
                                handleSelecionarSugestao(list);
                            }}
                        >{list.id} - {list.city} - {list.zipcode}</div>
                    ))}
                </div>



            </>
        )}
        {etapa === 2 && (
            <div class="wizard-steps">
                <div>
                    <h3 class="profile-address-edit__step-title">Confirmar endereço</h3>
                    <form autocomplete="off" class="profile-address-edit-form" onSubmit={handleSubmit}>
                        <div class="field form-group">
                            <div class="label-group">
                                <label for="address" class="field__label form-control-label">Logradouro</label>
                            </div>
                            <div class="input-group">
                                <input class="field__input form-control" name="address" type="text" data-testid=""
                                    id="address"
                                    value={onAddress.address}
                                    onChange={(e) => {
                                        handleChange(e);
                                    }}
                                   
                                />
                            </div>
                        </div>
                        <div class="field form-group">
                            <div class="label-group">
                                <label for="street-number" class="field__label form-control-label">Número</label>
                            </div>
                            <div class="input-group">
                                <input class="field__input form-control"
                                    name="streetNumber"
                                    type="text"
                                    data-testid=""
                                    id="street-number"
                                    value={onAddress.streetNumber}
                                    onChange={handleChange}
                                   
                                />
                            </div>
                        </div>
                        <div class="field form-group">
                            <div class="label-group">
                                <label for="complement" class="field__label form-control-label">Complemento</label>
                            </div>
                            <div class="input-group">
                                <input class="field__input form-control"
                                    name="complement"
                                    type="text"
                                    maxlength="45"
                                    data-testid=""
                                    id="complement"
                                    value={onAddress.complement}
                                    onChange={handleChange}
                                   
                                />
                            </div>
                            <div class="field-with-limit__counter">0/45 caracteres</div>
                        </div>
                        <div class="field form-group">
                            <div class="label-group">
                                <label for="district" class="field__label form-control-label">Bairro</label>
                            </div>
                            <div class="input-group">
                                <input class="field__input form-control" name="district" type="text" data-testid=""
                                    id="district"
                                    onChange={handleChange}
                                    value={onAddress.district}
                                    
                                />
                            </div>
                        </div>
                        <div class="field form-group">
                            <div class="label-group">
                                <label for="zip-code" class="field__label form-control-label">CEP</label>
                            </div>
                            <div class="input-group">
                                <input
                                    class="field__input form-control"
                                    name="zipCode"
                                    type="text"
                                    data-testid=""
                                    id="zip-code"
                                    onChange={handleChange}
                                    value={onAddress.zipCode}
                                    
                                    readOnly
                                />
                            </div>
                        </div>
                        <div class="field form-group">
                            <div class="label-group">
                                <label for="constant" class="field__label form-control-label">Cidade e Estado</label>
                            </div>{onAddress.city}, {onAddress.state}</div>
                        <button class="edit-button"
                            color="primary"
                            data-testid="profile-address-edit-form-submit">Confirmar</button>
                    </form>
                </div>
            </div>


        )}
        {etapa === 3 && (
            <div>
                 <h3 class="profile-address-edit__step-title">Confirmar posição no mapa</h3>
            <div class="profile-address-edit__confirm-address"><div>
            <span class="profile-address-edit__confirm-street">{onAddress.address}, {onAddress.streetNumber}</span>
            <span class="profile-address-edit__confirm-district">{onAddress.district}</span></div>
            <div class="profile-address-edit__confirm-city">{onSetAddress.city}, {onAddress.state}</div>
            <div class="profile-address-edit__confirm-zip-code">CEP {onAddress.zipCode}</div>
            </div>
            <button class="edit-button"
                            color="primary"
                            data-testid="profile-address-edit-form-submit" onClick={handleSalvarEndereco}>Salvar novo endereço</button>
                                 <button class="edit-button"
                            color="primary"
                            data-testid="profile-address-edit-form-submit">cancelar</button>
            </div>
        )}

{etapa < 2 && (
        <div style={{ marginTop: '16px', display: 'flex', justifyContent: 'space-between' }}>
            
            <button className="edit-button" onClick={avancar} disabled={ /* !Selecionado  ||*/ etapa === 3}>
                Próximo
            </button>
           
        </div> )}
    </div>

    )
}

export { FormularioEditMap }