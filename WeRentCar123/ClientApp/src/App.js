import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
// Views
import Home from './components/Home';
import Clients from './components/Clients';

export default () => (
  <Layout>
    <Route exact path='/' component={Home} />
    <Route path='/clients' component={Clients} />
  </Layout>
);
