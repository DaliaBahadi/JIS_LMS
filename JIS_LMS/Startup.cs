
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
//using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using JIS_LMS.Data;
using JIS_LMS.Model;
using JIS_LMS.Services;


namespace JIS_LMS
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
            services.AddSingleton<WeatherForecastService>();

            // Add DbContext to services
            services.AddDbContext<LMSDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //Employee Service
            services.AddScoped<EmployeeService>();

            //Publisher Service
            services.AddScoped<PublisherService>();

            //Address Service
            services.AddScoped<AddressService>();

            //Library Service
            services.AddScoped<LibraryService>();

            //Parent Service
            services.AddScoped<ParentService>();

            //Patron Service
            services.AddScoped<PatronService>();

            //Teacher Service
            services.AddScoped<TeacherService>();

            //Student Service
            services.AddScoped<StudentService>();

            //Author Service
            services.AddScoped<AuthorService>();

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
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
