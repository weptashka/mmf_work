const express = require('express');
const HandlebarsIntl = require('handlebars-intl');
const path = require('path');
const favicon = require('serve-favicon');
const morganLogger = require('morgan');
const logger = require('./logger');
const cookieParser = require('cookie-parser');
const bodyParser = require('body-parser');
const exphbs  = require('express-handlebars');

const routes = require('./routes/index');
const feedback = require('./routes/feedback');
const dates = require('./routes/dates');

const app = express();

const env = process.env.NODE_ENV || 'development';
app.locals.ENV = env;
app.locals.ENV_DEVELOPMENT = env == 'development';

// set up handlebar intl utils to format dates
const hbs = exphbs.create({
  defaultLayout: 'main',
  partialsDir: ['views/partials/']
})

HandlebarsIntl.registerWith(hbs.handlebars)

// view engine setup
//exphbs
app.set('views', path.join(__dirname, 'views'));
app.set('view engine', 'handlebars');

app.engine('handlebars', hbs.engine);

// app.use(favicon(__dirname + '/public/img/favicon.ico'));
app.use(morganLogger("combined", { "stream": logger.stream }));

app.use(bodyParser.json());
app.use(bodyParser.urlencoded({
  extended: true
}));
app.use(cookieParser());
app.use(express.static(path.join(__dirname, 'public')));

app.use('/', routes);
app.use('/feedback', routes);
app.use('/feedback/reviews', feedback);
app.use('/feedback/dates', dates);
app.use('/health', require('express-healthcheck')());


/// catch 404 and forward to error handler
app.use((req, res, next) => {
    const err = new Error('Not Found');
    err.status = 404;
    next(err);
});

/// error handlers

// development error handler
// will print stacktrace
if (app.get('env') === 'development') {
    app.use((err, req, res, next) => {
        res.status(err.status || 500);
        res.render('error', {
            message: err.message,
            error: err,
            title: 'error'
        });
    });
}

// production error handler
// no stacktraces leaked to user
app.use((err, req, res, next) => {
    res.status(err.status || 500);
    res.render('error', {
        message: err.message,
        error: {},
        title: 'error'
    });
});

// Testing App error after 3 sec
/*  
 setTimeout((function() {
    return process.exit(22);
}), 3000); */

module.exports = app;