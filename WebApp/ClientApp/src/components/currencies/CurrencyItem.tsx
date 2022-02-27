// noinspection JSRemoveUnnecessaryParentheses

import * as React from 'react';
import { useContext } from 'react';

import Card from '../ui/Card';
import classes from './CurrencyItem.module.css';
import FavoritesContext from '../../store/favourites-context';

function CurrencyItem(props: { id: any; DisplaySymbol: React.ReactNode; Symbol: React.ReactNode; Description: React.ReactNode}) {
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
                DisplaySymbol: props.DisplaySymbol,
                Symbol: props.Symbol,
                Description: props.Description
            });
        }
    }


    // @ts-ignore
    if (itemIsFavorite) {
        return (
            <li className={classes.item}>
                <Card>
                    <div className={classes.content}>
                        <h3>{props.Symbol}</h3>
                        <p>{props.DisplaySymbol}</p>
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
                        <h3>{props.Symbol}</h3>
                        <p>{props.DisplaySymbol}</p>
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

export default CurrencyItem;