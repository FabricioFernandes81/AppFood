import React, { useEffect, useState, useRef } from "react";
import { FormularioEditMap } from "./FormularioEditMap";
import { parseISO3166 } from "../_helpers/functions";
import { useSelector, useDispatch } from 'react-redux';
import { loadAddress, updateFormField, resetFrom, submitAddress } from "../_actions/address.action";
import { Link } from "react-router";
import MaperService from "../_services/MaperServices";
import { getNonEditableMapProps } from "../_helpers/mapHelpers";
import { MapContainer, TileLayer, Marker, Popup, useMapEvents, useMap, ZoomControl } from "react-leaflet";
import "leaflet/dist/leaflet.css";
import L from "leaflet";
import maperService from "../_services/MaperServices";
delete L.Icon.Default.prototype._getIconUrl;
L.Icon.Default.mergeOptions({
  iconRetinaUrl: require("leaflet/dist/images/marker-icon-2x.png"),
  iconUrl: require("leaflet/dist/images/marker-icon.png"),
  shadowUrl: require("leaflet/dist/images/marker-shadow.png"),
});




export default function MapAddress({ Editlocation }) {
  const [position, setPosition] = useState([0, 0]);
  const { selectedMerchant } = useSelector((state) => state.Merchants);
  const { data } = useSelector((state) => state.FormAddresss);
  const [etapa, setEtapa] = useState(1);
  const dispatch = useDispatch();

  const [input, setInput] = useState('');
  const [zoomin, setZoomIn] = useState(15);
  const [sugestoes, setSugestoes] = useState([]);

  useEffect(() => {
    if (selectedMerchant?.id) {
      dispatch(loadAddress(selectedMerchant.id));
      setPosition([data.latitude, data.longitude]);
    }
  }, [dispatch, selectedMerchant?.id]);

  const MapCenter = ({ newPosition }) => {
    const map = useMap();
    useEffect(() => {
      if (newPosition) {
        map.flyTo(newPosition, 18);
      }
    }, [newPosition, map]);
    return null;
  };

  const handleMapClick = async (e) => {
    const lat = e.latlng.lat;
    const lng = e.latlng.lng;
    setPosition([lat, lng]);
    maperService.BuscaCordenadas(lat, lng).then(respo => {
      if (respo && respo.address) {

        dispatch(updateFormField('latitude', parseFloat(respo.lat)));
        dispatch(updateFormField('longitude', parseFloat(respo.lon)));
        // setPosition([parseFloat(local.lat), parseFloat(local.lon)]);
        const isoCode = respo?.address?.["ISO3166-2-lvl4"];
        console.log("Código ISO:", isoCode); // Resultado: "Código ISO: BR-RS"

        const { countryCode, stateCode } = parseISO3166(isoCode);
        console.log("Estado:", stateCode);
        dispatch(updateFormField('latitude', parseFloat(respo.lat)));
        dispatch(updateFormField('longitude', parseFloat(respo.lon)));
        dispatch(updateFormField('address', respo.address.road || "")); //Adicionar Informaçoes do endereço
        dispatch(updateFormField('district', respo.address.suburb || respo.address.neighbourhood || ''));
        dispatch(updateFormField('zipCode', respo.address.postcode || ""));
        dispatch(updateFormField('state', stateCode || ""));
        dispatch(updateFormField('country', countryCode || ""));
        dispatch(updateFormField('city', respo.address.city_district || respo.address.city || respo.address.municipality || ""));

      }
    }).catch(error => {
      console.log("Erro no Localizar coodenadas", error);
    })
  };

  const LocationMarker = () => {
    useMapEvents({
      click(e) {
        handleMapClick(e);
      },
    });
    return position === null ? null : (
      <Marker position={position}>
        <Popup>{position || "Localização selecionada."}</Popup>
      </Marker>
    );
  }

  const isValidCoordinates =
    typeof data?.latitude === 'number' &&
    typeof data?.longitude === 'number' &&
    !isNaN(data.latitude) &&
    !isNaN(data.longitude);

  if (!isValidCoordinates) {
    return <p>Carregando mapa...</p>; // ou um Spinner, Skeleton, etc.
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
  const buscarCep = async (texto) => {
    maperService.BuscarSugestoes(texto)
      .then(data => {
        const listaCidades = (data ?? []).map((item, index) => {
          const isoCode = item?.address?.["ISO3166-2-lvl4"];
          console.log("ISO3166-2-lvl4:", isoCode);

          const { countryCode, stateCode } = parseISO3166(isoCode);
          console.log("Estado:", stateCode);

          return {
            id: index + 1,
            zipCode: item.address?.postcode,
            state: stateCode || '',
            city: item.address.city || item.address.town || item.address.village || item.address.municipality,
            latitude: item.lat,
            longitude: item.lon,
          };
        });
        setSugestoes(listaCidades);
      })
      .catch(error => {
        console.error('Erro ao buscar sugestões:', error);
      });
  };

  const buscarEndereco = async (valor) => {

    maperService.Buscar_Mapa(valor).then(dados => {
      dispatch(resetFrom());
      const local = dados[0];
      dispatch(updateFormField('latitude', parseFloat(local.lat)));
      dispatch(updateFormField('longitude', parseFloat(local.lon)));
      setPosition([parseFloat(local.lat), parseFloat(local.lon)]);
      const isoCode = local?.address?.["ISO3166-2-lvl4"];
      console.log("Código ISO:", isoCode); // Resultado: "Código ISO: BR-RS"

      const { countryCode, stateCode } = parseISO3166(isoCode);
      console.log("Estado:", stateCode);

      dispatch(updateFormField('address', local.address.road || "")); //Adicionar Informaçoes do endereço
      dispatch(updateFormField('zipCode', local.address.postcode || ""));
      dispatch(updateFormField('state', stateCode || ""));
      dispatch(updateFormField('country', countryCode || ""));

      dispatch(updateFormField('city', local.address.city_district || local.address.city || local.address.municipality || ""));

      setSugestoes([]);
      avancar();
    }).catch(error => {
      console.log("ERRO MAPERSERVICE", error);
    })
  };

  const handleChange = (e) => {
    const { name, value } = e.target;
    dispatch(updateFormField(name, value));
  };

  const handleConfirmar = () => {
    maperService.BuscarCompleta(data)
      .then(receive => {
        console.log("Receive", receive);

        if (receive && receive.length > 0) {
          setPosition([parseFloat(receive[0].lat), parseFloat(receive[0].lon)]);
          avancar();
        } else {
          console.warn("Resposta vazia de BuscarCompleta");
        }
      })
      .catch(error => {
        console.log("Erro na busca completa", error);
      });

  }

  const handleSubimit = (e) => {
    e.preventDefault();
    dispatch(submitAddress(selectedMerchant.id, data));
  }

  return (
     <div className="mapcont">
        <div className="map-container">
          <MapContainer
            center={position}
            zoom={zoomin}
            style={{ height: "100%", width: "100%" }}
            zoomControl={false}
          >
            <MapCenter newPosition={position} />
            <TileLayer
              url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
              attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
            />
            <LocationMarker />
            <ZoomControl position="bottomright" />
          </MapContainer>
                    {etapa !== 3 && (
              <div className="map-overlay-blocker" />
            )}
        </div>

      {Editlocation && (
        <div className="address-info">
          <div className="container">
            {/* Etapas visuais */}
            <div className="barra-etapas">
              {[1, 2, 3].map((n) => (
                <div
                  key={n}
                  className={`barra ${etapa === n ? 'ativa' : ''}`}
                  onClick={() => setEtapa(n)}
                />
              ))}
            </div>

            <p>Etapa {etapa} de 3</p>

            {/* Etapa 1: Busca por endereço */}
            {etapa === 1 && (
              <>
                <h3>Buscar endereço</h3>
                <label>CEP:</label>
                <input
                  type="text"
                  name="input"
                  placeholder="Digite o CEP ou endereço"
                  style={{ width: '100%', padding: '8px', marginTop: '8px' }}
                  onChange={(e) => buscarCep(e.target.value)}
                />

                <div style={{ marginTop: '8px' }}>
                  {sugestoes.map((list) => (
                    <div
                      key={list.id}
                      onClick={() => buscarEndereco(list)}
                      style={{
                        cursor: 'pointer',
                        backgroundColor: '#eaeaea',
                        marginBottom: '4px',
                        padding: '4px',
                      }}
                    >
                      {list.id} - {list.city} - {list.state}
                    </div>
                  ))}
                </div>
              </>
            )}

            {/* Etapa 2: Confirmação de endereço */}
            {etapa === 2 && (
              <div>
                <h3>Confirmar endereço</h3>

                <div className="field form-group">
                  <label>Logradouro</label>
                  <input
                    name="address"
                    className="field__input form-control"
                    value={data.address}
                    onChange={handleChange}
                  />
                </div>

                <div className="field form-group">
                  <label>Número</label>
                  <input
                    name="streetNumber"
                    className="field__input form-control"
                    value={data.streetNumber}
                    onChange={handleChange}
                  />
                </div>

                <div className="field form-group">
                  <label>Complemento</label>
                  <input
                    name="complement"
                    className="field__input form-control"
                    maxLength="45"
                    value={data.complement}
                    onChange={handleChange}
                  />
                </div>

                <div className="field form-group">
                  <label>Bairro</label>
                  <input
                    name="district"
                    className="field__input form-control"
                    value={data.district}
                    onChange={handleChange}
                  />
                </div>

                <div className="field form-group">
                  <label>CEP</label>
                  <input
                    name="zipCode"
                    className="field__input form-control"
                    value={data.zipCode}
                    readOnly
                  />
                </div>

                <div className="field form-group">
                  <label>Cidade e Estado</label>
                  <div>{data.city}, {data.state}</div>
                </div>

                <div style={{ marginTop: '16px' }}>
                  <button type="button" className="edit-button" onClick={handleConfirmar}>
                    Confirmar
                  </button>
                  <button type="button" className="edit-button" onClick={voltar}>
                    Voltar
                  </button>
                </div>
              </div>
            )}

            {/* Etapa 3: Confirmação final e envio */}
            {etapa === 3 && (
              <form onSubmit={handleSubimit} className="profile-address-edit-form" autoComplete="off">
                <h3>Confirmar posição no mapa</h3>

                <div className="profile-address-edit__confirm-address">
                  <span>{data.address}, {data.streetNumber}</span><br />
                  <span>{data.district}</span><br />
                  <span>{data.city}, {data.state}</span><br />
                  <span>CEP {data.zipCode}</span>
                </div>

                <div style={{ marginTop: '16px' }}>
                  <button type="submit" className="edit-button">
                    Salvar novo endereço
                  </button>
                  <button
                    type="button"
                    className="edit-button"
                    onClick={cancelar}
                  >
                    Cancelar
                  </button>
                </div>
              </form>
            )}

            {/* Botão "Próximo" para etapas 1 */}
            {etapa === 1 && (
              <div style={{ marginTop: '16px' }}>
                <button className="edit-button" onClick={avancar}>
                  Próximo
                </button>
              </div>
            )}
          </div>
        </div>
      )}
    </div>
  );
}
