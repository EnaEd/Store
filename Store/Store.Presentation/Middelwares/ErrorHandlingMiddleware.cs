namespace Store.Presentation.Middelwares
{
    //public class ErrorHandlingMiddleware
    //{
    //    private RequestDelegate _next;
    //    public ErrorHandlingMiddleware(RequestDelegate next)
    //    {
    //        _next = next;
    //    }
    //    public async Task InvokeAsync(HttpContext context)
    //    {
    //        try
    //        {
    //            await _next.Invoke(context);
    //        }
    //        catch (UserException ex)
    //        {
    //            context.Response.StatusCode = (int)ex.Code;
    //            await context.Response.WriteAsync(
    //            $"Error:{(int)ex.Code} {(ex.Code).GetAttribute<EnumDescriptor>().Description}\n {ex.Description}");
    //        }
    //    }

    //}
}
