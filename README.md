# SuperShopping

Used technologies:
ASP.NET, C#, SQL Server, WebAPI, MVC, RabbitMQ, Entity Framework, Log (NLog).

- It is a solution using the microservice architecture. The solution as a whole is simple and a monolith would be more adequated, but I wanted to show how to implement microservices in ASP.NET.
- All hardcoded secrets and/or password would be in Azure Vault or other services do make it secure, when in production.
- Each microservice should have its own database.
- The way it was designed, it is possible to have many replicas of each service in a Kubernetes cluster.
  

The main solution has 5 projects:

<b>1-AuthAPI</b>

Where all the authentication is made. I used Identity Framework and SQL Server.
It was built based on JWT. 

<b>2-ProductAPI</b>

Microservice for all the products. It would be used to create the shop's list of products. Once the client put the product in a cart, the next microservice is called.

<b>3-CartAPI</b>

Where the cart is managed. The product's information is "duplicated" here, because we have to keep the services independent.
Once the client proceed to checkout the cart, the information will be sent to RabbitMQ.

<b>4-MessageBus</b>

It is just a place to share the interface and implementation of a message. It could be a Nuget package.

<b>5-OrderAPI</b>

It listens to RabbitMQ queue and once an order is created, this microservice would use a third party payment gateway to finish the process.


It's necessary to run:
docker run -d --hostname my-rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management

