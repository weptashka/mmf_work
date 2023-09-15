import React from 'react';
import * as Api from 'typescript-fetch-api'
import { withRouter } from "react-router";
import { Link } from "react-router-dom";
import Moment from 'react-moment';
import moment from 'moment';


const api = new Api.DefaultApi()

class WeeklyScheduler extends React.Component {

    constructor(props) {
        super(props);
        const dateParam = this.props.match?.params.id || moment().format('YYYY-MM-DD');
        const parsedDate = moment(dateParam, "YYYY-MM-DD")

        const nearestWeekend = parsedDate.startOf('week').isoWeekday(0);
        const endDate = moment(nearestWeekend).add(6, 'day');

        console.log("Enddate", nearestWeekend.toString(), endDate.toString())

        const startWeek = nearestWeekend.format("YYYY-MM-DD")
        const endWeek = endDate.format("YYYY-MM-DD")



        // TODO reuse data to service from https://citydog.by/post/play-musykanty/
        this.state = {
            events: [],
            start: startWeek,
            end: endWeek

        };

        console.log(this.state.start, this.state.end)
        this.handleReload = this.handleReload.bind(this);
        this.handleReload();
    }


    async handleReload(event) {
        const response = await api.events({ date: this.state.startWeek });
        this.setState({ events: response });
    }


    render() {
        return <div>
            {/*<button onClick={this.handleReload}>Reload</button>*/}
            <h2>Weekly highlights</h2>
            <h3>Upcoming events from  <Moment format="YYYY/MM/DD">{this.state.start}</Moment> to <Moment format="YYYY/MM/DD">{this.state.end}</Moment> </h3>
            <div>
                {this.state.events.map(
                    (event) =>
                        <div key={event.id}>{event.id} {event.band}  is performing on <Link to={`/timetable/${event.date}`}>  {event.date} </Link>  at {event.time} in {event.place}</div>)}
            </div>
        </div>
    }
}

export default withRouter(WeeklyScheduler);