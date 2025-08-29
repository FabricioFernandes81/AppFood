import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import {App} from './App';
import { Provider } from 'react-redux';
import Store from './_helpers/store';
import { BrowserRouter } from 'react-router';
import { initializeAuth } from './_actions/authentication.action';
Store.dispatch(initializeAuth());
const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <Provider store={Store}>
     <BrowserRouter>
    <App />
    </BrowserRouter>
 </Provider>
);


