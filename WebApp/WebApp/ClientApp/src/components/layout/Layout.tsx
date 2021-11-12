import * as React from 'react';
import classess from './Layout.module.css';
import MainNavigation from "./MainNavigation";

function Layout(props) {
    return (
        <div>
            <MainNavigation />
            <main className={classess.main}>
                {props.children}
            </main>
        </div>
    );
}

export default Layout;