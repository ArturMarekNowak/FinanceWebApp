import * as React from 'react';
import CompaniesList from "../components/companies/CompaniesList";
import { useState, useEffect } from "react";

function AllCompaniesPage() {
    
    const [ areCompaniesLoading, setAreCompaniesLoading ] = useState(true);
    const [ loadedCompanies, setLoadedCompanies ] = useState([]);
    
    useEffect(() => {
        setAreCompaniesLoading(true);
        fetch('https://localhost:5001/api/Companies')
            .then(response => {
                return response.json();
            })
            .then(data => {
                
            const companies = [];

                for (const key in data["value"]) {
                    const company = {
                        id: key, 
                        CompanyId: data["value"][key]["CompanyId"],
                        Acronym: data["value"][key]["Acronym"],
                        FullName: data["value"][key]["FullName"]
                    };
                    companies.push(company)
                }
                
            setAreCompaniesLoading(false);
            setLoadedCompanies(companies);
        });
    }, []);
    
    if(areCompaniesLoading)
    {
        return (
          <section>
              <p>Loading...</p>
          </section>  
        );
    }
    
    return (
        <section>
            <CompaniesList companies={loadedCompanies} />
        </section>
    );
}

export default AllCompaniesPage