const express = require('express');
const router = express.Router();
const reqlib = require('app-root-path').require;
const logger = reqlib('logger');
const os = require("os");
const hostname = os.hostname();

const util = require('util')
const chance = require('chance')
const faker = require('faker')

const packageGenVersion = reqlib('lib/version.js') 
const instance_id = process.env.NODE_APP_INSTANCE || 0 


/* GET home page. */
router.get('/', (req, res) => {
	res.render('index', 
	  	{ team:  'FP', 
	  	  year: 2020,
	  	  version: packageGenVersion,
	  	  instance: instance_id,
	  	  host: hostname 
	  	});

  
});

module.exports = router;
