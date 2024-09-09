using BuildingBlocks.CQRS;
using BuildingBlocks.Exeptions;
using CatalogAPI.Models;

namespace CatalogAPI.Features.Products.GetProductById
{

    public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;
    public record GetProductByIdResult(Product Product);

    public class GetProductByIdHandler(IDocumentSession session)
    : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
    {

        public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            var product = await session.LoadAsync<Product>(query.Id, cancellationToken);
            
            if(product is null)
            {
                throw new NotFoundException("product not found");
            }

            return new GetProductByIdResult(product!);
        }

    }
}
