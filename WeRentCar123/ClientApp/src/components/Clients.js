import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from '../store/ClientStore';

class ClientsData extends Component {

    constructor(props) {
        super(props);
        this.state = {};
    }

    componentDidMount() {
        this.ensureDataFetched();
    }

    componentDidUpdate() {
        this.ensureDataFetched();
    }

    ensureDataFetched() {
        this.props.requestClientData();
    }

    render() {
        return (
            <div>
                <h1>Clients</h1>
                <p>This component demonstrates fetching data from the server and working with URL parameters.</p>
                <table className='table table-striped'>
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Name</th>
                            <th>Last Name</th>
                            <th>Phone Number</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.props.clients.map(client =>
                            <tr key={client.id}>
                                <td>{client.id}</td>
                                <td>{client.name}</td>
                                <td>{client.lastName}</td>
                                <td>{client.phoneNumber}</td>
                            </tr>
                        )}
                    </tbody>
                </table>
                </div>
        );
    }
}

export default connect(
  state => state.clients,
  dispatch => bindActionCreators(actionCreators, dispatch)
)(ClientsData);
