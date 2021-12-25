import * as React from 'react'
import { createContext, useState } from 'react';

const FavoritesContext = createContext({
    favorites: [],
    totalFavorites: 0,
    addFavorite: (favoriteCompany: any) => {},
    removeFavorite: (companyId: any) => {},
    itemIsFavorite: (companyId: any) => {}
});

export function FavoritesContextProvider(props: { children: React.ReactNode; }) {
    const [userFavorites, setUserFavorites] = useState([]);

    function addFavoriteHandler(favoriteCompany: ConcatArray<never>) {
        setUserFavorites((prevUserFavorites) => {
            return prevUserFavorites.concat(favoriteCompany);
        });
    }

    function removeFavoriteHandler(companyId: any) {
        setUserFavorites(prevUserFavorites => {
            // @ts-ignore
            return prevUserFavorites.filter(company => company.id !== companyId);
        });
    }

    function itemIsFavoriteHandler(companyId: any) {
        // @ts-ignore
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