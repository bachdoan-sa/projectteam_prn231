using AutoMapper;
using WebApp.Core.Mapper;

namespace WebApp.Extensions
{
    public static class AutoMapperExtension
    {
        public static IServiceCollection AddAutoMapperServices(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile(new AccountProfile());
                
            });

            return services;
        }
    }
}
