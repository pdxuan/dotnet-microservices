using BasketAPI.Repository;
using BuildingBlocks.CQRS;
using DiscountGrpc;
using DiscountGrpc.SDK;
using FluentValidation;
using Grpc.Net.Client;

namespace BasketAPI.Basket.StoreBasket
{

    public record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;
    public record StoreBasketResult(string UserName);


    public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
    {
        public StoreBasketCommandValidator()
        {
            RuleFor(x => x.Cart).NotNull().WithMessage("Cart can not be null");
            RuleFor(x => x.Cart.UserName).NotEmpty().WithMessage("UserName is required");
        }
    }


    public class StoreBasketHandler(IBasketRepository repository, IDiscountGrpcService discountGrpcService) : ICommandHandler<StoreBasketCommand, StoreBasketResult>
    {
        public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
        {

            // Calculate latest price of products
            foreach (var item in command.Cart.Items)
            {
                var coupon = await discountGrpcService.GetDiscountAsync(new GetDiscountRequest { ProductName = item.ProductName },
                    cancellationToken: cancellationToken);

                item.Price -= coupon.Amount;
            }

            await repository.StoreBasket(command.Cart, cancellationToken);

            return new StoreBasketResult(command.Cart.UserName);
        }


    }
}
