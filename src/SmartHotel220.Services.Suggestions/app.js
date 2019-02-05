'use strict';

var debug = require('debug');
var express = require('express');
var path = require('path');
var favicon = require('serve-favicon');
var logger = require('morgan');
var cookieParser = require('cookie-parser');
var bodyParser = require('body-parser');

var routes = require('./routes/index');
var suggestions = require('./routes/suggestions');

var app = express();

// Установка движка для представлений
app.set('views', path.join(__dirname, 'views'));
app.set('view engine', 'pug');

app.use(favicon(__dirname + '/public/favicon.ico'));
app.use(logger('dev'));
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: false }));
app.use(cookieParser());
app.use(express.static(path.join(__dirname, 'public')));

app.use('/', routes);
app.use('/suggestions', suggestions);

// ловушка для ошибки 404
app.use(function (req, res, next) {
    var err = new Error('Не найдено');
    err.status = 404;
    next(err);
});

// обработчики ошибок

// обработчик при разработке
// будет печатать стэктрейс
if (app.get('env') === 'local' || app.get('env') === 'docker') {
    app.use(function (err, req, res, next) {
        res.status(err.status || 500);
        res.render('error', {
            message: err.message,
            error: err
        });
    });
}

// обработчик в продакшине
// никаких стэктрейсов
app.use(function (err, req, res, next) {
    res.status(err.status || 500);
    res.render('error', {
        message: err.message,
        error: {}
    });
});

app.set('port', process.env.PORT || 3000);


const basePath = process.env.PATH_BASE || '/';

if (basePath !== '/') {
    var pfxserver = express();
    pfxserver.use(basePath, app);

    var server = pfxserver.listen(app.get('port'), function () {
        debug('Экспресс-сервер прослушивает ' + basePath + ' порт ' + server.address().port);
    });    
} else {
    var server = app.listen(app.get('port'), function () {
        debug('Экспресс-сервер прослушивает порт ' + server.address().port);
    });    
}