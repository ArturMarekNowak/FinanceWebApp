import 'bootstrap/dist/css/bootstrap.css';

import * as React from 'react';
import * as ReactDOM from 'react-dom';
import { BrowserRouter } from "react-router-dom";

import './App.css';
import App from './App';
import {FavoritesContextProvider} from "./store/favourites-context";

ReactDOM.render(
    <FavoritesContextProvider>
        <BrowserRouter>
            <App/>
        </BrowserRouter>
    </FavoritesContextProvider>, 
    document.getElementById('root')
);

