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

var recentDays = 5;

var schema = {
  "type": "array",
  "minItems": 10,
  "maxItems": 20,
  "items": {
	  "type": "object",
	  "properties": {
	    "name": {
	      "type": "string",
	      "faker": "name.findName"
	    },
	    "date": {
	      "type": "string",
	      "faker": "date.recent"
	    },
	    "rank" : {
	      "type": "integer", 
	       "minimum": 3,
  		   "maximum": 5
	    },
	    "age" : {
	    	"type": "string", 
	    	"chance": {
	    		 "age": {
	      			"type": "adult"
	    		 }
	    	}
	    }
	  },
	  "required": [
	    "name",
	    "age", 
	    "date",
	    "rank"
	   ]
	  }
};

/* GET home page. */
router.get('/', (req, res) => {

  jsf.resolve(schema).then(sample => {
  	   logger.debug(util.inspect(sample, 
  	   	{showHidden: false, depth: null}));
	   
	   res.render('feedback', 
	  	{  opinions:  sample });
  });

  
});

module.exports = router;
