$tagPush = "v8"

docker tag smarthotel220/hotels:latest smarthotel220/hotels:$tagPush
docker tag smarthotel220/configuration:latest smarthotel220/configuration:$tagPush
docker tag smarthotel220/notifications:latest smarthotel220/notifications:$tagPush
docker tag smarthotel220/bookings:latest smarthotel220/bookings:$tagPush
docker tag smarthotel220/tasks:latest smarthotel220/tasks:$tagPush
docker tag smarthotel220/suggestions:latest smarthotel220/suggestions:$tagPush
docker tag smarthotel220/reviews:latest smarthotel220/reviews:$tagPush
docker tag smarthotel220/discounts:latest smarthotel220/discounts:$tagPush
docker tag smarthotel220/profiles:latest smarthotel220/profiles:$tagPush

docker push smarthotel220/hotels:$tagPush
docker push smarthotel220/configuration:$tagPush
docker push smarthotel220/notifications:$tagPush
docker push smarthotel220/bookings:$tagPush
docker push smarthotel220/tasks:$tagPush
docker push smarthotel220/suggestions:$tagPush
docker push smarthotel220/reviews:$tagPush
docker push smarthotel220/discounts:$tagPush
docker push smarthotel220/profiles:$tagPush

pause