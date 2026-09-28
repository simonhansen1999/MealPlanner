using Madplan.Authentication;
using Madplan.Database;
using Madplan.Repository;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;

namespace Madplan.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDepedenyInjection(this IServiceCollection services)
        {
            services.AddScoped<NavigationState>();

            services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();

            services.AddTransient<FoodService>();
            services.AddTransient<FoodRepository>();

            services.AddTransient<FoodPlanService>();
            services.AddTransient<FoodPlanRepository>();

            services.AddTransient<UserService>();
            services.AddTransient<UserRepository>();

            services.AddTransient<FamilyGroupService>();
            services.AddTransient<FamilyGroupRepository>();

            services.AddTransient<PDFService>();

            return services;
        }

        public static IServiceCollection AddGoogle(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = AppConstants.AuthScheme;
                options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
            })
            .AddCookie(AppConstants.AuthScheme, options =>
            {
                options.Cookie.Name = AppConstants.AuthScheme;
                options.Cookie.HttpOnly = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Cookie.SameSite = SameSiteMode.Lax; // important for Google
                options.ExpireTimeSpan = TimeSpan.FromDays(GlobalVariables.GoogleAuthenticationDays);
                options.SlidingExpiration = true;
                options.LoginPath = "/login";
            })
            .AddGoogle(GoogleDefaults.AuthenticationScheme, googleOptions =>
            {
                googleOptions.ClientId = configuration["Authentication:Google:ClientId"] ?? "No ClientID found.";
                googleOptions.ClientSecret = configuration["Authentication:Google:ClientSecret"] ?? "No ClientSecret found.";
                googleOptions.AccessDeniedPath = "/access-denied";
                googleOptions.SignInScheme = AppConstants.AuthScheme;
                googleOptions.SaveTokens = true;

                googleOptions.Events.OnCreatingTicket = context =>
                {
                    context.Properties.IsPersistent = true;
                    context.Properties.ExpiresUtc = DateTimeOffset.UtcNow.AddDays(GlobalVariables.GoogleAuthenticationDays);
                    return Task.CompletedTask;
                };

                googleOptions.Events.OnRedirectToAuthorizationEndpoint = context =>
                {
                    context.Response.Redirect(context.RedirectUri + "&prompt=select_account");
                    return Task.CompletedTask;
                };
            });

            services.AddDataProtection().PersistKeysToFileSystem(new DirectoryInfo("/data/keys")).SetApplicationName("Madplan");

            return services;
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            string dbFolder;

            // 1. Allow override (Docker / prod)
            var explicitPath = Environment.GetEnvironmentVariable("DB_PATH");
            if (!string.IsNullOrWhiteSpace(explicitPath))
            {
                dbFolder = explicitPath;
            }
            else if (OperatingSystem.IsWindows())
            {
                // 2. Windows dev: %APPDATA%\Madplan
                dbFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Madplan");
            }
            else
            {
                // 3. Linux/macOS dev (NOT Docker): ~/.madplan
                var home = Environment.GetEnvironmentVariable("HOME") ?? ".";
                dbFolder = Path.Combine(home, ".madplan");
            }

            Directory.CreateDirectory(dbFolder);

            var dbPath = Path.Combine(dbFolder, "madplan.db");

            services.AddDbContext<AppDbContext>(options => options.UseSqlite($"Data Source={dbPath}"));

            return services;
        }

    }
}
