using CatalogAPI.Models;

namespace CatalogAPI.Features.Products.GetProductByCategory
{

    public record GetProductByCategoryRequest(List<string> Categories);

    public record GetProductByCategoryResponse(IEnumerable<Product> Products);


    public class GetProductByCategoryEnpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/products/category",
            async (List<string> categories, ISender sender) =>
            {
                var result = await sender.Send(new GetProductByCategoryQuery(categories));

                var response = result.Adapt<GetProductByCategoryResponse>();

                return Results.Ok(response);
            })
        .WithName("GetProductByCategory")
        .Produces<GetProductByCategoryResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Product By Category")
        .WithDescription("Get Product By Category");
        }
    }
}
