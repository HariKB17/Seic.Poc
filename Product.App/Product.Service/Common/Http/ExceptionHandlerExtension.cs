using Microsoft.AspNetCore.Builder;

namespace Product.Service.Common.Http
{
    /// <summary>
    /// This extension class exposes the ExceptionHandlerMiddleWare through IApplicationBuilder
    /// </summary>
    public static class ExceptionHandlerExtension
    {
        /// <summary>
        /// The method that exposes the ExceptionHandlerMiddleware through IApplicationBuilder
        /// </summary>
        /// <param name="builder">Defines a class that provides the mechanisms to configure an application's request pipeline.</param>
        /// <returns>The <see cref="IApplicationBuilder"/> instance.</returns>
        public static IApplicationBuilder UseGlobalExceptionHandling(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
