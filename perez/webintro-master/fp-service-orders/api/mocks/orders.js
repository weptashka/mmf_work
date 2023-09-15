'use strict';
/*
 'use strict' is not required but helpful for turning syntactical errors into true errors in the program flow
 https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Strict_mode
*/

/*
 Modules make it possible to import JavaScript files into your application.  Modules are imported
 using 'require' statements that give you a reference to the module.

  It is a good idea to list the modules that your application depends on in the package.json in the project root
 */
var util = require('util');
var builder = require('xmlbuilder');
const jsf = require('json-schema-faker');
const chance = require('chance')
const faker = require('faker')
jsf.extend('chance', () => new chance.Chance());
jsf.extend('faker', () => faker);

/*
 Once you 'require' a module you can reference the things that it exports.  These are defined in module.exports.

 For a controller in a127 (which this is) you should export the functions referenced in your Swagger document by name.

 Either:
  - The HTTP Verb of the corresponding operation (get, put, post, delete, etc)
  - Or the operationId associated with the operation in your Swagger document

  In the starter/skeleton project the 'get' operation on the '/hello' path has an operationId named 'hello'.  Here,
  we specify that in the exports of this module that 'hello' maps to the function named 'hello'
 */
module.exports = {
  listOrders: getOrders,
  listTeaTypes: getTeaTypes,
  listSpots: getSpots, 
  stats: getStats
};

/*
  Functions in a127 controllers used for operations should take two parameters:

  Param 1: a handle to the request object
  Param 2: a handle to the response object
 */
function getOrders(req, res) {
  // variables defined in the Swagger document can be referenced using req.swagger.params.{parameter_name}
  var teaOrder = { 
                  "id": "1234", "takeOffId": 230, "teaType": "green", 
                  "time": "2020-05-01T12:00", "status": "ready"
                  }
  res.json([teaOrder]);
}

function getTeaTypes(req, res) {
  // variables defined in the Swagger document can be referenced using req.swagger.params.{parameter_name}
  // var name = req.swagger.params.tea.value || 'white';
  var teaType = { "id": "1234", "name": "green" }
  res.json([teaType]);
}


function getSpots(req, res) {
  // variables defined in the Swagger document can be referenced using req.swagger.params.{parameter_name}
  // var name = req.swagger.params.tea.value || 'white';
  var spot = { 
      "name": faker.company.companyName(), 
      "geo": `${faker.address.longitude()};${faker.address.latitude()}`, 
      "photo":"http://capl.washjeff.edu/2/l/5069.jpg", 
      "teaTypes": ["green", "black"] }
  res.json([spot]);
}


function getStats(req, res) {
  // variables defined in the Swagger document can be referenced using req.swagger.params.{parameter_name}
  // var name = req.swagger.params.tea.value || 'white';
  var doc = builder.create('orders')
    .ele('order')
      .att('date', '2020-04-01T17:40')
      .att('product', 'Earl grey')
      .att('category', 'black')
      .up()
    .ele('order')
      .att('date', '2020-04-01T17:40')
      .att('product', 'Earl grey')
      .att('category', 'black')
      .up()  
  .end({ pretty: true });

  res.type('application/xml');
  res.set('x-template', 'orders.xsl')
  res.send(doc.toString());
}
