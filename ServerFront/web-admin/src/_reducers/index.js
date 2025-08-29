import { combineReducers } from "redux";
import { Authenticacao } from "./authentication.reducer";
import { Merchants } from "./merchants.reducer";
import { MerchantsProfile } from "./api.requestMerchants";
import { FormAddresss } from "./reducer.address";
import { FormProfile } from "./redurce.profile";
import { MenuList } from "./cardapios.reducer";
import { CategoriaList } from "./categoria.redurce";
import { catalogoSelecionadoReducer } from "./catalogoSelecionado.reducer";
import { FormCategoria } from "./CategoryForm.Reducer";
import { ProductsReduce } from "./produtos.reducer";
import { ItemsRedurce } from "./ItemsCardapio.redurce";
const rootReducer = combineReducers({
  Authenticacao,
  Merchants,
  MerchantsProfile,
  FormProfile,
  FormAddresss,
  MenuList,
  CategoriaList,
  CatalogoSelecionado:catalogoSelecionadoReducer,
  FormCategoria,
  ProductsReduce,
  ItemsRedurce,
});


export default rootReducer;