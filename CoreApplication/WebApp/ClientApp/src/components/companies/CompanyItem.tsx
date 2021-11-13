import * as React from 'react';
import { useContext } from 'react';

import Card from '../ui/Card';
import classes from './CompanyItem.module.css';
import FavoritesContext from '../../store/favourites-context';

function CompanyItem(props) {
    console.log(props)
    const favoritesCtx = useContext(FavoritesContext);

    const itemIsFavorite = favoritesCtx.itemIsFavorite(props.id);

    function toggleFavoriteStatusHandler() {
        if (itemIsFavorite) {
            favoritesCtx.removeFavorite(props.id);
        } else {
            favoritesCtx.addFavorite({
                id: props.id,
                CompanyId: props.CompanyId,
                Acronym: props.Acronym,
                FullName: props.FullName
            });
        }
    }

    return (
        <li className={classes.item}>
            <Card>
                <div className={classes.content}>
                    <h3>{props.Acronym}</h3>
                    <p>{props.FullName}</p>
                </div>
                <div className={classes.actions}>
                    <button>Details</button>
                    &nbsp;
                    <button onClick={toggleFavoriteStatusHandler}>
                        {itemIsFavorite ? 'Remove from Favorites' : 'To Favorites'}
                    </button>
                </div>
            </Card>
        </li>
    );
}

export default CompanyItem;