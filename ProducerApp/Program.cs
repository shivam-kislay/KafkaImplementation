using System;
using System.Collections.Generic;
using KafkaNet;
using KafkaNet.Model;
using KafkaNet.Protocol;
namespace ProducerApp
{
    class Program
    {
        static void Main(string[] args)
        {
           
            string topic = "TestTopic";
            Console.WriteLine("Enter the message to pass");
            string payload = Console.ReadLine();
            Message msg = new Message(payload);
            Uri uri = new Uri("http://localhost:9092");
            var options = new KafkaOptions(uri);
            var router = new BrokerRouter(options);
            var client = new Producer(router);
            client.SendMessageAsync(topic, new List<Message> { msg }).Wait();
            Console.ReadLine();
        }
    }
}
