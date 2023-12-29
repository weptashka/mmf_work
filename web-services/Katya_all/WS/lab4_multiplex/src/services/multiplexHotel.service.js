import async from 'async';

import bookingService from './booking.service';
import pricelineService from './priceline.service';

class MultiPlexHotelService{
   getHotels () {
    const requests = [
      () => bookingService.getUnifiedHotels(),
      () => pricelineService.getUnifiedHotels(),
    ];
  
    const executeRequest = (request, callback) => {  
      request()
        .then((response) => {
          callback(null, response);
        })
        .catch((error) => {
          callback(error);
        });
    };
  
    return async.parallel(
      requests.map((request) => {
        return async.parallel.bind(null, {
          request: async.apply(executeRequest, request),
        });
      }),
      (error, results) => {
        if (error) {
          console.error(error);
        } else {
          console.log(results.map((result) => result.request));
        }
      }
    );
  };
  
}
export default new MultiPlexHotelService();
