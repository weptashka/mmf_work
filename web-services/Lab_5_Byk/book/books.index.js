const express = require('express')
const { BookModel } = require("./books.mongodb");
const { prepareBook } = require("./books.helpers");
const axios = require("axios");

const app = express()

app.get('/books', async (req, res) => {
    const { genreId } = req.query;  

    const books = await BookModel.find(genreId ? { genreId } : undefined);

    const prepared = await Promise.all(books.map(async (item) => {
        const { data: users } = await axios.get('http://localhost:8081/users', {
            params: {
                bookId: item._id
            }
        })

        return {
            ...prepareBook(item),
            users
        }
    }))

    return res.send(prepared)
})

const PORT = 8082;
app.listen(PORT, () => console.log(`Book is running on port ${PORT}`))