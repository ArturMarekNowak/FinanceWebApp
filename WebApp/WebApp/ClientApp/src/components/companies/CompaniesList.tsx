import * as React from 'react';
import CompanyItem from './CompanyItem';
import classes from './CompaniesList.module.css';

function CompaniesList(props) {
    return (
        <ul className={classes.list}>
            {props.companies.map((company) => (
                <CompanyItem
                    key={company.id}
                    id={company.id}
                    CompanyId={company.CompanyId}
                    Acronym={company.Acronym}
                    FullName={company.FullName}
                />
            ))}
        </ul>
    );
}

export default CompaniesList;