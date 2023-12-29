import express from 'express';
import xml2js from 'xml2js';
import bodyParser from 'body-parser';

import db from './db.js';

const app = express();

app.use(bodyParser.text({ type: 'application/xml' }));

app.post('/weatherService', async (req, res) => {
  let parsedWeatherInfo = {};

  try {
    const parsedRequest = await xml2js.parseStringPromise(req.body);
console.log( parsedRequest['soapenv:Envelope']['soapenv:Body'][0]['web:weatherService'])
    parsedWeatherInfo._id = parsedRequest['soapenv:Envelope']['soapenv:Body'][0]['web:weatherService'][0]['web:weatherInfo'][0]?.['web:id']?.[0];
    parsedWeatherInfo.city = parsedRequest['soapenv:Envelope']['soapenv:Body'][0]['web:weatherService'][0]['web:weatherInfo'][0]?.['web:city']?.[0];
    
  } catch (e) {
    console.error(e);
  }

  const weather = await db.findWeather(parsedWeatherInfo);

  console.log(parsedWeatherInfo)

  if (!weather) {
    res.status(404);
    res.send('Weather info not found');
    return;
  }

  const xmlResponse = `
      <soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:web="http://example.com/hotelReserveService">
        <soapenv:Body>
        <web:weatherReserveService>
        <web:weatherInfo>
        <web:id>${weather._id}</web:id>
        <web:city>${weather.city}</web:city>
        <web:degree>${weather.degree}</web:degree>
        <web:wind>${weather.wind}</web:wind>
        <web:prwcipitation>${weather.precipitation}</web:precipitation>
        </web:weatherInfo>
    </web:weatherReserveService>
        </soapenv:Body>
      </soapenv:Envelope>`;

  res.status(201);
  res.set('Content-Type', 'application/xml');
  res.send(xmlResponse);
});

// Starting the server on port 3000
app.listen(3000, () => {
  console.log('Starting the server on port 3000');
});