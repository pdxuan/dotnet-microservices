using BuildingBlocks.CQRS;
using CatalogAPI.Models;
using MediatR;

namespace CatalogAPI.Features.Products.CreateProduct
{

    //MediatR Library that HandlerClass : IRequestHandler<TRequest, TResponse>
    public record CreateProductCommand(Product product) : ICommand<CreateProductResult>;

    public record CreateProductResult(Guid Id);



    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            Product product = command.product;


            return new CreateProductResult(Guid.NewGuid());
        }
    }
}
