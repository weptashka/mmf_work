const express = require('express');
const path = require('path');
const bodyParser = require('body-parser');
const port = process.argv.slice(2)[0];
const app = express();

app.use(bodyParser.json());

// const occupations = [
//   { id: 0, name: 'manager' },
//   { id: 1, name: 'seller' },
//   { id: 2, name: 'packer' },
// ];



const persons = [
  {
    id: 5,
    displayName: 'Bob',
    occupations: [0, 1]
  },
  {
    id: 6,
    displayName: 'Yulia',
    occupations: [0, 2]
  },
  {
    id: 7,
    displayName: 'Max',
    occupations: [1, 2]
  },
  {
    id: 8,
    displayName: 'Anna',
    occupations: [0, 2]
  },
];




app.get('/persons', (req, res) => {
  console.log('Returning persons list');
  res.send(persons);
});

app.get('/occupations', (req, res) => {
  console.log('Returning occupations list');
  res.send(occupations);
});

app.post('/person/**', (req, res) => {
  const personId = parseInt(req.params[0]);
  const foundPerson = person.find(subject => subject.id === personId);

  if (foundPerson) {
      for (let attribute in foundPerson) {
          if (req.body[attribute]) {
              foundPerson[attribute] = req.body[attribute];
              console.log(`Set ${attribute} to ${req.body[attribute]} in person: ${personId}`);
          }
      }
      res.status(202).header({Location: `http://localhost:${port}/person/${foundPerson.id}`}).send(foundPerson);
  } else {
      console.log(`person not found.`);
      res.status(404).send();
  }
});

console.log(`persons service listening on port ${port}`);
app.listen(port);