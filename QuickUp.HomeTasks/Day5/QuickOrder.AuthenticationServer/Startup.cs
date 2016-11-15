using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using QuickOrder.AuthenticationServer.Extensions;
using QuickOrder.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using QuickOrder.Entities;

namespace QuickOrder.AuthenticationServer
{
    public class Startup
    {
        private IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true);

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<QuickOrderContext>(
                options =>
                    options.UseSqlServer(
                        Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, Role>(
                        options =>
                        {
                            options.Password.RequireDigit = false;
                            options.Password.RequireLowercase = false;
                            options.Password.RequireUppercase = false;
                            options.Password.RequiredLength = 3;
                            options.Password.RequireNonAlphanumeric = false;
                            options.User.RequireUniqueEmail = true;
                            options.Lockout.MaxFailedAccessAttempts = 5;
                        })
                    .AddEntityFrameworkStores<QuickOrderContext>();

            services.Configure<AuthorizationSettings>(ConfigAuthSettings);

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultTokenProvider();

            app.UseMvc();
        }

        private void ConfigAuthSettings(AuthorizationSettings settings)
        {
            settings.Audience = "AuthAudience";
            settings.ExpirationDays = 30;
            settings.Issuer = "AuthIssuer";
            settings.SecretKey = "fa34001a-f717-43a4-9211-129a63aedf8a";
        }
    }
}
