'use strict';

// Случайное число
var getRandom = function (min, max) {
    min = Math.ceil(min);
    max = Math.floor(max);

    return Math.floor(Math.random() * (max - min + 1)) + min; // Максимальное значение включено и минимальное значение включено
};

// Получить города
var getCities = function () {
    var cities = [
        { name: "Сиэтл", latitude: 47.6062095, longitude: -122.3320708 },
        { name: "Нью-Йорк", latitude: 40.712784, longitude: -74.005941 },
        { name: "Барселона", latitude: 41.385064, longitude: 2.173403 },
        { name: "Киев", latitude: 50.4501, longitude: 30.5234 }
    ];

    return cities;
};

// Получить рестораны
var getRestaurants = function () {
    var restaurants = [
        { name: 'Кафе 1', city: 'Нью-Йорк', coordinate: { latitude: 40.70629, longitude: -74.00786 }, description: 'Вот что вы должны знать о Black Fox на Pine Street: в магазине есть лучший выбор бобов по дням в любом магазине в городе. В результате, он упаковывает сотрудников в центре города, ища кофейную ложку и пищу для кофе выше среднего, например, салат из капусты и салата с песто, жареный цыпленок и сэндвич из авокадо и бублик из копченого лосося.', picture: 'suggestions/nyc_1.jpg' },
        { name: 'Кафе 2', city: 'Нью-Йорк', coordinate: { latitude: 40.70874938095975, longitude: -74.0070341029628 }, description: 'Названный в честь космического корабля "Вояджер", этот магазин идет на научно-фантастическую сцену с мензурками и научными предметами как часть опыта здесь. Любители кофе принимают к сведению необычный признак ростера, часто один из которых не базируется в США. Для еды есть причудливые тосты, такие как авокадо, и один, увенчанный Nutella.', picture: 'suggestions/nyc_2.jpg' },
        { name: 'Кафе 3', city: 'Нью-Йорк', coordinate: { latitude: 40.72137, longitude: -74.004377 }, description: 'Расположение West Broadway - звезда трех мест. Перемещение здесь состоит в том, чтобы получить один из фирменных напитков, таких как панацея или эспрессо, старомодный.', picture: 'suggestions/nyc_3.jpg' },
        { name: 'Ресторан 1', city: 'Нью-Йорк', coordinate: { latitude: 40.719227, longitude: -73.985203 }, description: 'В городе есть много мест в Голубой Бутылке, но это один из оазисов по соседству, где можно выпить и охладить.', picture: 'suggestions/nyc_4.jpg' },
        { name: 'Ресторан 2', city: 'Нью-Йорк', coordinate: { latitude: 40.72982797782921, longitude: -73.99982929229736 }, description: 'Небольшое и уютное место, которое собралось вечером с учениками NYU, это место для кофе перед фильмом в Центре IFC. Меню классики дополняется пончиками Donut Plant и множеством других испеченные товары. Просто имейте в виду только наличные деньги.', picture: 'suggestions/nyc_5.jpg' },
        { name: 'Ресторан 3', city: 'Нью-Йорк', coordinate: { latitude: 40.727190300039474, longitude: -73.98609917877279 }, description: 'Несмотря на то, что крошечный магазин стал больше в перекрестке, Abraco остается местом для качественного кофе и выпечки. Эспрессо особенно эффектно, когда наливает владелец Джейми Маккормик. Обратите внимание на мелодии, начиная с виниловых пластинок.', picture: 'suggestions/nyc_6.jpg' },
        { name: 'Кафе 4', city: 'Нью-Йорк', coordinate: { latitude: 40.72944395157202, longitude: -73.98588683367826 }, description: '"Выберите свой компонент" среди нескольких в меню. И рассмотрим множество различных методов пивоварения. Опыт - это ничья, как и все здесь.', picture: 'suggestions/nyc_7.jpg' },
        { name: 'Ресторан 4', city: 'Нью-Йорк', coordinate: { latitude: 40.73424147849653, longitude: -74.00747596129659 }, description: 'Ищите Vancouver vibe от этого уроженца Канады, Клэр Чан открыла пункт назначения для прекрасного кортадо и одноразового перелива. В общем кофейном магазине магазина с легким меню включается грейпфрут с выпечкой и запеченный яичный тост.', picture: 'suggestions/nyc_8.jpg' },
        { name: 'Кафе 5', city: 'Нью-Йорк', coordinate: { latitude: 40.73493358250772, longitude: -74.00211989879607 }, description: 'Третье дополнение к семейству семейств Тоби в Нью-Йорке, а также самое полное. Большое пространство оснащено всевозможными пивоваренными устройствами, а меню включает в себя ассортимент одноразового кофе. Это также одна из лучших ставок для серьезного ботаника кофе, потому что она предлагает регулярные занятия по всему, от латте искусства до дегустации кофе.', picture: 'suggestions/nyc_9.jpg' },
        { name: 'Кафе 6', city: 'Нью-Йорк', coordinate: { latitude: 40.745911003619725, longitude: -74.00536421354879 }, description: 'Этот импорт в Чикаго является одним из лучших вариантов в районе, где нет хорошего кофе. Напитки красиво приготовлены и подаются в превосходной стеклянной посуде. Кроме того, есть несколько приготовленных салатов и предварительно упакованных сэндвичей для толпы обеда, а также выпечка из Бьен-Куита и Мах-Зе-Дара.', picture: 'suggestions/nyc_10.jpg' },
        { name: 'Ресторан 5', city: 'Нью-Йорк', coordinate: { latitude: 40.745901560214506, longitude: -73.98814227092512 }, description: 'Персонал отеля Ace сохраняет текущую линейку в хорошем клипе. Капучино особенно звездное: идеальное молоко для эспрессо и температура молока. Это нулевой ноль для нитро в городе.', picture: 'suggestions/nyc_11.jpg' },
        { name: 'Ресторан 6', city: 'Нью-Йорк', coordinate: { latitude: 40.752285553402615, longitude: -73.98580074776224 }, description: 'Твердый кортадо и капельный кофе запирают меню этого стильного кофе-бара рядом с парком Брайант. Это гораздо более сильный выбор для кофе, чем несколько магазинов сети ближе к парку, и он служит превосходному печенью с шоколадной стружкой', picture: 'suggestions/nyc_12.jpg' },
        { name: 'Кафе 7', city: 'Нью-Йорк', coordinate: { latitude: 40.75990312387116, longitude: -73.96976709365845 }, description: 'Aussies, управляющие этим магазином в Мидтауне, обеспечили бегство для соседнего района, заполненного Starbucks и Le Pains. Наряду с плоскими белками и выливанием в магазин подают сэндвичи, салаты и бегемот из поджаренного бананового хлеба с рикоттой, ягодами, медом и миндалем. Получите шницель сэндвич или всегда твердый авокадо.', picture: 'suggestions/nyc_13.jpg' },
        { name: 'Кафе 8', city: 'Нью-Йорк', coordinate: { latitude: 40.76519004067687, longitude: -73.95801020048518 }, description: 'Выписывая себя как «творческую пекарню», этот магазин может чувствовать себя слишком чересчур похожим на пекарню Panera, а Оазис играет на динамиках и слишком корпоративную атмосферу. Персонал все еще немного разбирается в меню, но все прощается с эспрессо, выданным из стильных алюминиевых фитингов Modbar. Кофейные бобы получены из Бруклинского Nobletree, который является ростером, который также контролирует выращивание бобы со своих полей в Бразилии. Конечный результат в Падоке особенно хорош. И есть бесплатный Wi-Fi.', picture: 'suggestions/nyc_14.jpg' },
        { name: 'Ресторан 7', city: 'Нью-Йорк', coordinate: { latitude: 40.773377, longitude: -73.963821 }, description: 'Незадолго до того, как Flora Bar станет Flora Coffee, более тонким продлением спекулянта ЕЭС, подающим кофе, выпечку и бутерброды с выносными напитками. Это меньше, чем главная столовая Flora, но есть много места для чашки кофе-экспертов, предоставленной Counter Culture. Это также то, где шеф-повар печенья Наташа Пикович продает из нее не пропустимые липкие булочки.', picture: 'suggestions/nyc_15.jpg' }
    ];

    var cities = getCities();

    var suggestions = [];

    // Для каждого города
    cities.forEach(function (city) {
        // Для каждого существующего ресторана ресторана, сравниваем города, 
        // если одинаковые формируем предложение и добавляем его в массив
        restaurants.filter(r => r.city === city.name).forEach(function (restaurant) {
            var suggestion = {};
            suggestion.name = restaurant.name;
            suggestion.type = 'restaurant';
            suggestion.description = restaurant.description;
            suggestion.latitude = restaurant.coordinate.latitude;
            suggestion.longitude = restaurant.coordinate.longitude;
            suggestion.rating = getRandom(4, 5);
            suggestion.votes = getRandom(2500, 3000);
            suggestion.picture = restaurant.picture;
            suggestion.createdAt = new Date();
            suggestion.updatedAt = new Date();
            suggestions.push(suggestion);
        });
    });

    return suggestions;
};



// Получить предложения
var getSuggestions = function () {
    var suggestions = getRestaurants();
    // Формируем id
    var id = 1;
    suggestions.forEach(function (suggestion) {
        suggestion.id = id++;
    });
    return suggestions;
};

// Удалить предложение
var deleteSuggestion = function (queryInterface) {
    return queryInterface.bulkDelete('Suggestions');
};

// Добавить предложения
var addSuggestions = function (queryInterface) {
    var suggestions = getSuggestions();
    return queryInterface.bulkInsert('Suggestions', suggestions, {});
};

module.exports = {
    up: (queryInterface, Sequelize) => {
        // Сначала удаляем существующие предложения, а затем асинхронно добавляем
        return deleteSuggestion(queryInterface)
            .then(function () {
                return addSuggestions(queryInterface);
            });
    },

    down: (queryInterface, Sequelize) => {
        /*
          return queryInterface.bulkDelete('Person', null, {});
        */
    }
};
