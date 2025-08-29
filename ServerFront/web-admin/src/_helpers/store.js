import {legacy_createStore as createStore, applyMiddleware,compose } from 'redux';
import { thunk } from 'redux-thunk';
import rootReducer from '../_reducers';


const composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;

const Store = createStore(
    rootReducer ,composeEnhancers(applyMiddleware(thunk))
);
export default Store;