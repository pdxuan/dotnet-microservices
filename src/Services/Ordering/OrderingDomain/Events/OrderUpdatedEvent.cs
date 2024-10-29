

namespace OrderingDomain.Events
{
    public record OrderUpdatedEvent(Order order) : IDomainEvent
    {

    }
}
