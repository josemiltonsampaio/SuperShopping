using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SuperShopping.OrderAPI.DTO;
using SuperShopping.OrderAPI.Models;
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
        OrderHeader order = new OrderHeader
        {
            UserId = checkoutDTO.UserId,
            FirstName = checkoutDTO.FirstName,
            LastName = checkoutDTO.LastName,
            Items = new List<OrderItem>(),
            CardNumber = checkoutDTO.CardNumber,
            CVV = checkoutDTO.CVV,
            Email = checkoutDTO.Email,
            ExpirationDate = checkoutDTO.ExpirationDate,
            OrderTime = DateTime.Now,
            PaymentStatus = false,
            Phone = checkoutDTO.Phone,
            PurchaseTime = checkoutDTO.DateTime
        };


        //TODO: The error happens here because what is sent to rabbitmq has a different schema and the product info
        //is not being loaded
        foreach (var item in checkoutDTO.Cart.Items)
        {
            OrderItem newItem = new OrderItem()
            {
                ProductId = item.ProductId,
                ProductName = item.ProductName,
                Price = item.Price,
                Quantity = item.Quantity
            };
            order.Items.Add(newItem);
        }

        await _orderRepository.AddOrder(order);

    }
}
