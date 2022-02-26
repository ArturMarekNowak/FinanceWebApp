import * as React from 'react';
import classes from './Layout.module.css';
import MainNavigation from "./MainNavigation";

function Layout(props: { children: React.ReactNode; }) {
    return (
        <div>
            <MainNavigation />
            <main className={classes.main}>
                {props.children}
            </main>
        </div>
    );
}

export default Layout;