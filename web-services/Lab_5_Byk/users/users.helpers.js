module.exports = {
    prepareUser: (item) => ({
        userId: item._id,
        bookId: item.bookId,
        userName: item.userName
    }),
}