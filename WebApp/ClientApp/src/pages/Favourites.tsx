import * as React from 'react';
import { useContext } from "react";
import FavoritesContext from "../store/favourites-context";
import CurrenciesList from "../components/currencies/CurrenciesList";

function FavouritesPage() {
    const favouritesCtx = useContext(FavoritesContext);
   
    let content;
    
    if(favouritesCtx.totalFavorites === 0) {
        content = <p>You have got no favourties yet</p>
    }
    else
    {
        content = <CurrenciesList currencies={favouritesCtx.favorites} />
    }
    
    return (
        <section>
            <h1>FavouritesPage</h1>
            {content}
        </section>
    );
}

export default FavouritesPage