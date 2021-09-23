import * as React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import Counter from './components/Counter';
import FetchData from './components/FetchData';
import Region from './components/Region';
import Apt from './components/Apt'


import './custom.css'

export default () => (
    <Layout>
        {/*exact : 디폴드 경로 */}
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/apt' component={Apt} />
        <Route path='/region-data/:pageIndex?' component={Region} />
        <Route path='/fetch-data/:startDateIndex?' component={FetchData} />
    </Layout>
);
