const express = require('express')
const { UserModel } = require("./users.mongodb");
const { prepareUser } = require("./users.helpers");

const app = express()

app.get('/users', async (req, res) => {
    const { bookId } = req.query

    const users = await UserModel.find(bookId ? { bookId } : undefined);

    const prepared = users.map((item) => prepareUser(item))

    return res.send(prepared)
})

const PORT = 8081;
app.listen(PORT, () => console.log(`User is running on port ${PORT}`))