


namespace BasketAPI.Basket.GetBasket
{

    public record GetBasketResponse(ShoppingCart Cart);

    public class GetBasketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/basket/{userName}", async (string userName, ISender sender) =>
            {

                var cts = new CancellationTokenSource();

                // Cancel if the response take over 3 senconds
                cts.CancelAfter(3000);

                var result = await sender.Send(new GetBasketQuery(userName), cts.Token);

                var respose = result.Adapt<GetBasketResponse>();

                return Results.Ok(respose);
            })
       .WithName("GetBasket")
       .Produces<GetBasketResponse>(StatusCodes.Status200OK)
       .ProducesProblem(StatusCodes.Status400BadRequest)
       .WithSummary("GetBasket")
       .WithDescription("GetBasket");
        }
    }
}
