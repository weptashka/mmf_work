const express = require('express')
const { GenreModel } = require("./genres.mongodb");
const { prepareGenre } = require("./genres.helpers");
const axios = require("axios");

const app = express()

app.get('/genres', async (req, res) => {
    const genres = await GenreModel.find();

    const prepared = await Promise.all(genres.map(async (item) => {
        const { data: books } = await axios.get('http://localhost:8082/books', {
            params: {
                genreId: item._id
            }
        })
        console.log(item._id);

        return {
            ...prepareGenre(item),
            books
        }
    }))

    return res.send(prepared)
})

const PORT = 8083;
app.listen(PORT, () => console.log(`Genre is running on port ${PORT}`))