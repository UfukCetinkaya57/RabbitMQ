﻿using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.IO;
using System.Text;
using System.Threading;

namespace RabbitMQ.Subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqp://guest:guest@localhost:5672/");

            using var connection = factory.CreateConnection();

            var channel = connection.CreateModel();


            channel.BasicQos(0, 1, false);
            var consumer = new EventingBasicConsumer(channel);

            var queueName = "direct-queue-Critical";
            channel.BasicConsume(queueName, false, consumer);

            Console.WriteLine("Listening to logs...");

            consumer.Received += (object sender, BasicDeliverEventArgs e) =>
            {
                var message = Encoding.UTF8.GetString(e.Body.ToArray());

                Thread.Sleep(1500);
                Console.WriteLine("Send message:" + message);

                channel.BasicAck(e.DeliveryTag, false);
            };





            Console.ReadLine();
        }


    }
}