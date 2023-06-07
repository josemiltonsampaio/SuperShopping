using SuperShopping.MessageBus;

namespace SuperShopping.CartAPI.RabbitMQSender;

public interface IRabbitMQMessageSender
{
    void SendMessage(BaseMessage baseMessage, string queueName);
}
