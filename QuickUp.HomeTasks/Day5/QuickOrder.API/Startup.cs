﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using QuickOrder.API.Extensions;
using QuickOrder.API.Middlewares.Authentication;
using QuickOrder.DAL;
using QuickOrder.DAL.Infrastructure;
using QuickOrder.DAL.Repostitories;
using QuickOrder.Entities;
using QuickOrder.Services;
using QuickOrder.Services.Contracts;

namespace QuickOrder.API
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
                options => options.UseSqlServer(Configuration["ConnectionStrings:TestAppDatabase"]));

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<QuickOrderContext, int>();

            services.Configure<AuthorizationSettings>(ConfigAuthSettings);

            // DI DAL
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IEntityBaseRepository<>), typeof(EntityBaseRepository<>));

            // DI Services
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();

            services.AddMvc();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseTokenAuth();
            app.UseMiddleware<ClaimsPrincipalFactoryMiddleware>();
            app.UseIdentity();

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
