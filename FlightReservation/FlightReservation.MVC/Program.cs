using FlightReservation.MVC.Context;
using FlightReservation.MVC.Models;
using FlightReservation.MVC.Repositories;
using FlightReservation.MVC.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Globalization;
using System.Reflection;

namespace FlightReservation.MVC;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddScoped<UserRepository>();
        builder.Services.AddScoped<PlaneRepository>();
        builder.Services.AddScoped<RouteRepository>();

        #region Localization
        builder.Services.AddSingleton<LanguageService>();
        builder.Services.AddLocalization(opt => opt.ResourcesPath = "Resources");

        builder.Services.AddMvc()
            .AddViewLocalization()
            .AddDataAnnotationsLocalization(options =>
            options.DataAnnotationLocalizerProvider = (type, factory) =>
            {
                var assemblyName = new AssemblyName(typeof(SharedResource).GetTypeInfo().Assembly.FullName ?? "");
                return factory.Create(nameof(SharedResource), assemblyName.Name ?? "");
            });
        #endregion

        builder.Services.Configure<RequestLocalizationOptions>(options =>
        {
            var supportCultures = new List<CultureInfo> {
                new CultureInfo("en-US"),
                new CultureInfo("tr-TR")
            };
            options.DefaultRequestCulture = new RequestCulture(culture: "tr-TR",
                uiCulture: "tr-TR");
            options.SupportedCultures = supportCultures;
            options.SupportedUICultures = supportCultures;
            options.RequestCultureProviders.Insert(0, new QueryStringRequestCultureProvider());
        });


        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
        });

        builder.Services.AddAuthentication("CookieAuth").AddCookie("CookieAuth", configuration =>
        {
            configuration.AccessDeniedPath = "/Account/Login";
            configuration.LoginPath = "/Account/Login";
            configuration.ExpireTimeSpan = TimeSpan.FromHours(1);
            configuration.Cookie.Name = "UserLoginCookie";
        });

        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }



        app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);


        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        using (var scope = app.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var result = context.Set<User>().Any(p => p.Email == "demirtarik44@gmail.com");
            if (!result)
            {
                User user = new()
                {
                    FirstName = "Tarýk",
                    LastName = "Demir",
                    Email = "demirtarik44@gmail.com",
                    Password = "Pas"
                };

                context.Set<User>().Add(user);

                Role? role = context.Set<Role>().Where(p => p.Name == "Admin").FirstOrDefault();

                if (role is null)
                {
                    role = new()
                    {
                        Name = "Admin"
                    };
                    context.Set<Role>().Add(role);
                }

                context.Set<UserRole>().Add(new()
                {
                    RoleId = role.Id,
                    UserId = user.Id
                });
                context.SaveChanges();
            }
        }

        using (var scope = app.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
        }

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
