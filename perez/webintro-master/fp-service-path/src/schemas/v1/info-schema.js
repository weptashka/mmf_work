module.exports = {
  keepAlive: {
    description: 'Get the status of the API',
    tags: ['Info'],
    summary: 'Obtain the status of the API',
    response: {
      200: {
        description: 'Succesful response',
        type: 'string'
      },
      400: {
        description: 'Not Found response',
        type: 'string'
      },
      500: {
        description: 'Error response',
        type: 'object',
        properties: {
          error: { type: 'string' },
          message: { type: 'string' },
          statusCode: { type: 'number' }
        }
      }
    }
  },
  tripsStatus: {
    description: 'Get the status of the current trips',
    tags: ['Trip'],
    summary: 'Obtain the status of the current trips',
    response: {
      200: {
        description: 'Succesful response',
        type: 'object'
      },
      400: {
        description: 'Not Found response',
        type: 'string'
      },
      500: {
        description: 'Error response',
        type: 'object',
        properties: {
          error: { type: 'string' },
          message: { type: 'string' },
          statusCode: { type: 'number' }
        }
      }
    }
  }
}
