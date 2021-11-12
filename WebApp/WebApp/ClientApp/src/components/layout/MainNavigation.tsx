import * as React from "react";
import { Link } from "react-router-dom";
import { useContext } from "react";

import classes from './MainNavigation.module.css';
import FavoritesContext from "../../store/favourites-context";

function MainNavigation() {
    
    const favouritesCtx = useContext(FavoritesContext);
    
    return (
        <header className={classes.header}>
            <div className={classes.logo}>
                <ul>
                    <li>
                        <Link to={'/'}>FinanceWebApp</Link>
                    </li>
                </ul>
            </div>
            <nav>
                <ul>
                    <li>
                        <Link to={'/'}>All companies</Link>
                    </li>
                    <li>
                        <Link to={'/favourites'}>
                            Favourites
                            <span className={classes.badge}>
                                {favouritesCtx.totalFavorites}
                            </span>
                        </Link>
                    </li>
                </ul>
            </nav>
        </header>
    )
}

export default MainNavigation;