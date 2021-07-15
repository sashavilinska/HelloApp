using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<DayOfWeekProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            int b = 4;
            int z = 0;
            app.Use(async (context, next) =>
            {
                z = b * 2;
                next.Invoke();
                z = z * 2;
                await context.Response.WriteAsync($"{z}");
            });
            app.Run(async (context) =>
            {
                z = z * 2;
                await Task.FromResult(0);
            });


            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //    endpoints.MapGet("/hello/{id}", context => context.Response.WriteAsync("srk"));
            //    endpoints.MapGet("/day", (context) =>
            //    {
            //        var dowProvider = context.RequestServices.GetRequiredService<DayOfWeekProvider>();
            //        var day = dowProvider.GetDayOfWeek();
            //        return context.Response.WriteAsync(day);
            //    });
            //});
        }
    }
}
