using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountGrpc.SDK
{
    public static class ServiceCollectionExtention
    {
        public static void AddGrpcSdk(this IServiceCollection services, string serverAddress)
        {
            services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient> (client =>
            {
                client.Address = new Uri(serverAddress);
            });

            services.AddScoped<IDiscountGrpcService, DiscountGrpcService>();
        }
    }
}
