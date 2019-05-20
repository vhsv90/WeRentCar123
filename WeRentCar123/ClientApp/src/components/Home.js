import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from '../store/HomeStore';
import {
    Card, CardImg, CardBody, CardTitle, CardSubtitle, Button, Container, Row, Col,
    CardText, Modal, ModalHeader, ModalFooter, ModalBody, Form, FormGroup, Label, Input,
} from 'reactstrap';

class Home extends Component {

    constructor(props) {
        super(props);
        this.state = {
            modal: false,
            modalHeader: "",
            modalSubheader: "",
            modalYear: 0,
            modalColor: "",
            modalNotes: "",
            modalDailyPrice: 0,
            modalRentedDays: 0,
            modalImage: ""
        };

        this.toggle = this.toggle.bind(this);
        this.submitFormHandler = this.submitFormHandler.bind(this);
    }

    componentDidMount() {
        this.ensureDataFetched();
    }

    componentDidUpdate() {
        this.ensureDataFetched();
    }

    ensureDataFetched() {
        const startDateIndex = parseInt(this.props.match.params.startDateIndex, 10) || 0;
        this.props.requestWeatherForecasts(startDateIndex);
    }

    toggle(pId) {
        var result = this.props.forecasts.find(forecast => (forecast.id === pId));        
        this.setState(prevState => ({
            modal: !prevState.modal,
            modalHeader: result === undefined ? "" : result.brand,
            modalSubheader: result === undefined ? "" : result.model,
            modalYear: result === undefined ? 0 : result.year,
            modalColor: result === undefined ? 0 : result.color,
            modalNotes: result === undefined ? 0 : result.notes,
            modalDailyPrice: result === undefined ? 0 : result.dailyPrice,
            modalRentedDays: result === undefined ? 0 : result.rentedDays,
            modalImage: result === undefined ? "" : result.imageSrc
        }));
    }

    submitFormHandler(event, props) {
        //event.preventDefault();
        const data = new FormData(event.target);
        var vehicleId = data.get('vehicleId');
        var clientId = data.get('clientId');
        this.props.postRentVehicle(vehicleId, clientId);
        this.ensureDataFetched();
    }

    render() {
        return (
            <div>
                <h1>Cars Rental</h1>
                <p>We offer car rental suppliers find you the best price [change this copy]</p>                
                <div>
                    <Container fluid>
                        <Row>
                            {this.props.forecasts.map(forecast =>
                                <Col sm="4">
                                    <div>
                                        <Card>
                                            <CardImg top width="100%" src={forecast.imageSrc} onClick={() => this.toggle(forecast.id)} alt="Card image cap" />
                                            <CardBody>
                                                <CardTitle>{forecast.brand}</CardTitle>
                                                <CardSubtitle>{forecast.model}</CardSubtitle>
                                                <div>
                                                    <Form onSubmit={this.submitFormHandler}>
                                                        <FormGroup check row>
                                                            <Label for="clientId">Select Client</Label>
                                                            <Input type="select" name="clientId" id="clientId" required>
                                                                {this.props.clients.map(client =>
                                                                    <option value={client.id}>{client.name}</option>
                                                                )}
                                                            </Input>
                                                            <Input type="text" name="vehicleId" id="vehicleId" value={forecast.id} hidden />
                                                            <Button type="submit" color="success">Rent Vehicle</Button>
                                                        </FormGroup>
                                                    </Form> 
                                                </div>                                                
                                                <Modal isOpen={this.state.modal} toggle={this.toggle}>
                                                    <ModalHeader>{this.state.modalHeader}</ModalHeader>
                                                    <ModalBody>
                                                        <Card>                                                            
                                                            <CardBody>
                                                                <CardTitle>{this.state.modalSubheader}</CardTitle>
                                                                <CardText>Year: {this.state.modalYear}</CardText>
                                                                <CardText>Color: {this.state.modalColor}</CardText>
                                                                <CardText>Daily Price: {this.state.modalDailyPrice}</CardText>
                                                                <CardText>Rented Days: {this.state.modalRentedDays}</CardText>
                                                                <CardText>Notes: {this.state.modalNotes}</CardText>                                                            
                                                                <CardImg bottom width="100%" src={this.state.modalImage} />
                                                            </CardBody>
                                                        </Card>
                                                    </ModalBody>
                                                    <ModalFooter>                                                        
                                                        <Button color="secondary" onClick={this.toggle}>Close</Button>
                                                    </ModalFooter>
                                                </Modal>
                                            </CardBody>
                                        </Card>
                                    </div>
                                </Col>
                            )}
                        </Row>
                    </Container>
                </div>
            </div>
        );
    }
}

export default connect(
    state => state.weatherForecasts,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(Home);
