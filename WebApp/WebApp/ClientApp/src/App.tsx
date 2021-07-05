import * as React from 'react';
import { Route } from 'react-router';
import Layout from './components/NavMenu/Layout';
import Home from './components/Home/Home';
import Counter from './components/Home/Counter';
import FetchData from './components/Home/FetchData';
import Login from './components/Home/Login';
import Register from './components/Home/Register';

import './custom.css'

export default () => (
    <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/Home/counter' component={Counter} />
        <Route path='/Home/fetch-data/:startDateIndex?' component={FetchData} />
        <Route path='/Home/login' component={Login} />
        <Route path='/Home/register' component={Register} />
    </Layout>
);
