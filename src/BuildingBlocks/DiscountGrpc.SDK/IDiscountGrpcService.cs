using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountGrpc.SDK
{
    public interface IDiscountGrpcService
    {
        Task<CouponModel> GetDiscountAsync(GetDiscountRequest request, CancellationToken cancellationToken);

    }

    public class DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient grpcClient) : IDiscountGrpcService
    {
        public async Task<CouponModel> GetDiscountAsync(GetDiscountRequest request, CancellationToken cancellationToken)
        {
            var coupon = await grpcClient.GetDiscountAsync(request,
                   cancellationToken: cancellationToken);

            return coupon;
        }
    }
}
