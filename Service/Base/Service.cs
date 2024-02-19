using Microsoft.Extensions.DependencyInjection;
using WebApp.Repository.Base.Interface;

namespace WebApp.Repository.Base
{
    public abstract class Service
    {
        protected readonly IUnitOfWork UnitOfWork;
        protected Service(IServiceProvider serviceProvider)
        {
            UnitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
        }
    }
}
