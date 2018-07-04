using System;
using Amadiere.Blog;
using Amadiere.Blog.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;

namespace Amadiere.Website
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<IArticleReader, ArticleReader>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }

            app.UseStaticFiles(new StaticFileOptions()
            {
                OnPrepareResponse = (context) =>
                {
                    var headers = context.Context.Response.GetTypedHeaders();
                    headers.CacheControl = new CacheControlHeaderValue()
                    {
                        MaxAge = TimeSpan.FromDays(350),
                    };
                }
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "sitemap",
                    template: "sitemap.xml",
                    defaults: new {controller = "Sitemap", action = "Index"});

                routes.MapRoute(
                    name: "error-handling",
                    template: "error/{httpStatusCode}",
                    defaults: new { controller = "Error", action = "Index", httpStatusCode = "500" });

                routes.MapRoute(
                    name: "blog-articles",
                    template: "blog/{year}/{month}/{slug}",
                    defaults: new { controller = "Blog", action = "Article" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
