using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NS.WebApp.MVC.Extensions;

namespace NS.WebApp.MVC.Configuration
{
	public static class WebAppConfig
	{
		public static void AddMvcConfiguration(this IServiceCollection services)
		{
			services.AddControllersWithViews();
		}

		public static void UseMvcConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				//app.UseDeveloperExceptionPage();
				app.UseExceptionHandler("/erro/500");
				app.UseStatusCodePagesWithRedirects("/erro/{0}");
				app.UseHsts();
			}
			else
			{
				app.UseExceptionHandler("/erro/500");
				app.UseStatusCodePagesWithRedirects("/erro/{0}");
				app.UseHsts();
			}



			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseIdentityConfiguration();

			app.UseMiddleware<ExceptionMiddleware>();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
