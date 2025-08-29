import { text } from "@fortawesome/fontawesome-svg-core";
import handleResponse from "../_helpers/HandleResponse";

const API_MAPPER = 'https://nominatim.openstreetmap.org';

class MaperService {
    constructor(){

    }

    async BuscarSugestoes (texto){
                if(texto.length < 3){
                    return
                }
    const response = await fetch(`${API_MAPPER}/search?q=${encodeURIComponent(texto)}&format=json&addressdetails=1&limit=5`);
           
    return handleResponse(response)
    }

    async Buscar_Mapa(texto){
             console.log("Seleção da List, ", texto);
        const response =  await fetch(`${API_MAPPER}/search?q=${texto.city}&format=json&addressdetails=1&limit=1`);
        return handleResponse(response);
    }


        async BuscarCompleta (form){
       const params = {
  street: `${form.address} ${form.streetNumber}`.trim(),
  city: form.city,
  state: form.state,
  country: 'Brazil',
  postalcode: form.ZipCode,
  format: 'json',
  addressdetails: '1',
  limit: '1'
};


const filteredParams = Object.fromEntries(
  Object.entries(params).filter(([_, value]) => Boolean(value))
);


const queryString = new URLSearchParams(filteredParams).toString();
  const response =  await fetch(`${API_MAPPER}/search?${queryString}&format=json&addressdetails=1&limit=1`);
        return handleResponse(response);
}
         async BuscaCordenadas(lat,lng){
          const response =  await fetch(`${API_MAPPER}/reverse?format=jsonv2&lat=${lat}&lon=${lng}`);
            return handleResponse(response);

         }

}
/*const MaperService = new MaperService();
export default MaperService;*/
const maperService = new MaperService(); // ← Nome diferente da classe
export default maperService;

