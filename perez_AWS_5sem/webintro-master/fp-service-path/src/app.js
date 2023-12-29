const swagger = require('fastify-swagger')
const cors = require('cors')

const { name, port, options, documentation } = require('./config/config')
const { v1 } = require('./routes')

const fastify = require('fastify')(options)

// Middlewares
fastify.use(cors())
// Plugins
fastify.register(swagger, documentation)
fastify.register(v1, { prefix: '/v1' })
fastify.register(require('fastify-nextjs'))


// Server
const start = async () => {
  try {
    await fastify.listen(port)
    fastify.swagger()

    fastify.log.info(`server listening on ${fastify.server.address().port} ${name} ${process.env.NODE_ENV}`)
  } catch (err) {
    fastify.log.error(err)
    process.exit(1)
  }
}
start()


// Export fastify for testing purpose
module.exports = { fastify }
