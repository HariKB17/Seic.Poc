using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Product.Domain.Common;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Product.Service.Common.Http
{
    /// <summary>
    /// Middleware that will catch exceptions and turn them into standard HTTP responses.
    /// </summary>
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionHandlerMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next.</param>
        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Invokes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                if (context.Response.HasStarted) return;

                // TODO: Log error to Db and get error ID, instead of generic exception
                var errorMessage = "Internal server error";

                var methodResponse = new MethodResponse();
                methodResponse.AddErrorMessage("Service Error", errorMessage);
                var genericResponseModel = new GenericResponseModel<int>();
                genericResponseModel.Build(methodResponse);
                var jsonString = JsonSerialize(genericResponseModel);

                context.Response.Clear();
                context.Response.ContentType = "application/json";

                // The status code must be set before the response is written
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync(jsonString);
            }
        }

        private string JsonSerialize(object obj)
        {
            var builder = new StringBuilder();
            var writer = new StringWriter(builder);
            var serializer = JsonSerializer.Create();
            serializer.Serialize(writer, obj);

            return builder.ToString();
        }
    }
}
