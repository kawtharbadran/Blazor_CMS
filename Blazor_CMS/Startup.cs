using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BlazorCMS.Data;
using Microsoft.EntityFrameworkCore;
using BlazorCMS.Grid;

namespace BlazorCMS
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            // Use the provider to get the factory from the services, configure DB connection
            services.AddDbContextFactory<ContactContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            // pager
            services.AddScoped<IPageHelper, PageHelper>();

            // sorting
            services.AddScoped<IContactSort, GridSort>();

            // query adapter for sorting contacts
            services.AddScoped<GridQueryAdapter>();

            // service to communicate success on edit between pages
            services.AddScoped<EditSuccess>();

            // Add Contact Context based on Context Factory returned to service provider
            services.AddScoped<ContactContext>(p =>
                p.GetRequiredService<IDbContextFactory<ContactContext>>()
                .CreateDbContext());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
