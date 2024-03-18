using AutoMapper;
using WebApp.Core.Mapper;
using WebApp.Repository.Entities;
using WebApp.Repository.Mapper;

namespace WebApp.Extensions
{
    public static class AutoMapperExtension
    {
        public static IServiceCollection AddAutoMapperServices(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile(new AccountProfile());
                cfg.AddProfile(new RoleProfile());
                cfg.AddProfile(new AuctionEventProfile());
                cfg.AddProfile(new AuctionStateProfile());
                cfg.AddProfile(new MutatiionProfile());
                cfg.AddProfile(new OrchidProfile());
            });

            return services;
        }
    }
}
