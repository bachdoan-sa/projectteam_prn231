using Invedia.DI.Attributes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Repository.Entities;
using WebApp.Repository.Repositories;
using WebApp.Repository.Repositories.IRepositories;
using WebApp.Service.IServices;

namespace WebApp.Service.Services
{
    [ScopedDependency(ServiceType = typeof(IAccountService))]
    public class OrchidCategoryService : IOrchidCategoriesService
    {
        private readonly IOrchidCategoriesRepository _orchidCategoryRepository;

        public OrchidCategoryService(IOrchidCategoriesRepository orchidCategoryRepository)
        {
            _orchidCategoryRepository = orchidCategoryRepository;
        }
        public Task AddOrchidCategory(OrchidCategory orchidCategory)
        {
            var addorchid = _orchidCategoryRepository.Add(orchidCategory);
            return Task.FromResult(orchidCategory);
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

            }
            return Task.FromResult(existingorchidCategory.Id);
        }
    }
}
