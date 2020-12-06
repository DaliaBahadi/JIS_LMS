
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
using Syncfusion.Blazor;


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

            // Add Syncfusion service
            services.AddSyncfusionBlazor();

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

            //Donor Service
            services.AddScoped<DonorService>();

            //Libray Material  Service
            services.AddScoped<Library_MaterialService>();

            //Libray Material  Service
            services.AddScoped<Library_MaterialService>();

            //Journal  Service
            services.AddScoped<JournalService>();

            //Book  Service
            services.AddScoped<BookService>();

            //cd-dvd-Br  Service
            services.AddScoped<CD_DVD_BR_Service>();

            //Borrowing Service
            services.AddScoped<BorrowingService>();

            //Hold Service
            services.AddScoped<HoldService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzM5NjkzQDMxMzgyZTMzMmUzMGowcEl3bmhTYkxDODluVzFRWHJrakRLQzRGT2h5OEhLUTZoZWZhMVNuK2c9");

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
