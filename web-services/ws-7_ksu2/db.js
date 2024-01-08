import mongoose from 'mongoose';

mongoose.connect('mongodb://127.0.0.1:27017/lab7');

const db = mongoose.connection;

db.on('error', console.error.bind(console, 'connection error:'));
db.once('open', () => console.log('Connected to MongoDB'));

export default db;