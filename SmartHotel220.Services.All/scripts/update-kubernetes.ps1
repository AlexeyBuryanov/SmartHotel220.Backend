$tagUpdate = "v10"

kubectl set image deployment/hotels hotels=smarthotel220/hotels:$tagUpdate
kubectl set image deployment/config config=smarthotel220/configuration:$tagUpdate
kubectl set image deployment/notifications notifications=smarthotel220/notifications:$tagUpdate
kubectl set image deployment/bookings bookings=smarthotel220/bookings:$tagUpdate
kubectl set image deployment/suggestions suggestions=smarthotel220/suggestions:$tagUpdate
kubectl set image deployment/discounts discounts=smarthotel220/discounts:$tagUpdate
kubectl set image deployment/profiles profiles=smarthotel220/profiles:$tagUpdate
kubectl set image deployment/tasks tasks=smarthotel220/tasks:$tagUpdate
kubectl set image deployment/reviews reviews=smarthotel220/reviews:$tagUpdate

kubectl get pod

pause