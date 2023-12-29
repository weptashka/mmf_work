const express = require('express');
const axios = require('axios');
const async = require('async');

const router = express.Router();

const requests = [
  (query) => ({
    path: 'https://pixabay.com/api/?key=41414344-12bcd6056365516fd221c2e08&q=' + 
    encodeURIComponent(query) + '&lang=en',
  }),
  (query) => ({
    path: 'https://api.pexels.com/v1/search?query=' + 
    encodeURIComponent(query || 'Everything') + '&locale=en_US',
    headers: {
      'Authorization': 'XrqAXIpKyHz2VtG3oTJ4Rq2Vo4iA6i30Rc4gMIy7InwFWAfbwKKcfs7e',
    },
  }),
];

const executeRequest = (request, callback) => {
  axios.get(request.path, request.headers ? { headers: request.headers } : {})
    .then(response => {
      callback(null, response.data);
    })
    .catch(error => {
      callback(error);
    });
};

router.get('/', async function (req, res, next) {
  const photos = await async.parallel(requests.map(request => {
    return callback => {
      executeRequest(request(req.query?.search || 'Something'), callback);
    };
  })).then(results => {
    return results
      .map((result) => {
        return result.hits || result.results || result.photos;
      })
      .flat()
      .map((photo) => {
        return {
          title: photo.alt_description || photo.alt || photo.tags,
          imageUrl: photo.webformatURL || photo.src?.original || photo.urls?.regular,
        };
      });
  });

  res.render('index', {
    title: 'Photos',
    photos,
  });
});

module.exports = router;
