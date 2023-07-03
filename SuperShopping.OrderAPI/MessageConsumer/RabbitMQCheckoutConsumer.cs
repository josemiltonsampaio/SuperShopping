using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SuperShopping.OrderAPI.DTO;
using SuperShopping.OrderAPI.Repository;
using System.Text;
using System.Text.Json;

namespace SuperShopping.OrderAPI.MessageConsumer;

public class RabbitMQCheckoutConsumer : BackgroundService
{
    private readonly OrderRepository _orderRepository;
    private IConnection _connection;
    private IModel _channel;

    public RabbitMQCheckoutConsumer(OrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
        var factory = new ConnectionFactory
        {
            HostName = "localhost",
            UserName = "guest",
            Password = "guest"
        };

        _connection = factory.CreateConnection();

        _channel = _connection.CreateModel();
        _channel.QueueDeclare(queue: "checkoutqueue", false, false, false, null);
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        stoppingToken.ThrowIfCancellationRequested();
        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += (channel, evt) =>
        {
            var content = Encoding.UTF8.GetString(evt.Body.ToArray());
            CheckoutDTO checkout = JsonSerializer.Deserialize<CheckoutDTO>(content);
            ProcessOrder(checkout);
            _channel.BasicAck(evt.DeliveryTag, false);
        };

        _channel.BasicConsume("checkoutqueue", false, consumer);
        return Task.CompletedTask;
    }

    private async Task ProcessOrder(CheckoutDTO checkoutDTO)
    {
        //Order processed
        //I could implement here a call to a third party payment gateway
    }
}
