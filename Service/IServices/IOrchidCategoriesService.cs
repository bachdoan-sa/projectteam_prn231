using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Repository.Entities;

namespace WebApp.Service.IServices
{
    public interface IOrchidCategoriesService
    {
        Task<List<OrchidCategory>> GetAllOrchidCategorys();
        Task<OrchidCategory> GetOrchidCategoryById(string id);
        Task AddOrchidCategory(OrchidCategory orchidCategory);
        Task UpdateOrchidCategory(OrchidCategory orchidCategory);
    }
}
