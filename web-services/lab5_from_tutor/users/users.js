const express = require('express');
const path = require('path');
const bodyParser = require('body-parser');
const port = process.argv.slice(2)[0];
const app = express();

app.use(bodyParser.json());

const skills = [
  { id: 0, name: 'reading post' },
  { id: 1, name: 'creation post' },
  { id: 2, name: 'editing post' },
];

const users = [
  {
    id: 5,
    type: 'admin',
    displayName: 'Bob',
    skills: [0, 1],
    img: 'user5.png'
  },
  {
    id: 6,
    type: 'user',
    displayName: 'Yulia',
    skills: [0, 2],
    img: 'user6.png'
  },
  {
    id: 7,
    type: 'user',
    displayName: 'Max',
    skills: [1, 2],
    img: 'user7.png'
  },
  {
    id: 8,
    type: 'admin',
    displayName: 'Anna',
    skills: [0, 2],
    img: 'user8.png'
  },
];

app.get('/users', (req, res) => {
  console.log('Returning users list');
  res.send(users);
});

app.get('/skills', (req, res) => {
  console.log('Returning skills list');
  res.send(skills);
});

app.post('/user/**', (req, res) => {
  const userId = parseInt(req.params[0]);
  const foundUser = users.find(subject => subject.id === userId);

  if (foundUser) {
      for (let attribute in foundUser) {
          if (req.body[attribute]) {
              foundUser[attribute] = req.body[attribute];
              console.log(`Set ${attribute} to ${req.body[attribute]} in user: ${userId}`);
          }
      }
      res.status(202).header({Location: `http://localhost:${port}/user/${foundUser.id}`}).send(foundUser);
  } else {
      console.log(`user not found.`);
      res.status(404).send();
  }
});

app.use('/img', express.static(path.join(__dirname,'img')));

console.log(`users service listening on port ${port}`);
app.listen(port);