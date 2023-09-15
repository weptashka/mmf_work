const winston = require('winston');

var appRoot = require('app-root-path');
var reqlib = appRoot.require;
const logfile = reqlib('ecosystem.config.js').apps[0].out_file || `${appRoot}/logs/app.log`

var options = {
  console: {
    level: 'debug',
    handleExceptions: true,
    json: false,
    colorize: true,
  },
  file: {
    level: 'info',
    filename: logfile,
    handleExceptions: true,
    json: true,
    maxsize: 5242880, // 5MB
    maxFiles: 5,
    colorize: false,
  }
};

// Define separately due to rewrite behavior latter if needed
const logTransports = {
  console: new winston.transports.Console(options.console),
  file: new winston.transports.File(options.file)
};

var logger = winston.createLogger({
    transports: [
        logTransports.console, logTransports.file
    ],
    exitOnError: false
});

// Due to integration with internal morgan request logger
logger.stream = {
    write: function(message, encoding){
        logger.info(message);
    }
};
  
module.exports = logger;