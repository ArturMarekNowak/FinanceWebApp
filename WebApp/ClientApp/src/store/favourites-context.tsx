import * as React from 'react'
import { createContext, useState } from 'react';

const FavoritesContext = createContext({
    favorites: [],
    totalFavorites: 0,
    addFavorite: (favoriteCurrencies: any) => {},
    removeFavorite: (currencyId: any) => {},
    itemIsFavorite: (currencyId: any) => {}
});

export function FavoritesContextProvider(props: { children: React.ReactNode; }) {
    const [userFavorites, setUserFavorites] = useState([]);

    function addFavoriteHandler(favoriteCurrency: ConcatArray<never>) {
        setUserFavorites((prevUserFavorites) => {
            return prevUserFavorites.concat(favoriteCurrency);
        });
    }

    function removeFavoriteHandler(currencyId: any) {
        setUserFavorites(prevUserFavorites => {
            // @ts-ignore
            return prevUserFavorites.filter(currency => currency.id !== currencyId);
        });
    }

    function itemIsFavoriteHandler(currencyId: any) {
        // @ts-ignore
        return userFavorites.some(currency => currency.id === currencyId);
    }

    const context = {
        favorites: userFavorites,
        totalFavorites: userFavorites.length,
        addFavorite: addFavoriteHandler,
        removeFavorite: removeFavoriteHandler,
        itemIsFavorite: itemIsFavoriteHandler
    };

    return (
        <FavoritesContext.Provider value={context}>
            {props.children}
        </FavoritesContext.Provider>
    );
}

export default FavoritesContext;