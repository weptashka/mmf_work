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

const Book = new Schema({
    bookId: ObjectId,
    genreId: ObjectId,
    bookName: String,
    price: Number
});

const BookModel = model('Book', Book);

module.exports = {
    BookModel
}