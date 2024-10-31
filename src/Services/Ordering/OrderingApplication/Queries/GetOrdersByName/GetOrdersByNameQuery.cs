using BuildingBlocks.CQRS;
using OrderingApplication.Dtos;


namespace OrderingApplication.Queries.GetOrdersByName
{
    public record GetOrdersByNameQuery(string Name)
      : IQuery<GetOrdersByNameResult>;

    public record GetOrdersByNameResult(IEnumerable<OrderDto> Orders);
}
