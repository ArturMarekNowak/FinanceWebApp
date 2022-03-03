import * as React from 'react';
import ReactApexChart from 'react-apexcharts';
import { useState, useEffect } from "react";

function DetailsPage() {
    
    const [ isCurrencyLoading, setIsCurrencyLoading ] = useState(true);
    const [ loadedCurrency, setLoadedCurrency ] = useState([]);

    useEffect(() => {
        setIsCurrencyLoading(true);
        fetch('http://localhost:8080/api/Prices?symbol=BINANCE:BTCUSDT')
            .then(response => {
                return response.json();
            })
            .then(data => {
                const currencyPrices = [];

                console.log(data);
                
                for (const key in data["value"]) {
                    const currencyPrice = {
                        x: new Date(data["value"][key]["TimeStamp"]),
                        y: [data["value"][key]["OpeningPrice"], data["value"][key]["HighestPrice"], 
                            data["value"][key]["LowestPrice"], data["value"][key]["ClosingPrice"]]
                    };
                    currencyPrices.push(currencyPrice)
                }

                setIsCurrencyLoading(false);
                // @ts-ignore
                setLoadedCurrency(currencyPrices);
                
                console.log(loadedCurrency);
            });
    }, []);
    
    const options: any = {
        chart: {
            type: 'candlestick',
                height: 350
        },
        title: {
            text: 'CandleStick Chart',
                align: 'left'
        },
        xaxis: {
            type: 'datetime'
        },
        yaxis: {
            tooltip: {
                enabled: true
            }
        }
    }
    
    const series = [{ data: loadedCurrency }]

    return (
        <ReactApexChart options={options} series={series} type={"candlestick"} height={350}/>
    );
}

export default DetailsPage;