const requestWeatherForecastsType = 'REQUEST_WEATHER_FORECASTS';
const receiveWeatherForecastsType = 'RECEIVE_WEATHER_FORECASTS';
const rentVehicle = 'RENT_VEHICLE';

const initialState = {
    forecasts: [],
    clients: [],
    isLoading: false
};

export const actionCreators = {
    requestWeatherForecasts: startDateIndex => async (dispatch, getState) => {
        if (startDateIndex === getState().weatherForecasts.startDateIndex) {
          return;
        }

        dispatch({ type: requestWeatherForecastsType, startDateIndex });

        const url = `api/vehicle/`;
        const response = await fetch(url);
        const forecasts = await response.json();

        const url2 = `/api/client/`;
        const response2 = await fetch(url2);
        const clients = await response2.json();

        dispatch({ type: receiveWeatherForecastsType, startDateIndex, forecasts, clients });
    },
    postRentVehicle: (vehicleId, clientId) => async (dispatch, getState) => {
       
        const url = `/api/vehicle/`;

        const formData = new FormData();
        formData.append('vehicleId', vehicleId);
        formData.append('clientId', clientId);

        const response = await fetch(url, {
            method: 'put',
            body: formData
        });
        var result = response.status === 200 ? true : false;    
    }
};

export const reducer = (state, action) => {
  state = state || initialState;

  if (action.type === requestWeatherForecastsType) {
    return {
      ...state,
      startDateIndex: action.startDateIndex,
      isLoading: true
    };
  }

  if (action.type === receiveWeatherForecastsType) {
    return {
      ...state,
        startDateIndex: action.startDateIndex,
        forecasts: action.forecasts,
        clients: action.clients,
        isLoading: false
    };
  }

  if (action.type === rentVehicle) {
    return {
      ...state,
        result: action.result
    }
  }


  return state;
};
