using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Date;
using WebApplication1.Date.Interfaces;
using WebApplication1.Date.Mocks;
using WebApplication1.Date.Models;
using WebApplication1.Date.Repository;

namespace WebApplication1
{
	public class Startup
	{
		private IConfigurationRoot _confSting;

		public Startup(IWebHostEnvironment hostEnv)
		{
			_confSting = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
		}

		// Метод для додавання служб до контейнера DI
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<AppDBContent>(options =>
				options.UseSqlServer(_confSting.GetConnectionString("DefaultConnection")));

			services.AddTransient<IAllCars, CarRepository>();
			services.AddTransient<ICarsCategory, CategoryRepository>();
			services.AddTransient<IAllOrders, OrdersRepository>();

			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddScoped(sp => ShopCart.GetCart(sp));
			services.AddMemoryCache();
			services.AddSession();

			services.AddMvc();
		}

		// Метод для налаштування HTTP-конвеєра (pipeline)
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseStatusCodePages();
			app.UseStaticFiles();
			app.UseSession();
			app.UseRouting();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
				endpoints.MapControllerRoute(
					name:"categoryFilter",
					pattern: "{controller =Car}/{action}/{category?}", defaults: new {Controller = "Car", action = "List"});
			});

			AppDBContent content;
			using (var scope = app.ApplicationServices.CreateScope())
			{
				content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
				DBObject.Initial(content);
			}
			
		}
	}
}