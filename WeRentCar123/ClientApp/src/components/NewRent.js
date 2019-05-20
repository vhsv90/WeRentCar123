import React from 'react';
import { connect } from 'react-redux';

const NewRent = props => (
    <div>
        <h1>New Page</h1>
        <p>Welcome to your new rent page</p>
    </div>
);

export default connect()(NewRent);
