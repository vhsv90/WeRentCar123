const requestClientDataType = 'REQUEST_CLIENTS_DATA';

const initialState = {
    clients: []
};

export const actionCreators = {
    requestClientData: () => async (dispatch, getState) => {

        const url = `api/client/`;
        const response = await fetch(url);
        const clients = await response.json();

        dispatch({ type: requestClientDataType, clients });
    }
};

export const reducer = (state, action) => {

    state = state || initialState;

    if (action.type === requestClientDataType) {
        return {
            ...state,
            clients: action.clients
        };
    }

    return state;
};