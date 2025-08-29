import React,{use, useState} from "react";
import MapAddress from "./MapAddress";
import { connect, useSelector, useDispatch } from 'react-redux';
import { Link } from "react-router";


const Address = () => {
const [addressData, setAddressData] = useState(null);
const [Editlocation, setEditLocation] = useState(false);
//{showLeft && <div className="box left">Box Esquerdo</div>}
const {data} = useSelector((state)=> state.FormProfile);


const editarLocalizacaoManual=()=>{
      setEditLocation(true);
}
    return <div className="Addresscontainer">
       <MapAddress Editlocation={Editlocation}/>
      {Editlocation || <div className="viewAdrress">
        <h2>Endereço do estabelecimento</h2>
        <p>{data?.address}</p>
        <p>CEP - {data.zipCode}</p><p>{data?.city} , {data?.state}</p>
        <Link to="/merchant/profile/address/edit" onClick={editarLocalizacaoManual}>
        <button className="edit-button" 
        color="secondary" type="button" 
        data-testid="profile-address-edit-button">Editar Endereço</button>
        </Link>
      </div>}

    </div>
}



export default Address;