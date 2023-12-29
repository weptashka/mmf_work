module.exports = {
    prepareGenre: (item) => ({
        genreId: item._id,
        genreName: item.genreName,
        numberOfBooks: item.numberOfBooks,
    }),
}