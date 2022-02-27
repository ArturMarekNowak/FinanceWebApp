import * as React from 'react';
import CurrenciesList from "../components/currencies/CurrenciesList";
import { useState, useEffect } from "react";

function AllCurrenciesPage() {
    
    const [ areCurrenciesLoading, setAreCurrenciesLoading ] = useState(true);
    const [ loadedCurrencies, setLoadedCurrencies ] = useState([]);
    
    useEffect(() => {
        setAreCurrenciesLoading(true);
        fetch('http://localhost:8080/api/Currencies')
            .then(response => {
                return response.json();
            })
            .then(data => {
                const currencies = [];

                for (const key in data["value"]) {
                    const currency = {
                        id: key, 
                        DisplaySymbol: data["value"][key]["DisplaySymbol"],
                        Symbol: data["value"][key]["Symbol"],
                        Description: data["value"][key]["Description"]
                    };
                    currencies.push(currency)
                }
                
            setAreCurrenciesLoading(false);
            // @ts-ignore
                setLoadedCurrencies(currencies);
        });
    }, []);
    
    if(areCurrenciesLoading)
    {
        return (
          <section>
              <p>Loading...</p>
          </section>  
        );
    }
    
    return (
        <section>
            <CurrenciesList currencies={loadedCurrencies} />
        </section>
    );
}

export default AllCurrenciesPage