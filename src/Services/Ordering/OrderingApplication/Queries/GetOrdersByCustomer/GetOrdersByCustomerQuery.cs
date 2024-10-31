using BuildingBlocks.CQRS;
using OrderingApplication.Dtos;


namespace OrderingApplication.Queries.GetOrdersByCustomer
{
    public record GetOrdersByCustomerQuery(Guid CustomerId)
        : IQuery<GetOrdersByCustomerResult>;

    public record GetOrdersByCustomerResult(IEnumerable<OrderDto> Orders);

}
