using Invedia.DI.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Repository.Base;
using WebApp.Repository.Entities;
using WebApp.Repository.Repositories;
using WebApp.Repository.Repositories.IRepositories;
using WebApp.Service.IServices;

namespace WebApp.Service.Services
{
    [ScopedDependency(ServiceType = typeof(IOrchidCategoriesService))]
    public class OrchidCategoryService : Base.Service,IOrchidCategoriesService
    {
        private readonly IOrchidCategoriesRepository _orchidCategoryRepository;

        public OrchidCategoryService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _orchidCategoryRepository = serviceProvider.GetRequiredService<IOrchidCategoriesRepository>();
        }
        public Task<OrchidCategory> AddOrchidCategory(OrchidCategory orchidCategory)
        {
            var entity = new OrchidCategory
            {
                CategoryName = orchidCategory.CategoryName,
            };
            var addorchid = _orchidCategoryRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(addorchid);
        }

        public Task<List<OrchidCategory>> GetAllOrchidCategorys()
        {
            var list = _orchidCategoryRepository.Get().ToListAsync();
            return list;
        }

        public Task<OrchidCategory> GetOrchidCategoryById(string id)
        {
            var orchidCategory = _orchidCategoryRepository.Get(orchidCategory => orchidCategory.Id == id).FirstOrDefaultAsync();
            return orchidCategory;
        }

        public Task UpdateOrchidCategory(OrchidCategory orchidCategory)
        {
            var existingorchidCategory = _orchidCategoryRepository.GetSingle(x => x.Id == orchidCategory.Id);
            if (existingorchidCategory != null)
            {



                existingorchidCategory.CategoryName = orchidCategory.CategoryName;
                _orchidCategoryRepository.Update(existingorchidCategory);
                UnitOfWork.SaveChange();

            }

            return Task.FromResult(existingorchidCategory.Id);
        }
    }
}
