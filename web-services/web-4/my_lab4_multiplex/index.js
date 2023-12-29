// 12.	Разработайте систему поиска отелей и интеграцией с API сервисов бронирования гостиниц. 
// Реализуйте мультиплексирование для одновременного поиска и отображения информации о доступных отелях от нескольких сервисов.

const axios = require('axios');
const async = require('async');

const requests = [
  {
    url: 'https://hotels4.p.rapidapi.com/locations/v3/search',
    headers: {
      'X-RapidAPI-Key': "7e373b9125msh269687bed4be908p1634b7jsna9f0e329b7f1",
      'X-RapidAPI-Hos': "hotels4.p.rapidapi.com",
    },
    params: {
      q: 'new york',
      locale: 'en_US',
      langid: '1033',
      siteid: '300000001',
    },
  },
  {
    url: 'https://best-booking-com-hotel.p.rapidapi.com/booking/best-accommodation',
    headers: {
      'X-RapidAPI-Key': "7e373b9125msh269687bed4be908p1634b7jsna9f0e329b7f1",
      'X-RapidAPI-Hos': "best-booking-com-hotel.p.rapidapi.com",
    },
    params: {
      cityName: 'Berlin',
      countryName: 'Germany',
    },
  }
];


const executeRequest = (request, callback) => {
  axios.get(request.url, {
    headers: request.headers,
    params: request.params,
  })
    .then(response => {
      callback(null, response.data);
    })
    .catch(error => {
      callback(error);
    });
};


async.parallel(requests.map(request => {
  return async.parallel.bind(null, {
    request: async.apply(executeRequest, request)
  });
}), (error, results) => {
  if (error) {
    console.error(error);
  } else {
    console.log(results.map(result => result.request));
  }
});
