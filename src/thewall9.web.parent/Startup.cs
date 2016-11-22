using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.Extensions.DependencyInjection;
using thewall9.web.parent.Controllers;
using System.Reflection;
using thewall9.web.parent.Filters;

namespace thewall9.web.parent
{
    public static class Startup
    {
        public static void AddMyMvc(this IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(FilterBase));
            })
                .AddApplicationPart(typeof(HomeController).GetTypeInfo().Assembly)
                .AddControllersAsServices();
        }
        public static void UseMyMvc(this IApplicationBuilder app)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
