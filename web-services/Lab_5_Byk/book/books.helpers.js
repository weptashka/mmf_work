module.exports = {
    prepareBook: (item) => ({
        bookId: item._id,
        genreId: item.genreId,
        bookName: item.bookName,
        price: item.price,
    })
}