using Microsoft.AspNetCore.Http;
using Store.Shared.Enums;
using Store.Shared.Extensions;
using System.Threading.Tasks;

namespace Store.Presentation.Middelwares
{
    public class ErrorHandlingMiddleware
    {
        private RequestDelegate _next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            await _next.Invoke(context);
            switch (context.Response.StatusCode)
            {
                case (int)ErrorCode.BadRequest:
                    await context.Response.WriteAsync(
                        $"Error:{(int)ErrorCode.BadRequest} {(ErrorCode.BadRequest).GetAttribute<EnumDescriptor>().Description}");
                    break;

                case (int)ErrorCode.Forbidden:
                    await context.Response.WriteAsync(
                        $"Error:{(int)ErrorCode.Forbidden} {(ErrorCode.Forbidden).GetAttribute<EnumDescriptor>().Description}");
                    break;

                case (int)ErrorCode.InternalServerError:
                    await context.Response.WriteAsync(
                       $"Error:{(int)ErrorCode.InternalServerError} {(ErrorCode.InternalServerError).GetAttribute<EnumDescriptor>().Description}");
                    break;

                case (int)ErrorCode.MethodNotAllowed:
                    await context.Response.WriteAsync(
                       $"Error:{(int)ErrorCode.MethodNotAllowed} {(ErrorCode.MethodNotAllowed).GetAttribute<EnumDescriptor>().Description}");
                    break;

                case (int)ErrorCode.NotFound:
                    await context.Response.WriteAsync(
                       $"Error:{(int)ErrorCode.NotFound} {(ErrorCode.NotFound).GetAttribute<EnumDescriptor>().Description}");
                    break;

                case (int)ErrorCode.RequestTimeout:
                    await context.Response.WriteAsync(
                       $"Error:{(int)ErrorCode.RequestTimeout} {(ErrorCode.RequestTimeout).GetAttribute<EnumDescriptor>().Description}");
                    break;

                case (int)ErrorCode.Unauthorized:
                    await context.Response.WriteAsync(
                       $"Error:{(int)ErrorCode.Unauthorized} {(ErrorCode.Unauthorized).GetAttribute<EnumDescriptor>().Description}");
                    break;

                default:
                    break;
            }
        }

    }
}
