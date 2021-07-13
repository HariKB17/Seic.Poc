using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Product.Domain.DataAccess;
using Product.Domain.DataAccess.Interfaces;
using System.Net;
using Microsoft.AspNetCore.Http;
using Product.Domain.Business;
using Product.Domain.Business.Interfaces;
using Product.Service.Areas.V1.Mappers;
using Product.Service.Areas.V1.Mappers.Interfaces;
using Product.Service.Common.Http;

namespace Product.Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <remarks>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </remarks>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped(_ => new ProductDbContext(
                new DbContextOptionsBuilder<DbContext>().Options,
                Configuration["ConnectionStrings:ProductDbConnectionString"]));

            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Product.Service", Version = "v1" });
            });

            ConfigureMappersIoc(services);
            ConfigureBusinessIoc(services);
            ConfigureFluentValidatorsIoc(services);
            ConfigureRepositoryIoc(services);
        }


        /// <summary>
        /// Configures the specified application builder.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <remarks>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </remarks>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product.Service v1"));
            } 

            // global cors policy
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials

            app.UseExceptionHandler(
                options =>
                {
                    options.Run(async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        context.Response.ContentType = "text/html";
                        var ex = context.Features.Get<IExceptionHandlerFeature>();
                        if (ex != null)
                        {
                            var err = $"<h1>Error: {ex.Error.Message}</h1>{ex.Error.StackTrace}";
                            await context.Response.WriteAsync(err).ConfigureAwait(false);
                        }
                    });
                });

            app.UseGlobalExceptionHandling();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        /// <summary>
        /// Configures the mappers for IOC.
        /// </summary>
        /// <param name="services">The services.</param>
        private void ConfigureMappersIoc(IServiceCollection services)
        {
            services.AddTransient<IProductModelMapper, ProductModelMapper>();
            services.AddTransient<IProductAttributeModelMapper, ProductAttributeModelMapper>();
        }

        /// <summary>
        /// Configures the business classes for IOC.
        /// </summary>
        /// <param name="services">The services.</param>
        private void ConfigureBusinessIoc(IServiceCollection services)
        {
            services.AddTransient<IProductRetriever, ProductRetriever>();
            services.AddTransient<IProductAttributeRetriever, ProductAttributeRetriever>();
        }

        /// <summary>
        /// Configures the repositories for IOC.
        /// </summary>
        /// <param name="services">The services.</param>
        private void ConfigureRepositoryIoc(IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductAttributeRepository, ProductAttributeRepository>();
        }

        /// <summary>
        /// Configures the fluent validators for IOC.
        /// </summary>
        /// <param name="services">The services.</param>
        private void ConfigureFluentValidatorsIoc(IServiceCollection services)
        {
        }
    }
}
