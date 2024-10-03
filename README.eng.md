# RabbitMQ Exchange Examples

This project showcases different types of RabbitMQ Exchanges. The following exchange types have been implemented in separate directories:

- **Direct Exchange**
- **Fanout Exchange**
- **Header Exchange**
- **Topic Exchange**
- **Work Queue**

## Requirements

To run this project, the following tools are required:

- [Docker](https://www.docker.com/)
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- RabbitMQ (Instructions for running RabbitMQ via Docker are provided below)

### Running RabbitMQ with Docker

To run RabbitMQ using Docker, use the following command:
```
docker run -d -p 5672:5672 -p 15672:15672 --name rabbitmqcontainer rabbitmq:4.0-management
```


This command runs RabbitMQ on the default ports (5672 and 15672). You can access the management panel at `http://localhost:15672`. The default username and password are `guest/guest`.

## Directory Structure

Each directory contains a different RabbitMQ exchange model. Inside these directories, you will find both **Publisher** and **Subscriber** examples. Below is an explanation of how each works.

### Direct Exchange

- **Publisher**: Sends messages directly to the queue based on the log type and routing key.
- **Subscriber**: Listens to and processes messages based on a specific routing key.

### Fanout Exchange

- **Publisher**: Broadcasts messages to all subscribers. Messages are distributed to all queues without using a routing key.
- **Subscriber**: Listens to all incoming messages.

### Header Exchange

- **Publisher**: Sends messages based on header parameters.
- **Subscriber**: Receives messages based on header parameters.

### Topic Exchange

- **Publisher**: Sends messages to queues based on routing keys matching a pattern.
- **Subscriber**: Listens to messages that match a specific pattern.

### Work Queue

- **Publisher**: Sends tasks to the queue. The tasks are distributed evenly among workers.
- **Subscriber**: Processes the tasks from the queue sequentially.

## Running the Project

1. **Run RabbitMQ with Docker**:
    ```
    docker run -d -p 5672:5672 -p 15672:15672 --name rabbitmqcontainer rabbitmq:4.0-management
    ```

2. Build the .NET project:
    ```
    dotnet build
    ```

3. To run the project in the relevant directory, use the following command:
    ```
    dotnet run
    ```

Example:
```
cd Direct-exchange/Direct-exchange dotnet run
```


Repeat these steps for each directory.
