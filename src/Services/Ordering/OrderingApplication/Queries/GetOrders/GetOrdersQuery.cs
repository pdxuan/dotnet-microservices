using BuildingBlocks.CQRS;
using BuildingBlocks.Pagination;
using OrderingApplication.Dtos;


namespace OrderingApplication.Queries.GetOrders
{
    public record GetOrdersQuery(PaginationRequest PaginationRequest)
    : IQuery<GetOrdersResult>;

    public record GetOrdersResult(PaginatedResult<OrderDto> Orders);
}
