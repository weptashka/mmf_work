/**
 * Keep Alive handler
 *
 * @param {FastifyRequest} request
 * @param {FastifyReply} reply
 */
 
/*const keepAlive = (request, reply) => {
  reply.code(200).send('API is alive')
}*/

const keepAlive = async () => {
  return 'API is alive'
} 


const uberSampleJson = [{
  "product_id": "17cb78a7-b672-4d34-a288-a6c6e44d5315",
  "request_id": "a1111c8c-c720-46c3-8534-2fcdd730040d",
  "status": "accepted",
  "surge_multiplier": 1.0,
  "shared": true,
  "driver": {
    "phone_number": "(415)555-1212",
    "sms_number": "(415)555-1212",
    "rating": 5,
    "picture_url": "https://d1w2poirtb3as9.cloudfront.net/img.jpeg",
    "name": "Bob"
  },
  "vehicle": {
    "make": "Bugatti",
    "model": "Veyron",
    "license_plate": "I<3Uber",
    "picture_url": "https://d1w2poirtb3as9.cloudfront.net/car.jpeg"
  },
  "location": {
    "latitude": 37.3382129093,
    "longitude": -121.8863287568,
    "bearing": 328
  },
  "pickup": {
    "latitude": 37.3303463,
    "longitude": -121.8890484,
    "eta": 5
  },
  "destination": {
    "latitude": 37.6213129,
    "longitude": -122.3789554,
    "eta": 19
  },
  "waypoints": [
    {
       "rider_id":null,
       "latitude":37.77508531,
       "type":"pickup",
       "longitude":-122.3976683872
    },
    {
       "rider_id":null,
       "latitude":37.773133,
       "type":"dropoff",
       "longitude":-122.415069
    },
    {
       "rider_id":"8KwsIO_YG6Y2jijSMf",
       "latitude":37.7752423,
       "type":"dropoff",
       "longitude":-122.4175658
    }
  ],
  "riders": [
    {
       "rider_id":"8KwsIO_YG6Y2jijSMf",
       "first_name":"Alec",
       "me": true
    },
    {
       "rider_id":null,
       "first_name":"Kevin",
       "me": false
    }
  ]
}]

const tripsStatus = async () => {
  return uberSampleJson
} 

module.exports = { keepAlive, tripsStatus }
