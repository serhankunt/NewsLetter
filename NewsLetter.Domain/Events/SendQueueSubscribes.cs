using MediatR;
using Microsoft.EntityFrameworkCore;
using NewsLetter.Domain.Repositories;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NewsLetter.Domain.Events;

public sealed class SendQueueSubscribes(ISubscribeRepository subscribeRepository) : INotificationHandler<BlogEvent>
{
    public async Task Handle(BlogEvent notification, CancellationToken cancellationToken)
    {
        var factory = new ConnectionFactory { HostName = "localhost" };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare(
            queue: "newsletter",
            exclusive: false,
            autoDelete: false,
            arguments: null);

        List<string> emails = await subscribeRepository.Where(p => p.EmailConfirmed).Select(p => p.Email).ToListAsync();
        foreach (string email in emails)
        {
            var data = new
            {
                Email = email,
                BlogId = notification.BlogId
            };

            string message = JsonSerializer.Serialize(data);

            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(
                exchange: string.Empty,
                routingKey: "newsletter",
                basicProperties: null,
                body: body);

            Console.WriteLine($" [x] {email} sended queue");
        }
        await Task.CompletedTask;
    }
}
