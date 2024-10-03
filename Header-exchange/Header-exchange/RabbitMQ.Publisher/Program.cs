using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RabbitMQ.publisher
{
    public enum LogNames
    {
        Critical = 1,
        Error = 2,
        Warning = 3,
        Info = 4
    }


    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqp://guest:guest@localhost:5672/");

            using var connection = factory.CreateConnection();

            var channel = connection.CreateModel();

            channel.ExchangeDeclare("header-exchange", durable: true, type: ExchangeType.Headers);


            Dictionary<string, object> headers = new Dictionary<string, object>();

            headers.Add("format", "jpg");
            headers.Add("shape3", "a3");

            var properties = channel.CreateBasicProperties();
            properties.Headers = headers;



            channel.BasicPublish("header-exchange", string.Empty, properties, Encoding.UTF8.GetBytes("header messagge"));

            Console.WriteLine("Message sent");

            Console.ReadLine();


        }
    }
}