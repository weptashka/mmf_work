import axios from 'axios';

class PricelineService {
  constructor(params) {
    this.api = axios.create({
      baseUrl: 'https://priceline-com-provider.p.rapidapi.com/v1/hotels/search',
    });
  }

  async getUnifiedHotels() {
    const hotels = await this.getHotels();

    return hotels.map(
      ({
        location: { neighborhoodName },
        name,
        ratesSummary: { minPrice },
        thumbnailUrl,
      }) => ({
        address: neighborhoodName,
        name,
        price: minPrice,
        image: thumbnailUrl,
      })
    );
  }

  async getHotels() {
    const options = {
      method: 'GET',
      params: {
        date_checkout: '2023-12-19',
        sort_order: 'HDR',
        location_id: '3000035821',
        date_checkin: '2023-12-18',
        amenities_ids: 'FINTRNT,FBRKFST',
        rooms_number: '1',
        star_rating_ids: '3.0,3.5,4.0,4.5,5.0',
      },
      headers: {
        'X-RapidAPI-Key': 'efc0e93cf6mshe59386ab28edcdbp136b0bjsn3ddd0119cf76',
        'X-RapidAPI-Host': 'priceline-com-provider.p.rapidapi.com',
      },
    };

    try {
      const response = await this.api.get(
        'https://priceline-com-provider.p.rapidapi.com/v1/hotels/search',
        options
      );
      return response.data?.hotels;
    } catch (error) {
      console.error(error);
      throw error;
    }
  }
}

export default new PricelineService();
