using BuildingBlocks.CQRS;
using CatalogAPI.Features.Products.GetProducts;
using CatalogAPI.Models;
using Marten.Pagination;

namespace CatalogAPI.Features.Products.GetProductByCategory
{

    public record GetProductByCategoryResult(IEnumerable<Product> Products);

    public record GetProductByCategoryQuery(List<string> Categories) : IQuery<GetProductByCategoryResult>;

    public class GetProductByCategoryHandler(IDocumentSession session) : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
    {
        public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
        {
            var products = await session.Query<Product>().Where(product => product.Categories.Intersect(query.Categories).Count() > 0).ToListAsync();

            return new GetProductByCategoryResult(products);
        }
    }
}
