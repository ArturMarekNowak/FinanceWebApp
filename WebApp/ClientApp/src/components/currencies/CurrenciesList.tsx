import * as React from 'react';
import CurrencyItem from './CurrencyItem';
import classes from './CurrenciesList.module.css';


function CurrenciesList(props: { currencies: { map: (arg0: (currency: any) => JSX.Element) => React.ReactNode; }; }) {
    return (
        <ul className={classes.list}>
            {props.currencies.map((currency) => (
                <CurrencyItem key={currency.id}
                              id={currency.id}
                              DisplaySymbol={currency.DisplaySymbol}
                              Symbol={currency.Symbol}
                              Description={currency.Description}
                />
            ))}
        </ul>
    );
}

export default CurrenciesList;