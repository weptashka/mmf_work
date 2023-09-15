import logo from './logo.svg';
import './App.css';
import React from 'react';
import WeeklyScheduler from './components/WeeklyScheduler';
import CurrentEventsProgress from 'components/CurrentEventsProgress';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link,
  Redirect,  
  useLocation
} from "react-router-dom";
import moment from 'moment'

function App() {
  return (

<Router>
    <div>
        <nav>
          <ul>
            <li>
              <Link to="/">Home</Link>
            </li>
            <li>
              <Link to="/timetable">Day scheduler</Link>
            </li>
            <li>
              <Link to="/highlights">Weekly highlights</Link>
            </li>
            <li>
              <Link to="/about">About</Link>
            </li>
          </ul>
        </nav>

        {/* A <Switch> looks through its children <Route>s and
            renders the first one that matches the current URL. */}
      <div className="App">
         
        <section> 
          <Switch>
            <Route path="/about">
              <About />
            </Route>
            <Route path="/timetable/:id">
              <CurrentEventsProgress />
            </Route>
            <Route path="/timetable">
              <Redirect to={`/timetable/${moment().format('YYYY-MM-DD')}`} />
            </Route>
            
            <Route path="/highlights">
              <WeeklyScheduler/>
            </Route>
            
            <Route path="/">
              <h1>Home</h1>
              Welcome to our service. Please explore <Link to="/highlights">highlights</Link> per week, or <Link to="/timetable">today scheduler</Link>
            </Route>

            <Route path="*">
              <NoMatch />
            </Route>
            
          </Switch>
          

        </section>
      </div>
    </div>
    </Router>
  );
}
function NoMatch() {
  let location = useLocation();

  return (
    <div>
      <h3>
        No match for <code>{location.pathname}</code>
      </h3>
    </div>
  );
}

function About() {
  let location = useLocation();

  return (
    <div>
      <h2>
        About us
      </h2>
      <p>Here is the description of the service and necessary terms.</p>
    </div>
  );
}
 
export default App;