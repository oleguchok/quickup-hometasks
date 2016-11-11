using FiltersWebApp.Core.Middleware;
using Microsoft.AspNetCore.Builder;

namespace FiltersWebApp.Core.Extensions
{
    public static class AppBuilderExtensions
    {
        public static IApplicationBuilder UseProductRequest(this IApplicationBuilder appBuilder)
        {
            return appBuilder.UseMiddleware<ProductRequestMiddleware>();
        }
    }
}
