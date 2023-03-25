using MyAngle.Mvc.Conventions;
using MyAngle.Mvc.Core.Extensions;
using MyAngle.Mvc.Entities;
using MyAngle.Mvc.Features.Animals.Dogs;
using MyAngle.Mvc.Features.Dictionary.Dictionary;
using MyAngle.Mvc.Infrastructure;

namespace MyAngle.Mvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddMvc(o => o.Conventions.Add(new FeatureConvention()))
                .AddRazorOptions(options =>
                {
                    options.ConfigureFeatureFolders();
                });
            builder.Services.AddHttpClient();
            // builder.Services.AddControllersWithViews();

            //services//
            builder.Services.AddScoped<IApiRequestService<Dog>, DogService>();
            builder.Services.AddScoped<IDictionaryService, DictionaryService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}