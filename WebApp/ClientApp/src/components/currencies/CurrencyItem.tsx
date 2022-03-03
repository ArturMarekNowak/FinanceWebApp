// noinspection JSRemoveUnnecessaryParentheses

import * as React from 'react';
import { useContext } from 'react';

import Card from '../ui/Card';
import classes from './CurrencyItem.module.css';
import FavoritesContext from '../../store/favourites-context';
import {Link} from "react-router-dom";

function CurrencyItem(props: { id: any; DisplaySymbol: React.ReactNode; Symbol: React.ReactNode; Description: React.ReactNode}) {
   
        return (
            <li className={classes.item}>
                <Card>
                    <div className={classes.content}>
                        <h3>{props.Symbol}</h3>
                        <p>{props.DisplaySymbol}</p>
                    </div>
                    <div className={classes.actions}>
                        &nbsp;
                        <button>
                            <Link to={`/details/${props.Symbol}`}>
                                {'Details'}
                            </Link>
                        </button>
                    </div>
                </Card>
            </li>
        );
}

export default CurrencyItem;