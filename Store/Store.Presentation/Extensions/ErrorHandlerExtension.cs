using Microsoft.AspNetCore.Builder;
using Store.Presentation.Middelwares;

namespace Store.Presentation.Extensions
{
    public static class ErrorHandlerExtension
    {
        public static IApplicationBuilder UseErrorHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
