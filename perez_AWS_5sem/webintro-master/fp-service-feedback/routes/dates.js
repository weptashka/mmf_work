const express = require('express');
const router = express.Router();
const reqlib = require('app-root-path').require;
const logger = reqlib('logger');

const jsf = require('json-schema-faker');
const util = require('util')
const chance = require('chance')
const faker = require('faker')
jsf.extend('chance', () => new chance.Chance());
jsf.extend('faker', () => faker);

var selectDeliveryDatesSchema = {
  "type": "array",
  "minItems": 1,
  "maxItems": 5,
  "items": {
	      "type": "string",
        "faker": { 
          "date.recent": 10
        },
        "uniqueItems": true
   }
};



/* GET home page. */
router.get('/', (req, res) => {

  jsf.resolve(selectDeliveryDatesSchema).then(sample => {
  	   logger.debug(util.inspect(sample, 
  	   	{showHidden: false, depth: null}));
	   
	   res.render('dates',  
	  	{  dates:  sample });
  });

  
});
 

module.exports = router;
