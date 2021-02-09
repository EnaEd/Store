using Microsoft.AspNetCore.Builder;
using Store.Shared.Middelwares;

namespace Store.Shared.Extensions
{
    public static class ErrorHandlerExtension
    {
        public static IApplicationBuilder UseErrorHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
