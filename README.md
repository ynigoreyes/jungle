# Jungle - a Kafka Demo
I wanted to learn how Kafka works and why people use it. So I created two services, both are producers and consumers using Kafka as the messaging queue.

## Vocabulary that I have learned

* **Broker**:
The part of the Kafka cluster that determines the through put of the system as a whole. The more brokers you have, more consumers that you can have. This is where running on kubernetes is nice for Kafka. Now, we can scale the number of brokers that we have. We can go from 3 to 30 with ease.

These are also synonymous with Kafka **nodes** or **servers**.

* **Serialize/Deserialize**:
This is what makes Kafka and many other systems so fast. To serialize something, means to turn all of its data into a byte array for processing later. This is not encryption. I see this like how you can make an English sentence “one plus one” be “1 + 1” so that everyone can understand it, not just those who speak English.

Deserialize goes the opposite way

## What this demo is about
I created two services, `PlantsService` and `AnimalsService` where the `PlantsService` creates flowers and trees and puts it on the queue while the `AnimalsService` creates monkeys and puts in on the queue.

The services also listen for the creation of these objects and logs it locally

#### Technology Used:
* [Helm](https://helm.sh/) - A package manager for Kubernetes 
* [Kubernetes](https://kubernetes.io/) - A container orchestrator
* [Docker](https://www.docker.com/) - A software used to package code into “container” to run anywhere
* [Visual Studio IDE](https://visualstudio.microsoft.com/) - Integrated Development Environment to write applications
* [.NET](https://dotnet.microsoft.com/) - Microsoft’s developer platform used for creating all types of apps
