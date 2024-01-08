import axios from 'axios';

class BookingService {
  constructor() {
    this.api = axios.create({
      baseUrl: 'https://apidojo-booking-v1.p.rapidapi.com/properties/list',
    });
  }

  async getUnifiedHotels() {
    const hotels = await this.getHotels();

    return hotels.map(({ address, hotel_name, min_total_price, main_photo_url }) => ({
      address,
      name: hotel_name,
      price: min_total_price / 10000,
      image: main_photo_url
    }));
  }

  async getHotels() {
    const options = {
      params: {
        offset: '0',
        arrival_date: '2023-12-05',
        departure_date: '2023-12-10',
        guest_qty: '1',
        dest_ids: '-3712125',
        room_qty: '1',
        search_type: 'city',
        children_qty: '2',
        children_age: '5,7',
        search_id: '20088325',
        price_filter_currencycode: 'USD',
        order_by: 'popularity',
        languagecode: 'en-us',
        travel_purpose: 'leisure',
      },
      headers: {
        'X-RapidAPI-Key': 'efc0e93cf6mshe59386ab28edcdbp136b0bjsn3ddd0119cf76',
        'X-RapidAPI-Host': 'apidojo-booking-v1.p.rapidapi.com',
      },
    };

    try {
      const response = await this.api.get(
        'https://apidojo-booking-v1.p.rapidapi.com/properties/list',
        options
      );
      return response.data?.result;
    } catch (error) {
      console.error(error);
      throw error;
    }
  }
}

export default new BookingService();
