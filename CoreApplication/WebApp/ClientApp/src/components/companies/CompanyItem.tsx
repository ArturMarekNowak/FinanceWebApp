// noinspection JSRemoveUnnecessaryParentheses

import * as React from 'react';
import { useContext } from 'react';

import Card from '../ui/Card';
import classes from './CompanyItem.module.css';
import FavoritesContext from '../../store/favourites-context';

function CompanyItem(props: { id: any; CompanyId: any; Acronym: React.ReactNode; FullName: React.ReactNode; }) {
    console.log(props)
    const favoritesCtx = useContext(FavoritesContext);

    const itemIsFavorite = favoritesCtx.itemIsFavorite(props.id);

    function toggleFavoriteStatusHandler() {
        // @ts-ignore
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


    // @ts-ignore
    if (itemIsFavorite) {
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
                            {'Remove from Favorites'}
                        </button>
                    </div>
                </Card>
            </li>
        );
    } else {
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
                            {'To Favorites'}
                        </button>
                    </div>
                </Card>
            </li>
        );
    }
}

export default CompanyItem;