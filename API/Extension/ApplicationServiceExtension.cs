using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreRateLimit;
using Core.Interfaces;
using Infrastructure.UnityOfWork;

namespace api.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options => {
            options.AddPolicy("CorsPolicy", buider => 
            buider.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        });

        public static void AddApplicationServices(this IServiceCollection services){
            services.AddScoped<IUnityOfWork, UnityOfWork>();
        }
        public static void ConfigureRateLimit(this IServiceCollection services){
            services.AddMemoryCache();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.AddInMemoryRateLimiting();
            services.Configure<IpRateLimitOptions>(options => {
                options.EnableEndpointRateLimiting = true;
                options.StackBlockedRequests = false;
                options.HttpStatusCode = 429;
                options.RealIpHeader = "X-Real-Ip";
                options.GeneralRules = new List<RateLimitRule>{
                    new RateLimitRule{
                        Endpoint ="*",
                        Period="10s",
                        Limit=2
                    }
                };
            });
        }
    }
}
