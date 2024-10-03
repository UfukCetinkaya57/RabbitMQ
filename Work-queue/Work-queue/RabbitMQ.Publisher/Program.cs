using RabbitMQ.Client;
using System;
using System.Linq;
using System.Text;

namespace RabbitMQ.Publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqp://guest:guest@localhost:5672/");

            using var connection = factory.CreateConnection();

            var channel = connection.CreateModel();

            channel.QueueDeclare("work-queue", true, false, false);

            Enumerable.Range(1, 50).ToList().ForEach(x =>
            {

                string message = $"Message {x}";

                var messageBody = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(string.Empty, "work-queue", null, messageBody);

                Console.WriteLine($"Send message : {message}");

            });



            Console.ReadLine();


        }
    }
}