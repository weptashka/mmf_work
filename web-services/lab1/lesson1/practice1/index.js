const express = require('express');
const app = express();
const bodyParser = require('body-parser');
const xml2js = require('xml2js');

// Parsing the request body in XML format
app.use(bodyParser.text({ type: 'text/xml' }));

app.post('/userDetailsService', (req, res) => {
  // Convert input XML to JS object
  xml2js.parseString(req.body, (err, result) => {
    if (err) {
      res.status(400).send('An error occurred while processing input data.');
      return;
    }

    const userId = result['soapenv:Envelope']['soapenv:Body'][0]['web:getUserInfo'][0]['web:userId'][0];
    console.log(userId);

    // Здесь должен быть код для получения информации о пользователе из базы данных
    // Замените этот код на реальную логику для получения информации о пользователе

    const userInfo = {
      firstName: 'John',
      lastName: 'Doe',
      age: 30
    };

    // Generating an XML response
    const xmlResponse = `
      <soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:web="http://example.com/userDetailsService">
        <soapenv:Body>
          <web:getUserInfoResponse>
            <web:userInfo>
              <web:firstName>${userInfo.firstName}</web:firstName>
              <web:lastName>${userInfo.lastName}</web:lastName>
              <web:age>${userInfo.age}</web:age>
            </web:userInfo>
          </web:getUserInfoResponse>
        </soapenv:Body>
      </soapenv:Envelope>`;

    res.set('Content-Type', 'text/xml');
    res.send(xmlResponse);
  });
});

// Starting the server on port 8000
app.listen(8000, () => {
  console.log('Starting the server on port 8000');
});