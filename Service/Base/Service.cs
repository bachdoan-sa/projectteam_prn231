using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using WebApp.Repository.Base.Interface;

namespace WebApp.Service.Base
{
    public abstract class Service
    {
        protected readonly IUnitOfWork UnitOfWork;
		protected readonly IMapper _mapper;
        protected Service(IServiceProvider serviceProvider)
        {
            UnitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }
    }
}
