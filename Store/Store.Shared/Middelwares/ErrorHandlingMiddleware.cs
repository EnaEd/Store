using Microsoft.AspNetCore.Http;
using Store.Shared.Common;
using Store.Shared.Enums;
using Store.Shared.Extensions;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.Shared.Middelwares
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
            try
            {
                await _next.Invoke(context);
            }
            catch (UserException ex)
            {
                string errorContent = JsonSerializer.Serialize(ex.Descriptions);
                string response = $"Error:{(int)ex.Code} {(ex.Code).GetAttribute<EnumDescriptor>().Description}\n {errorContent}";
                context.Response.StatusCode = (int)ex.Code;
                await context.Response.WriteAsync(response);
            }
            catch (Exception ex)
            {
                //TODO EE: add logger
            }
        }

    }
}
