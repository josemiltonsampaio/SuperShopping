﻿using RabbitMQ.Client;
using SuperShopping.CartAPI.DTO;
using SuperShopping.MessageBus;
using System.Text;
using System.Text.Json;

namespace SuperShopping.CartAPI.RabbitMQSender;

public class RabbitMQMessageSender : IRabbitMQMessageSender
{
    private readonly string _hostname;
    private readonly string _password;
    private readonly string _username;
    private IConnection _connection;

    public RabbitMQMessageSender()
    {
        _hostname = "localhost";
        _password = "guest";
        _username = "guest";
    }

    public void SendMessage(BaseMessage message, string queueName)
    {
        var factory = new ConnectionFactory
        {
            HostName = _hostname,
            UserName = _username,
            Password = _password
        };

        _connection = factory.CreateConnection();

        using var channel = _connection.CreateModel();
        channel.QueueDeclare(queue: queueName, false, false, false, arguments: null);
        byte[] body = GetMessageAsByteArray(message);
        channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);

    }

    private byte[] GetMessageAsByteArray(BaseMessage message)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
        };

        var json = JsonSerializer.Serialize<CheckoutDTO>((CheckoutDTO)message, options);
        var body = Encoding.UTF8.GetBytes(json);
        return body;
    }
}
