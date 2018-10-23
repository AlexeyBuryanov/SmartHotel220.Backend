﻿const fs = require('fs');
const path = require('path');
const Sequelize = require('sequelize');
const basename = path.basename(module.filename);
const env = process.env.NODE_ENV || 'local';
const config = require(`${__dirname}/../config/config.json`)[env];
const db = {};

// Создаём объект для работы с Sequelize в зависимости от среды выполнения
let sequelize;
if (config.use_env_variable) {
    sequelize = new Sequelize(process.env[config.use_env_variable], config || {});
} else {
    sequelize = new Sequelize(
        config.database, config.username, config.password, config
    );
}

// Асинхронно читаем папку проекта
fs
    .readdirSync(__dirname)
    .filter(file =>
        (file.indexOf('.') !== 0) &&
        (file !== basename) &&
        (file.slice(-3) === '.js'))
    // ƒл¤ каждого файла
    .forEach(file => {
        // »мпортируем существующие модели
        const model = sequelize.import(path.join(__dirname, file));
        db[model.name] = model;
    });

Object.keys(db).forEach(modelName => {
    if (db[modelName].associate) {
        db[modelName].associate(db);
    }
});

db.sequelize = sequelize;
db.Sequelize = Sequelize;

// Экспортируем созданную базу
module.exports = db;