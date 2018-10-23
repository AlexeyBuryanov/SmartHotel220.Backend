cd D:\GraduationProject\SmartHotel220.Services.All\src
docker-compose build

$tag = "v14"

docker tag smarthotel220/hotels:latest smarthotel220/hotels:$tag
docker tag smarthotel220/configuration:latest smarthotel220/configuration:$tag
docker tag smarthotel220/notifications:latest smarthotel220/notifications:$tag
docker tag smarthotel220/bookings:latest smarthotel220/bookings:$tag
docker tag smarthotel220/tasks:latest smarthotel220/tasks:$tag
docker tag smarthotel220/suggestions:latest smarthotel220/suggestions:$tag
docker tag smarthotel220/reviews:latest smarthotel220/reviews:$tag
docker tag smarthotel220/discounts:latest smarthotel220/discounts:$tag
docker tag smarthotel220/profiles:latest smarthotel220/profiles:$tag

docker push smarthotel220/hotels:$tag
docker push smarthotel220/configuration:$tag
docker push smarthotel220/notifications:$tag
docker push smarthotel220/bookings:$tag
docker push smarthotel220/tasks:$tag
docker push smarthotel220/suggestions:$tag
docker push smarthotel220/reviews:$tag
docker push smarthotel220/discounts:$tag
docker push smarthotel220/profiles:$tag

kubectl set image deployment/hotels hotels=smarthotel220/hotels:$tag
kubectl set image deployment/config config=smarthotel220/configuration:$tag
kubectl set image deployment/notifications notifications=smarthotel220/notifications:$tag
kubectl set image deployment/bookings bookings=smarthotel220/bookings:$tag
kubectl set image deployment/suggestions suggestions=smarthotel220/suggestions:$tag
kubectl set image deployment/discounts discounts=smarthotel220/discounts:$tag
kubectl set image deployment/profiles profiles=smarthotel220/profiles:$tag
kubectl set image deployment/tasks tasks=smarthotel220/tasks:$tag
kubectl set image deployment/reviews reviews=smarthotel220/reviews:$tag

kubectl get pod

pause