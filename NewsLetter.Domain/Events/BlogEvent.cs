using MediatR;

namespace NewsLetter.Domain.Events;
public sealed record BlogEvent(
    Guid BlogId) : INotification;
