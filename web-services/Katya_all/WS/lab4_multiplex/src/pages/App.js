import promo from './promo.jpg';
import './App.css';
import HotelList from './components/HotelLists'

function App() {
  return (
    <div className="app">
      <section className="section">
        <img className="app-header" alt="" src={promo}/>
      </section>
      <section className="section">
        <h1 className="section-header">Our most popular Hotels</h1>

        <HotelList/>
      </section>
    </div>
  );
}

export default App;
