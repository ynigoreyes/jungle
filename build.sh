docker build -t jungle/animals-service:latest --build-arg PROJECT=AnimalsService . &
docker build -t jungle/plants-service:latest --build-arg PROJECT=PlantsService . &
wait

