using Microsoft.AspNetCore.Builder;
using SIGNALR_APP.TableDependencies;

namespace SIGNALR_APP.MiddlewareExtensions
{
    public static class ApplicationBuilderExtension
    {

        public static void UseProductTableDependency(this IApplicationBuilder applicationBuilder)
        {

             var serviceProvider = applicationBuilder.ApplicationServices;
             var service = serviceProvider.GetService<ProductTableDependency>();
             service.PTableDependency();

        }

        public static void UseOrderTableDependency(this IApplicationBuilder applicationBuilder)
        {

            var serviceProvider = applicationBuilder.ApplicationServices;
            var service = serviceProvider.GetService<OrderTableDependency>();
            service.OTableDependency();

        }

        public static void UseSaleTableDependency(this IApplicationBuilder applicationBuilder)
        {

            var serviceProvider = applicationBuilder.ApplicationServices;
            var service = serviceProvider.GetService<SaleTableDependency>();
            service.STableDependency();

        }
    }
}
