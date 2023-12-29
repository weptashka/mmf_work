import { MongoClient } from 'mongodb';

const url = "mongodb+srv://ksenia:test1234@cluster0.84oxlgv.mongodb.net/?retryWrites=true&w=majority";
const client = new MongoClient(url);

client.connect().then(() => {

});

const dbName = 'todo-app-base';
const collectionName = 'weather';

async function findWeather(weatherDto) {
  const db = client.db(dbName);
  const collection = db.collection(collectionName);

  return collection.findOne(weatherDto);
}


export default {
  findWeather,
}