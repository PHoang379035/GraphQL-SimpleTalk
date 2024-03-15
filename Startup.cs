using Microsoft.AspNetCore.Server.Kestrel.Core;
using GraphQL;
using GraphQL_SimpleTalk.Controllers;
using GraphQL_SimpleTalk.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace GraphQL_SimpleTalk
{
    public class Startup
    {
        public const string GraphQlPath = "/graphql";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            // Inject các interfaces

            // Cấu hình GraphQL
            services.AddScoped<BlogService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Cấu hình GraphQL
            app.UseGraphQLGraphiQL(GraphQlPath);

            // Cấu hình giao diện Playground


            // Cấu hình giao diện Graphiql


            // Cấu hình giao diện Voyager


            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("AspNetCore GraphQL Test");
                });
                endpoints.MapControllers();
            });
        }
    }
}