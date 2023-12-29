const express = require('express');
const path = require('path');
const bodyParser = require('body-parser');
const request = require('request');
const port = process.argv.slice(2)[0];
const app = express();

app.use(bodyParser.json());

const personsService = 'http://localhost:8081';

const storehouses = [
    {
        id: 4,
        displayName: 'Storehouse 4',
        necessaryOccupations: ['saller'],
        assignedPerson: 0
    },
    {
        id: 5,
        displayName: 'Storehouse 5',
        necessaryOccupations: ['manager'],
        assignedPerson: 0
    },
    {
        id: 6,
        displayName: 'Storehouse 6',
        necessaryOccupations: ['packer'],
        assignedPerson: 0
    },
];

app.get('/storehouses', (req, res) => {
    console.log('Returning storehouses list');
    res.send(storehouses);
});

app.post('/assignment', (req, res) => {
    request.post({
        headers: { 'content-type': 'application/json' },
        url: `${personsService}/person/${req.body.personId}`,
        body: `{
          
        }`
    }, (err, personResponse, body) => {
        if (!err) {
            const storehouseId = parseInt(req.body.storehouseId);
            const storehouse = storehouses.find(subject => subject.id === storehouseId);
            storehouse.assignedPerson = req.body.personId;
            res.status(202).send(storehouse);
        } else {
            res.status(400).send({ problem: `person Service responded with issue ${err}` });
        }
    });
});


console.log(`storehouses service listening on port ${port}`);
app.listen(port);

