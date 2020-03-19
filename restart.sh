./kafka/kafka-delete.sh
kubectl delete -f deployment.yaml
kubectl apply -f deployment.yaml
./kafka/kafka-deploy.sh