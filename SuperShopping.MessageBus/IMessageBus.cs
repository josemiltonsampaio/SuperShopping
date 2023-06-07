namespace SuperShopping.MessageBus;
internal interface IMessageBus
{
    Task PublicMessage(BaseMessage message, string queueName);
}
