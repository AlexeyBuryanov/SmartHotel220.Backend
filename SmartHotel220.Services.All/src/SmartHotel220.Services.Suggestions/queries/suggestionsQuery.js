const geolib = require('geolib');
const Suggestion = require('../data/models').Suggestion;

// Получить предложение
// location - текущая локация
var get = function (location, take) {
    take = take || 10;

    // .all - вернуть ссылку на коллекцию элементов, содержащихся в объекте
    // .then - прикрепляет коллбэки для разрешения и/или отклонения Promise
    return Suggestion.all({ raw: true }).then(function (suggestions) {
        // Проходим по предложениям
        suggestions.forEach(function (suggestion) {
            // С помощью geolib можем рассчитать расстояние до заведения
            var distance = geolib.getDistance(location, suggestion);
            suggestion.distance = distance;
        });

        // Ближайщие заведения
        // .slice - возвращает раздел массива
        var nearest = suggestions.sort(function (suggestionA, suggestionB) {
            return suggestionA.distance - suggestionB.distance;
        }).slice(0, take);

        return nearest;
    });
}

module.exports = {
    get: get
};                           