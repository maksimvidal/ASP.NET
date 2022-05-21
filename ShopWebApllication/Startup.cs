using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using IHostingEnvironment = Microsoft.Extensions.Hosting.IHostingEnvironment;
using ShopWebApllication.Data;
using Microsoft.EntityFrameworkCore;
using ShopWebApllication.Data.Interfaces;
using ShopWebApllication.Data.Repository;
using ShopWebApllication.Data.Models;

namespace ShopWebApllication
{
    public class Startup
    {

        private IConfigurationRoot _confString;
        public Startup(IHostingEnvironment hostEnv)
        {
            //отримання файлу зі строкою підключення БД
            _confString = new ConfigurationBuilder().SetBasePath(hostEnv.
           ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
          //  services.AddScoped(sp => Purchase.GetCart(sp));
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(
_confString.GetConnectionString("DefaultConnection")));
            services.AddSession();
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddRazorPages();
            services.AddControllers();
            services.AddTransient<IAllCategories, CategoryRepository>();
            services.AddTransient<IAllFurnitures, FurnitureRepository>();
            services.AddTransient<IPurchaseRepository, PurchaseRepository>();
            services.AddMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSession();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseMvcWithDefaultRoute();
            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContent content = scope.ServiceProvider.
               GetRequiredService<AppDBContent>();
                DBObjects.Initial(content);
            }
        }
    }
}
