const express = require('express');
const path = require('path');
const bodyParser = require('body-parser');
const request = require('request');
const port = process.argv.slice(2)[0];
const app = express();

app.use(bodyParser.json());

const usersService = 'http://localhost:8081';

const posts = [
    {
        id: 4,
        displayName: 'Post 4',
        img: 'post4.png',
        necessarySkills: ['reading post'],
        assignedUser: 0
    },
    {
        id: 5,
        displayName: 'Post 5',
        img: 'post5.png',
        necessarySkills: ['editing post'],
        assignedUser: 0
    },
    {
        id: 6,
        displayName: 'Post 6',
        img: 'post6.png',
        necessarySkills: ['editing post'],
        assignedUser: 0
    },
];

app.get('/posts', (req, res) => {
    console.log('Returning posts list');
    res.send(posts);
});

app.post('/assignment', (req, res) => {
    request.post({
        headers: { 'content-type': 'application/json' },
        url: `${usersService}/user/${req.body.userId}`,
        body: `{
          
      }`
    }, (err, userResponse, body) => {
        if (!err) {
            const postId = parseInt(req.body.postId);
            const post = posts.find(subject => subject.id === postId);
            post.assignedUser = req.body.userId;
            res.status(202).send(post);
        } else {
            res.status(400).send({ problem: `user Service responded with issue ${err}` });
        }
    });
});

app.use('/img', express.static(path.join(__dirname, 'img')));

console.log(`posts service listening on port ${port}`);
app.listen(port);

