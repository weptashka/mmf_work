import React from 'react';
import * as Api from 'typescript-fetch-api'
import { withRouter } from "react-router";
import moment from 'moment'
import Moment from 'react-moment';


const api = new Api.DefaultApi()

class CurrentEventsProgress extends React.Component {

    constructor(props) {
        super(props);
        const id =  this.props.match?.params.id || moment().format('YYYY-MM-DD');
        console.log(id);

        

        this.state = { 
            events: [{id:'xyz1', date: "2021-04-21", band: "Какора", image: "", time: "19:00", place:"Cultural Hub Ok16"}],
            date: id 
        };

        this.handleReload = this.handleReload.bind(this);
        this.handleReload();
    }


    async handleReload(event) {
        //const response = await api.events({ date: '2021-03-25'/*this.state.targetDate*/ });
        //this.setState({ events: response });
    }


    render() {
        return <div>
            {/*<button onClick={this.handleReload}>Reload</button> */}
            <h2>Day scheduler</h2>
            <h3>Upcoming events on <Moment format="YYYY/MM/DD">{this.state.date}</Moment> </h3>
            <ul>
               {this.state.events.map(
                   (event) => 
                        <li key={event.id}>{event.time}:  {event.band} is performing in {event.place}</li>)}
            </ul>
        </div>
    }
}

export default withRouter(CurrentEventsProgress);