using Newtonsoft.Json;
using System.Net;
using Megasave.Application.Exceptions;

namespace Megasave.Web.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (System.Exception ex)
            {
                await ConvertException(context, ex);
            }
        }

        private Task ConvertException(HttpContext context, System.Exception exception)
        {
            HttpStatusCode httpStatusCode;

            context.Response.ContentType = "application/json";

            var result = string.Empty;

            switch (exception)
            {
                case ValidationException validationException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    result = JsonConvert.SerializeObject(validationException.ValdationErrors);
                    break;
                case BadRequestException badRequestException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    result = badRequestException.Message;
                    break;
                case IdentityException identityException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    result = JsonConvert.SerializeObject(identityException.ValidationErrors);
                    break;
                case NotFoundException notFoundException:
                    httpStatusCode = HttpStatusCode.NotFound;
                    break;
                default:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    break;
            }

            context.Response.StatusCode = (int)httpStatusCode;

            if (result == string.Empty)
            {
                result = JsonConvert.SerializeObject(new { error = exception.ToString() });
            }
            //context.Items.Add("errorMessage",result);
            //context.Response.Redirect("/Home/Error");
            return context.Response.WriteAsync(result);
        }
    }
}
