import * as React from 'react'
import { createContext, useState } from 'react';

const FavoritesContext = createContext({
    favorites: [],
    totalFavorites: 0,
    addFavorite: (favoriteCompany) => {},
    removeFavorite: (companyId) => {},
    itemIsFavorite: (companyId) => {}
});

export function FavoritesContextProvider(props) {
    const [userFavorites, setUserFavorites] = useState([]);

    function addFavoriteHandler(favoriteCompany) {
        setUserFavorites((prevUserFavorites) => {
            return prevUserFavorites.concat(favoriteCompany);
        });
    }

    function removeFavoriteHandler(companyId) {
        setUserFavorites(prevUserFavorites => {
            return prevUserFavorites.filter(company => company.id !== companyId);
        });
    }

    function itemIsFavoriteHandler(companyId) {
        return userFavorites.some(company => company.id === companyId);
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