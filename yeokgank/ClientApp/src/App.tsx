import * as React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import TradeInfoPage from './components/TradeInfoPage';
import RegionCodePage from './components/RegionCodePage';


import './index.css'

export default () => (
    <Layout>
        {/*exact : 디폴드 경로 */}
        <Route exact path='/' component={Home} />
        <Route path='/apt' component={TradeInfoPage} />
        <Route path='/region' component={RegionCodePage} />
        {/* <Route path='/region-data/:pageIndex?' component={Region} /> */}
    </Layout>
);
