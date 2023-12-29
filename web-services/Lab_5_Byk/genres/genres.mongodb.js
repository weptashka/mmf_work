const mongoose = require('mongoose');

const { Schema, ObjectId, model } = mongoose;

mongoose.connect('mongodb://127.0.0.1:27017/lab5', {
    serverSelectionTimeoutMS: 5000
})
    .then(() => console.log('Connected!'))
    .catch(() => {
        console.log("Cannot connect to mongoose");
        process.exit()
    });

const Genre = new Schema({
    genreId: ObjectId,
    genreName: String,
    numberOfBooks: Number
});

const GenreModel = model('Genre', Genre);

module.exports = {
    GenreModel
}