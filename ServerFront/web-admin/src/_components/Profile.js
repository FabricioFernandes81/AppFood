import React,{useState,useEffect} from "react";
import {  UpdateFormField,
         submitMerchants,
         updateImageField,
 } from "../_actions/merchantsProfile.action";

import '../assets/css/formprofile.css'
import Logoim from '../assets/Images/default-profile-image.2c669f74.png'
import {connect } from 'react-redux';

const CategoriaList = [{"code":"AC1","name":"Açaí"},{"code":"AF1","name":"Africana"},{"code":"ALE","name":"Alemã"},{"code":"ARA","name":"Árabe"},{"code":"AR1","name":"Argentina"},{"code":"ASI","name":"Asiática"},{"code":"BA1","name":"Baiana"},{"code":"BRA","name":"Brasileira"},{"code":"CA1","name":"Cafeteria"},{"code":"CAR","name":"Carnes"},{"code":"CS1","name":"Casa de Sucos"},{"code":"CHI","name":"Chinesa"},{"code":"CO1","name":"Colombiana"},{"code":"CN1","name":"Congelados"},{"code":"CF1","name":"Congelados Fit"},{"code":"CNT","name":"Contemporânea"},{"code":"CR1","name":"Coreana"},{"code":"CRP","name":"Cozinha Rápida"},{"code":"CP1","name":"Crepe"},{"code":"DCE","name":"Doces & Bolos"},{"code":"ES1","name":"Espanhola"},{"code":"FRA","name":"Francesa"},{"code":"FR1","name":"Frangos"},{"code":"FRU","name":"Frutos Do Mar"},{"code":"GA1","name":"Gaúcha"},{"code":"GRC","name":"Grega"},{"code":"BUR","name":"Hambúrguer"},{"code":"IND","name":"Indiana"},{"code":"ITA","name":"Italiana"},{"code":"JAP","name":"Japonesa"},{"code":"LCH","name":"Lanches"},{"code":"MA1","name":"Marmita"},{"code":"MAR","name":"Marroquina"},{"code":"MED","name":"Mediterrânea"},{"code":"MEX","name":"Mexicana"},{"code":"MI1","name":"Mineira"},{"code":"NO1","name":"Nordestina"},{"code":"PA1","name":"Padaria"},{"code":"PQC","name":"Panqueca"},{"code":"PR1","name":"Paranaense"},{"code":"PAS","name":"Pastel"},{"code":"PX1","name":"Peixes"},{"code":"PER","name":"Peruana"},{"code":"PIZ","name":"Pizza"},{"code":"POR","name":"Portuguesa"},{"code":"PRE","name":"Presentes"},{"code":"SAG","name":"Salgados"},{"code":"SAU","name":"Saudável"},{"code":"SP1","name":"Sopas & Caldos"},{"code":"SOR","name":"Sorvetes"},{"code":"THA","name":"Tailandesa"},{"code":"TA1","name":"Tapioca"},{"code":"TN1","name":"Típica do Norte"},{"code":"VAR","name":"Variada"},{"code":"VE1","name":"Vegana"},{"code":"VEG","name":"Vegetariana"},{"code":"XI1","name":"Xis"},{"code":"YA1","name":"Yakisoba"}];

