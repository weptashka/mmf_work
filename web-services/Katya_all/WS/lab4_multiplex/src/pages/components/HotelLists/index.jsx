import { useEffect, useState } from "react";
import multyplexHotelService from "../../../services/multiplexHotel.service";

function HotelList() {
  const [hotels, setHotels] = useState([]);

  useEffect(()=>{
    (async ()=>{
      const hotelResults = await multyplexHotelService.getHotels()
      setHotels(hotelResults);
    })();
  }, []);

  if(!hotels){
    return null;
  }
  console.log(hotels[0])

  return (
    <div className="hotels">
        {hotels.map(()=> <div>{Math.random()}</div>)}
    </div>
  );
}

export default HotelList;
