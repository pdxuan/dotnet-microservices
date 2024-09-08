using BuildingBlocks.CQRS;
using CatalogAPI.Models;
using Marten.Pagination;

namespace CatalogAPI.Features.Products.GetProducts
{

    public record GetProductsQuery(int? PageNumber = 1, int? PageSize = 10) : IQuery<GetProductsResult>;
    public record GetProductsResult(IEnumerable<Product> Products);

    public class GetProductHandler(IDocumentSession session)
    : IQueryHandler<GetProductsQuery, GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            var products = await session.Query<Product>()
            .ToPagedListAsync(query.PageNumber ?? 1, query.PageSize ?? 10, cancellationToken);

            return new GetProductsResult(products);
        }
    }
}