const Profile = (props) => {
  const { data, loading, UpdateFormField, submitMerchants, updateImageField, imageFiles } = props;

const handleChange = (e) => {
    const { name, value } = e.target;
     UpdateFormField(name,value);
  };

  const handleSubmit = (e) => {
    e.preventDefault();
   submitMerchants(data, imageFiles.coverFile, imageFiles.logoFile);
  }

 const handleImageUpload = (event, fieldName) => {
    const file = event.target.files[0];
    if (file) {
      const reader = new FileReader();
      reader.onload = (e) => {
        // Despacha a ação do Redux para atualizar o estado com o arquivo e a URL de pré-visualização
       updateImageField(fieldName, file, e.target.result);
      };
      reader.readAsDataURL(file);
    }
  };



    return ( <div className="container-fluid">
        <div className="row justify-content-center">
            <div className="col-lg-10 col-md-12">
                
             <form onSubmit={handleSubmit}>
                <div className="row">
                    <div className="grid-profile">
                        <div className="Flex-sc-rrnf8w-0">
                            <div className="mb-3">
                                <label for="storeName" className="form-label">Nome da loja*</label>
                                <input type="text" className="form-control" 
                                 name="name"
                                 onChange={handleChange}
                                 value={data?.name || ''}
                                 disabled={loading}
                                 />
                                <div className="form-text form-label-small">Nome que vai aparecer para seus clientes no app</div>
                            </div>
                             <div className="mb-3">
                                <label for="storeDescription" className="form-label">Descrição da loja</label>
                                <textarea className="form-control" id="Descricao" rows="5" 
                                placeholder="Escreva uma breve descrição da sua loja em até 400 caracteres"
                                onChange={handleChange}
                                name = "description" 
                                value = {data?.description}
                                disabled={loading}
                               
                                >  
                                </textarea>
                                <div className="text-end form-label-small">{data.description?.length}/400</div>
                            </div>

                            <div className="mb-3">
                                <label for="category" className="form-label">Categoria*</label>
                                <select className="form-select" id="Categoria"
                                 name="mainCuisine"
                                 value={data?.mainCuisine}
                                 onChange={handleChange}
                                 disabled={loading}
                                >
                                   {CategoriaList?.map((categoria, index) => (
                                    <option key={index} value={categoria?.code}>
                                        {categoria?.name}
                                    </option>
                                    ))}
                                </select>
                                <div className="form-text form-label-small">Informação referente ao tipo de cozinha da sua loja</div>
                            </div>

                            <div className="mb-3">
                                <label for="contactPhone" className="form-label">Telefone de contato*</label>
                                <input type="text" className="form-control" id="Fone" 
                                name="Fone"
                                value={data?.deliveryPhone}
                                onChange={handleChange} 
                                disabled={loading}
                                />
                                <div className="form-text form-label-small">Telefone para clientes com pedidos em andamento</div>
                            </div>
                        </div>
                          <div className="Flex-sc-rrnf8w-0">
                             <div className="right-preview">
                             <div className="Flex-sc-rrnf8w-0">
                                    <div className="image-upload-container">
                                       <img src={data.cover || Logoim} alt="Background Pattern" className="img-grande" />
                                          <label htmlFor="main-image-upload" className="upload-icon">
                                            <i className="fas fa-upload"></i>
                                          </label>
                                          <input
                                            type="file"
                                            id="main-image-upload"
                                            accept="image/*"
                                            onChange={(e) => handleImageUpload(e, 'cover')} // Chama a ação `updateImageField` com o nome 'cover'
                                            name="cover"
                                            style={{ display: "none" }}
                                          />
                                    </div>
                                   
                                </div>
                            
                                <div className="Flex-sc-rrnf8w-0">
                                   <div className="img-container">
                                    <img
                                        src={data.logo || Logoim}
                                        alt="Imagem Centralizada"
                                        className="img-centralizada"
                                      />
                                      <label htmlFor="central-image-upload" className="upload-icon-center">
                                        <i className="fas fa-upload"></i>
                                      </label>
                                      <input
                                        type="file"
                                        id="central-image-upload"
                                        accept="image/*"
                                        onChange={(e) => handleImageUpload(e, 'logo')} // Chama a ação `updateImageField` com o nome 'logo'
                                        style={{ display: "none" }}
                                      />
                                   </div>
                                </div>
                        </div>

                        <div className="mt-4">
                                    <label for="minimumOrder" className="form-label">Pedido mínimo</label>
                                    <div className="input-group mb-3">
                                        <span className="input-group-text">R$</span>
                                        <input type="text" className="form-control" id="minimumOrder"
                                        onChange={handleChange}
                                        value={data?.minimumOrderValue?.value}/>
                                    </div>
                                </div>
                                <div className="mb-3">
                                    <label for="storeID" className="form-label">ID da loja</label>
                                    <div className="input-group">
                                        <input type="text" className="form-control" id="storeID" value={data.id || ''} name="Id"
                                         disabled readonly/>
                                        <button className="btn btn-outline-secondary" type="button" id="copyButton">
                                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-clipboard" viewBox="0 0 16 16">
                                                <path d="M4 1.5H3a2 2 0 0 0-2 2V14a2 2 0 0 0 2 2h10a2 2 0 0 0 2-2V3.5a2 2 0 0 0-2-2h-1.5v-.5A1.5 1.5 0 0 0 9.5 0h-3A1.5 1.5 0 0 0 4.5 1V1.5zM6.5 1a.5.5 0 0 1 .5-.5h3a.5.5 0 0 1 .5.5V3H6V1zm-2 1h7v-.5a.5.5 0 0 1 .5-.5h-3a.5.5 0 0 1 .5.5V2H14a1 1 0 0 1 1 1v10a1 1 0 0 1-1 1H2a1 1 0 0 1-1-1V3a1 1 0 0 1 1-1h2.5v.5z"/>
                                            </svg>
                                        </button>
                                    </div>
                                </div>
                        </div>

                         <div className="save-button-container">
                                <button type="submit" className="btn btn-primary"  disabled={loading}>Salvar alterações</button>
                            </div>
                    </div>
                </div>
                </form>
            </div>
        </div>
    </div>)



}

const mapStateToProps = state => {

  return {
 // selectedMerchant: state.Merchants.selectedMerchant,
  data: state.FormProfile.data,
  imageFiles: state.FormProfile.imageFiles,
  loading:state.FormProfile.loading,
  }
}

function mapDispatchToProps (dispatch) {
  return{
   // loadingMerchant:(merchantId) => dispatch(loadingMerchant(merchantId)),
    UpdateFormField:(filed,value) =>dispatch(UpdateFormField(filed,value)),
    submitMerchants: (data, coverFile, logoFile) => dispatch(submitMerchants(data, coverFile, logoFile)),
    updateImageField:(fieldName,file,result) => dispatch(updateImageField(fieldName,file,result)), 
  };
}
const ConnectMerchantProfile = connect(mapStateToProps,mapDispatchToProps)(Profile); 
export {ConnectMerchantProfile as Profile}
